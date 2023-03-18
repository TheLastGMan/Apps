using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetronomeMusicCreator.MusicStream
{
    class TemplateInfoStream
    {
        public void WriteSong(Song song, FileInfo outputFile)
        {
            //validate
            if (song == null)
                throw new ArgumentNullException("song");
            if (outputFile == null)
                throw new ArgumentNullException("outputFile");

            //load template file
            if (!File.Exists(@"./SongTemplate.txt"))
                throw new Exception("Missing song template file");

            //parse file
            try
            {
                string template = File.ReadAllText(@"SongTemplate.txt");
                string notes = String.Join(", ", song.Notes.Select(f => Enum.GetName(typeof(Key), f.Key)));
                string ntypes = String.Join(", ", song.Notes.Select(f => Enum.GetName(typeof(NoteType), f.Type)));

                //update file
                string songContent = template.Replace("{0}", song.Number.ToString());
                songContent = songContent.Replace("{1}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                songContent = songContent.Replace("{2}", song.Info.SongName);
                songContent = songContent.Replace("{3}", song.Info.BeatsPerMinute.ToString());
                songContent = songContent.Replace("{4}", song.Notes.Count.ToString());
                songContent = songContent.Replace("{5}", notes);
                songContent = songContent.Replace("{6}", ntypes);

                //write
                File.WriteAllText(outputFile.FullName, songContent, Encoding.ASCII);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            
        }
    }
}
