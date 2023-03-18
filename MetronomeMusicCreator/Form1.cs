using MetronomeMusicCreator.MusicStream;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetronomeMusicCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (byte i = 1; i <= 6; i++)
            {
                Song song = new MusicInfoStream().ReadFromFile(new FileInfo("C:/Users/rgau1/Desktop/Song" + i.ToString() + @".csv"));
                song.Number = i;
                new TemplateInfoStream().WriteSong(song, new FileInfo("C:/Users/rgau1/Desktop/Song" + i.ToString() + @".h"));
            }
        }
    }
}
