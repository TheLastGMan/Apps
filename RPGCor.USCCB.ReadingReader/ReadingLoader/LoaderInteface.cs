using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReadingLoader
{
    public partial class LoaderInteface
    {
        private const string HeaderIntoTBName = "Header_Intro";
        private const string HeaderReadingTBName = "Header_Reading";
        private const string HeaderVerseTBName = "Verse";
        private const string HeaderContentTBName = "Content";
        private const string HeaderPageNumberTBName = "Page_Number";

        private void LoaderInteface_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void Reading1_Click(object sender, RibbonControlEventArgs e)
        {
            DoAction(ReadingType.Reading1);
        }

        private void ResponsorialPsalm_Click(object sender, RibbonControlEventArgs e)
        {
            DoAction(ReadingType.Responsorial);
        }

        private void Reading2_Click(object sender, RibbonControlEventArgs e)
        {
            DoAction(ReadingType.Reading2);
        }

        private void Alleluia_Click(object sender, RibbonControlEventArgs e)
        {
            DoAction(ReadingType.Alleluia);
        }

        private void Gospel_Click(object sender, RibbonControlEventArgs e)
        {
            DoAction(ReadingType.Gospel);
        }

        private void AutomateToday_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now);
        }

        private void AutomateToday1_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(1));
        }

        private void AutomateToday2_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(2));
        }

        private void AutomateToday3_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(3));
        }

        private void AutomateToday4_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(4));
        }

        private void AutomateToday5_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(5));
        }

        private void AutomateToday6_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(6));
        }

        private void AutomateToday7_Click(object sender, RibbonControlEventArgs e)
        {
            DoMultipleAction(DateTime.Now.AddDays(7));
        }

        private static readonly object LockObj = new object();
        private static bool InProgress = false;
        private async void DoMultipleAction(DateTime date)
        {
            //ensure single instance
            lock (LockObj)
            {
                if (InProgress)
                    return;
                else
                    InProgress = true;
            }

            //load readings
            try
            {
                //download readings
                var result = await new ReadingUtil().LoadReadings(date);

                //update intro slide with date
                int headerSlide = FindSlideNumber(HeaderIntoTBName);
                if (headerSlide == -1)
                    throw new Exception("Unable to find slide that has a textbox with a name of: " + HeaderIntoTBName);

                //delete intermediate slides
                //validate
                int firstSlide = FindFirstSlideNumber(HeaderReadingTBName);
                int lastSlide = FindLastSlideNumber(HeaderReadingTBName);
                if (firstSlide == -1)
                    throw new Exception("Unable to find the First Slide that has a textbox with a name of: " + HeaderReadingTBName);
                if (lastSlide == -1)
                    throw new Exception("Unable to find the Last Slide that has a textbox with a name of: " + HeaderReadingTBName);

                //add/delete slide differential
                var readingOrder = new ReadingType[] { ReadingType.Reading1, ReadingType.Responsorial, ReadingType.Reading2, ReadingType.Alleluia, ReadingType.Gospel };
                int readingSlides = lastSlide - firstSlide + 1;
                int diff = Math.Abs(readingSlides - readingOrder.Length);
                for (int cnt = 0; cnt < diff; cnt++)
                    if (readingSlides > readingOrder.Length)
                        //delete
                        Globals.ThisAddIn.Application.ActivePresentation.Slides[lastSlide - cnt].Delete();
                    else
                    {
                        //add
                        Globals.ThisAddIn.Application.ActivePresentation.Slides[lastSlide + cnt].Copy();
                        Globals.ThisAddIn.Application.ActivePresentation.Slides.Paste(lastSlide + cnt + 1);
                    }

                //update slides
                int additionalSlides = 0;
                for (int cnt = 0; cnt < readingOrder.Length; cnt++)
                {
                    //update current slide with reading
                    int slideNumber = firstSlide + cnt + additionalSlides;
                    var currentSlide = Globals.ThisAddIn.Application.ActivePresentation.Slides[slideNumber];
                    var readingType = readingOrder[cnt];
                    var readingContent = result[readingType];

                    //during lent, it switches to Pre Gospel Verse, use backup option if not found
                    if(!readingContent.Found && readingType == ReadingType.Alleluia)
                    {
                        readingType = ReadingType.PreGospelVerse;
                        readingContent = result[readingType];
                    }    

                    UpdateSlide(currentSlide, readingType, readingContent);
                    additionalSlides += SplitSlide(slideNumber, HeaderContentTBName, HeaderPageNumberTBName);
                    UpdateSlideNotes(currentSlide, $" => For Date: {date:dddd, MMM d, yyyy}", true);
                }

                //update header slide date as secondary indication of it being completed
                UpdateIntroSlide(Globals.ThisAddIn.Application.ActivePresentation.Slides[headerSlide], HeaderIntoTBName, date);

                //make intro slide active
                Globals.ThisAddIn.Application.ActivePresentation.Slides[headerSlide].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more issues occurred: " + ex.Message, "ISSUE", MessageBoxButtons.OK);
            }

            //release lock
            lock (LockObj)
                InProgress = false;
        }

        private async void DoAction(ReadingType type)
        {
            //ensure single instance
            lock (LockObj)
            {
                if (InProgress)
                    return;
                else
                    InProgress = true;
            }

            //update slide with individual reading
            try
            {
                var slide = (Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
                UpdateSlideNotes(slide, "Loading data feed", false);

                var result = await new ReadingUtil().LoadReading(DateTime.Now, type);
                UpdateSlide(slide, type, result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more issues occurred: " + ex.Message, "ISSUE", MessageBoxButtons.OK);
            }

            //release lock
            lock (LockObj)
                InProgress = false;
        }

        private int SplitSlide(int slideNumber, string contentTbName, string pageNumberTbName)
        {
            //load number of lines
            var lines = new List<string>(128);
            Shape foundShape = null;
            Shape pageShape = null;
            foreach (Shape shape in Globals.ThisAddIn.Application.ActivePresentation.Slides[slideNumber].Shapes)
                if (shape.Name.Equals(contentTbName, StringComparison.InvariantCultureIgnoreCase))
                {
                    foundShape = shape;
                    string textLine;
                    int lineNumber = 1;
                    while (!string.IsNullOrEmpty(textLine = shape.TextFrame.TextRange.Lines(lineNumber).Text))
                    {
                        lines.Add(textLine);
                        lineNumber++;
                    }
                }
                else if (shape.Name.Equals(pageNumberTbName, StringComparison.InvariantCultureIgnoreCase))
                    pageShape = shape;

            //validate
            if (foundShape == null)
                throw new Exception("Unable to find textbox with name: " + contentTbName);
            if (pageShape == null)
                throw new Exception("Unable to find textbox with name: " + pageNumberTbName);

            //split into another slide if there are so many lines
            if (lines.Count >= 40)
            {
                //find end of sentence
                int divider = lines.Count / 2;
                while (!new char[] { '.', '\"', }.Contains(lines[divider].TrimEnd(new char[] { ' ', ' ', '\r', '\n' }).Last()))
                    divider++;

                //split slide into 2nd half
                pageShape.TextFrame.TextRange.Text = "2 / 2";
                string content = string.Join("", lines.GetRange(divider + 1, lines.Count - divider - 1));
                content = content.TrimEnd(new char[] { ' ', ' ', '\r', '\n' }); //similar to a space, space, cr, lf
                ApplyTextBoxSettings(foundShape, 48, false, true, "Times New Roman", content, false);

                //copy slide
                Globals.ThisAddIn.Application.ActivePresentation.Slides[slideNumber].Copy();
                Globals.ThisAddIn.Application.ActivePresentation.Slides.Paste(slideNumber + 1);

                //update current slide to 1st half of split
                pageShape.TextFrame.TextRange.Text = "1 / 2";
                content = string.Join("", lines.GetRange(0, divider + 1));
                content = content.TrimEnd(new char[] { ' ', ' ', '\r', '\n' }); //similar to a space, space, cr, lf
                ApplyTextBoxSettings(foundShape, 48, false, true, "Times New Roman", content, false);

                return 1;
            }
            return 0;
        }

        private void UpdateSlide(Slide slide, ReadingType type, ReadingResult reading)
        {
            //validate control name exists
            var controlNames = new string[] { HeaderReadingTBName, HeaderVerseTBName, HeaderContentTBName, HeaderPageNumberTBName };
            var controlNamesFound = new bool[] { false, false, false, false };
            for (int i = 1; i <= slide.Shapes.Count; i++)
                for (int j = 0; j < controlNames.Length; j++)
                    if (slide.Shapes[i].Name == controlNames[j])
                        controlNamesFound[j] = true;

            //all or nothing 
            if (controlNamesFound.Any(f => f == false))
            {
                throw new Exception($"Textboxes with names not found: ({ string.Join(", ", controlNames.Select((s, i) => controlNamesFound[i] == false ? s : string.Empty).Where(f => f != string.Empty)) })");
            }
            else
            {
                //update textboxes with new content
                for (int i = 1; i <= slide.Shapes.Count; i++)
                {
                    var shape = slide.Shapes[i];
                    var shapeName = shape.Name.ToUpper();
                    if (shapeName.Equals(HeaderPageNumberTBName, StringComparison.InvariantCultureIgnoreCase))
                        //HEADER
                        ApplyTextBoxSettings(shape, 18, true, false, "Georgia", string.Empty);
                    else if (shapeName.Equals(HeaderReadingTBName, StringComparison.InvariantCultureIgnoreCase))
                        //READING
                        ApplyTextBoxSettings(shape, 28, true, false, "Georgia", reading.Header);
                    else if (shapeName.Equals(HeaderVerseTBName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //VERSE
                        ApplyTextBoxSettings(shape, 12, false, false, "Verdana", reading.Verse);

                        //check if leading verse indication is missing for responsorial psalms
                        if (type == ReadingType.Responsorial && !shape.TextFrame.TextRange.Text.Trim().StartsWith("Ps"))
                            shape.TextFrame.TextRange.Text = "Ps " + shape.TextFrame.TextRange.Text.Trim();
                    }
                    else if (shapeName.Equals(HeaderContentTBName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //CONTENT
                        //make the text bigger so it will scale down to fit
                        shape.TextFrame.WordWrap = Microsoft.Office.Core.MsoTriState.msoTrue;
                        shape.TextFrame2.Column.Number = 2;
                        ApplyTextBoxSettings(shape, 48, false, true, "Times New Roman", reading.Content);

                        //concat worlds or commas with newline to single line with a space between
                        foreach (Match match in Regex.Matches(shape.TextFrame.TextRange.Text, "([\\w],?;?\\s?)[\\r|\\n|\\r\\n]([\\w|“])", RegexOptions.Multiline))
                        {
                            string replace = match.Groups[1].Value + " " + match.Groups[2].Value;
                            shape.TextFrame.TextRange.Text = shape.TextFrame.TextRange.Text.Replace(match.Groups[0].Value, replace);
                        }

                        //additional actions for certain types
                        if (type == ReadingType.Responsorial)
                        {
                            shape.TextFrame.TextRange.Text = Regex.Replace(shape.TextFrame.TextRange.Text, "\\(.*\\)", "", RegexOptions.Multiline);
                            shape.TextFrame.TextRange.Text = Regex.Replace(shape.TextFrame.TextRange.Text, "R\\.\\s+", "R. ", RegexOptions.Multiline | RegexOptions.CultureInvariant);
                        }
                        else if (type == ReadingType.Alleluia)
                        {
                            shape.TextFrame2.Column.Number = 1;
                        }

                        //search for <strong> and translate to bold style
                        SelectedTextFindAction("strong", shape, tr => tr.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue);

                        //check for <em> to italisize
                        SelectedTextFindAction("em", shape, tr => tr.Font.Italic = Microsoft.Office.Core.MsoTriState.msoTrue);
                    }
                }

                //update notes for last success time
                UpdateSlideNotes(slide, $"Last updated: { DateTime.Now.ToString("MMM/d/yyyy h:mm:ss tt") }", false);
            }
        }

        private void UpdateIntroSlide(Slide slide, string textboxName, DateTime date)
        {
            //find textbox and update with format
            for (int i = 1; i <= slide.Shapes.Count; i++)
                if (slide.Shapes[i].Name.Equals(textboxName))
                {
                    var dateFmt = date.ToString("dddd, MMMM d");
                    var daySuffix = DaySuffix(date.Day);
                    slide.Shapes[i].TextFrame.TextRange.Text = $"Daily Mass - { dateFmt }{ daySuffix }";
                    slide.Shapes[i].TextFrame.TextRange.Characters(slide.Shapes[i].TextFrame.TextRange.Text.Length - 1, 2).Font.Superscript = Microsoft.Office.Core.MsoTriState.msoTrue;
                }
        }

        private string DaySuffix(int dayOfMonth)
        {
            switch (dayOfMonth)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        private int FindSlideNumber(string tbName)
        {
            for (int i = 1; i <= Globals.ThisAddIn.Application.ActivePresentation.Slides.Count; i++)
                foreach (Shape shape in Globals.ThisAddIn.Application.ActivePresentation.Slides[i].Shapes)
                    if (shape.Name.Equals(tbName, StringComparison.InvariantCultureIgnoreCase))
                        return i;
            return -1;
        }

        private int FindFirstSlideNumber(string tbName)
        {
            for (int i = 1; i <= Globals.ThisAddIn.Application.ActivePresentation.Slides.Count; i++)
                foreach (Shape shape in Globals.ThisAddIn.Application.ActivePresentation.Slides[i].Shapes)
                    if (shape.Name.Equals(tbName, StringComparison.InvariantCultureIgnoreCase))
                        return i;
            return -1;
        }

        private int FindLastSlideNumber(string tbName)
        {
            for (int i = Globals.ThisAddIn.Application.ActivePresentation.Slides.Count; i >= 1; i--)
                foreach (Shape shape in Globals.ThisAddIn.Application.ActivePresentation.Slides[i].Shapes)
                    if (shape.Name.Equals(tbName, StringComparison.InvariantCultureIgnoreCase))
                        return i;
            return -1;
        }

        private void ApplyTextBoxSettings(Shape shape, int fontSizePts, bool isBold, bool autoSizeText, string fontName, string content, bool stripNewLines = true)
        {
            shape.TextFrame.TextRange.Text = string.Empty;
            shape.TextFrame.TextRange.Font.Size = fontSizePts;
            shape.TextFrame.TextRange.Font.Bold = isBold ? Microsoft.Office.Core.MsoTriState.msoTrue : Microsoft.Office.Core.MsoTriState.msoFalse;
            shape.TextFrame2.AutoSize = autoSizeText ? Microsoft.Office.Core.MsoAutoSize.msoAutoSizeTextToFitShape : Microsoft.Office.Core.MsoAutoSize.msoAutoSizeNone;
            shape.TextFrame.TextRange.Font.NameAscii = fontName;
            shape.TextFrame.TextRange.Text = Cleanup(content, stripNewLines);
        }

        private void SelectedTextFindAction(string tagName, Shape shape, Action<TextRange> foundTextAction)
        {
            int j;
            while ((j = shape.TextFrame.TextRange.Find($"<{tagName}>")?.Start ?? -1) >= 0)
            {
                int end = shape.TextFrame.TextRange.Find($"</{tagName}>", j).Start + 9;
                var textSelected = shape.TextFrame.TextRange.Characters(j, end - j);
                foundTextAction(textSelected);
                textSelected.Replace($"<{tagName}>", "");
                textSelected.Replace($"</{tagName}>", "");
            }
        }

        private string Cleanup(string content, bool stripNewLines = true)
        {
            if (stripNewLines)
            {
                content = content.Replace(Environment.NewLine, "");
                content = content.Replace("\r", "");
                content = content.Replace("\n", "");
            }
            content = content.Replace("â€œ", "“");
            content = content.Replace("â€", "”");
            content = content.Replace("â€˜", "‘");
            content = content.Replace("â€™", "’");
            content = content.Replace("â€", "-");
            content = content.Replace("Â", "");
            content = content.Replace("<br />", Environment.NewLine);
            content = content.Replace("<br/>", Environment.NewLine);
            content = content.Replace("<span>", "");
            content = content.Replace("</span>", "");
            //content = content.Replace(" ", " "); //replace similar to a space with a ascii space
            content = content.TrimEnd(new char[] { ' ', '\r', '\n' });
            return content;
        }

        private void UpdateSlideNotes(Slide slide, string message, bool append)
        {
            if (append)
                slide.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text += message;
            else
                slide.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text = message;
        }
    }
}
