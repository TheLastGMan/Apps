using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetronomeMusicCreator.MusicStream
{
    class Song
    {
        public Song()
        {
            Info = new HeaderData();
            Notes = new List<NoteInfo>();
        }

        public HeaderData Info { get; set; }
        public List<NoteInfo> Notes { get; set; }
        public byte Number { get; set; }
    }
}
