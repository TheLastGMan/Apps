using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLoader
{
    public class ReadingUtil
    {
        public async Task<ReadingResult> LoadReading(DateTime date, ReadingType type)
        {
            var content = await DownloadContent(date);
            var readings = ParseVersesFromFeed(content);
            var result = SelectReading(readings, type);
            return result;
        }

        public async Task<Dictionary<ReadingType, ReadingResult>> LoadReadings(DateTime date)
        {
            var content = await DownloadContent(date);
            var readings = ParseVersesFromFeed(content);
            var result = new Dictionary<ReadingType, ReadingResult>()
            {
                [ReadingType.Reading1] = SelectReading(readings, ReadingType.Reading1),
                [ReadingType.Responsorial] = SelectReading(readings, ReadingType.Responsorial),
                [ReadingType.Reading2] = SelectReading(readings, ReadingType.Reading2),
                [ReadingType.Alleluia] = SelectReading(readings, ReadingType.Alleluia),
                [ReadingType.PreGospelVerse] = SelectReading(readings, ReadingType.PreGospelVerse),
                [ReadingType.Gospel] = SelectReading(readings, ReadingType.Gospel)
            };
            return result;
        }

        private async Task<string> DownloadContent(DateTime date)
        {
            var dateFmt = date.ToString("MMddyy");
            var url = $"https://bible.usccb.org/bible/readings/{dateFmt}.cfm";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (snd, cert, chain, errors) => { return true; };

            var client = new WebClient();
            var data = await client.DownloadStringTaskAsync(new Uri(url));
            return data;
        }

        public List<ReadingResult> ParseVersesFromFeed(string data)
        {
            var results = new List<ReadingResult>();

            int idx = 0;
            while ((idx = data.IndexOf("b-verse", idx)) >= 0)
            {
                var startIdx = data.IndexOf('>', idx) + 1;
                int divClosures = 1;
                while (divClosures > 0)
                {
                    int divEnd = data.IndexOf("</div>", idx);
                    int divStart = data.IndexOf("<div", idx);
                    if (divEnd < divStart)
                    {
                        divClosures -= 1;
                        idx = divEnd + 6;
                    }
                    else
                    {
                        divClosures += 1;
                        idx = divStart + 4;
                    }
                }

                var subData = data.Substring(startIdx, idx - startIdx - 6);

                //reading type
                var sidx = subData.IndexOf("<h3");
                sidx = subData.IndexOf(">", sidx) + 1;
                var eidx = subData.IndexOf("</", sidx);
                var rType = subData.Substring(sidx, eidx - sidx);

                //verse
                sidx = subData.IndexOf("<a", sidx);
                sidx = subData.IndexOf(">", sidx) + 1;
                eidx = subData.IndexOf("</", sidx);
                var rVerse = subData.Substring(sidx, eidx - sidx).Replace(" \">", string.Empty);

                //body
                sidx = subData.IndexOf("body", sidx);
                sidx = subData.IndexOf(">", sidx) + 1;
                eidx = subData.IndexOf("</div", sidx);
                var rContent = subData.Substring(sidx, eidx - sidx);

                //mapping
                var record = new ReadingResult()
                {
                    Found = true,
                    Header = FormatHeader(rType),
                    Verse = FormatHeader(rVerse),
                    Content = FormatContent(rContent)
                };
                results.Add(record);
            }

            return results;
        }

        private string FormatHeader(string header)
        {
            var nHeader = header.Replace("Reading 2", "Reading II");
            nHeader = nHeader.Replace("Reading 1", "Reading I");
            nHeader = FormatContent(nHeader);
            return nHeader;
        }

        private string FormatContent(string content)
        {
            var nContent = content.Replace("<p>", "");
            nContent = nContent.Replace("</p>", "<br/>");
            nContent = nContent.Replace("&nbsp;", " ");
            nContent = nContent.Replace("Â", "");
            nContent = nContent.Trim(Environment.NewLine.ToCharArray().Concat(new char[] { ' ' }).ToArray());
            nContent = nContent.TrimEnd(new char[] { ' ', ' ' });
            nContent = nContent.TrimStart(new char[] { ' ', ' ' });
            return nContent;
        }

        public ReadingResult SelectReading(List<ReadingResult> readings, ReadingType type)
        {
            var header = ReadingHeader(type);
            var reading = readings.FirstOrDefault(f => f.Header == header || f.Header.StartsWith(header));
            if (reading == default)
                return new ReadingResult() { Found = false, Header = header, Verse = "Unknown", Content = "Unable to locate in USCCB data feed." };
            return reading;
        }

        private string ReadingHeader(ReadingType type)
        {
            string headingText;
            switch (type)
            {
                case ReadingType.Reading1:
                    headingText = "Reading I";
                    break;
                case ReadingType.Responsorial:
                    headingText = "Responsorial Psalm";
                    break;
                case ReadingType.Reading2:
                    headingText = "Reading II";
                    break;
                case ReadingType.Alleluia:
                    headingText = "Alleluia";
                    break;
                case ReadingType.PreGospelVerse:
                    headingText = "Verse before the Gospel";
                    break;
                default:
                    headingText = "Gospel";
                    break;
            }
            return headingText;
        }

        [Obsolete("Use SelectReading")]
        private ReadingResult ParseSection(string data, ReadingType type)
        {
            //determine what section to load
            string headingText = ReadingHeader(type);

            //map reading text
            data = data.Replace("Reading 1", "Reading I");
            data = data.Replace("Reading 2", "Reading II");
            data = data.Replace("<div class=\"content - body\">", "<div class=\"content-body\">");


            //jump to section "Â "
            var formats = new string[] { $"<h3 class=\"name\">{headingText}</h3>",
                                         $"<h3 class=\"name\">{headingText}&nbsp;</h3>",
                                         $"<h3 class=\"name\">{headingText}Â </h3>",
                                         $"<h3 class=\"name\">{headingText}Â</h3>",
                                         $"<h3 class=\"name\">{headingText} </h3>",
                                         $"<h3 class=\"name\">{headingText}" };
            int index = -1;
            foreach (var fmt in formats)
            {
                index = data.IndexOf(fmt);
                if (index >= 0)
                    break;
            }
            if (index <= 0)
                return new ReadingResult() { Header = headingText, Verse = "Unknown", Content = "Unable to locate section in data feed, is it available today?" };

            //jump up to container section
            //index = data.Substring(0, index).LastIndexOf("<div class=\"innerblock\">");

            //load verse
            string verse;
            int index2;
            try
            {
                index = data.IndexOf("<a href=", index);
                index = data.IndexOf(">", index) + 1;
                index2 = data.IndexOf("</a>", index);
                verse = data.Substring(index, index2 - index);
            }
            catch (Exception ex)
            {
                throw new Exception("Issue while parsing the (Verse) from the data feed: " + ex.Message);
            }

            //load reading
            string content;
            try
            {
                index = data.IndexOf("<div class=\"content-body\">", index);
                index = data.IndexOf("<p>", index) + 3;
                index2 = data.IndexOf("</div>", index);
                content = data.Substring(index, index2 - index);
                content = content.Substring(0, content.LastIndexOf("</p>"));
                content = content.Replace("<p>", "");
                content = content.Replace("</p>", "<br/>");
                content = content.Trim(Environment.NewLine.ToCharArray().Concat(new char[] { ' ' }).ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Issue while parsing the (Content) from the data feed: " + ex.Message);
            }

            //combine
            var result = new ReadingResult() { Header = headingText, Verse = verse, Content = content, Found = true };
            return result;
        }
    }
}
