using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetronomeMusicCreator.MusicStream
{
    class MusicInfoStream
    {
        public Song ReadFromFile(FileInfo file)
        {
            var ret = new Song();
            using (var sr = new StreamReader(file.FullName))
            {
                //read header
                var header = new HeaderData();
                header.SongName = sr.ReadLine().Split(',')[0];
                header.BeatsPerMinute = byte.Parse(sr.ReadLine().Split(',')[1]);
                ret.Info = header;

                //read notes
                sr.ReadLine();
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var note = new NoteInfo();
                    note.Key = (Key)Enum.Parse(typeof(Key), data[0], true);
                    note.Type = (NoteType)Enum.Parse(typeof(NoteType), data[1], true);
                    ret.Notes.Add(note);
                }
            }
            return ret;
        }
    }
}
