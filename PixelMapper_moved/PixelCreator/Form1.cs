using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PixelMapper.Profile.RpgDmd.ConversionProfile.DMD64;
using PixelMapper.Profile.RpgDmd.OutputFormat;

namespace PixelMapper
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				//show folder
				string folder = folderBrowserDialog1.SelectedPath;
				BrowseDirectory.Text = folder;

				string[] imageFiles = { ".bmp", ".jpg", ".gif", ".png" };
				var files = System.IO.Directory.GetFiles(folder, "*.*").Where(f => imageFiles.Contains(new System.IO.FileInfo(f).Extension)).OrderBy(f => new System.IO.FileInfo(f).Name).ToArray();

				//add to drop down
				ValidImages.Items.Clear();
				ValidImages.Items.AddRange(files.Select(f => new System.IO.FileInfo(f).Name).ToArray());

				if (ValidImages.Items.Count > 0)
					ValidImages.SelectedIndex = 0;
			}
		}

		private void ValidImages_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			var item = (string)lb.SelectedItem;
			var path = System.IO.Path.Combine(folderBrowserDialog1.SelectedPath, item);
			SourceImage.ImageLocation = path;
			OutputImage.Image = new DMD64().Preview(path);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ColorProfiles.Items.Clear();
			ColorProfiles.Items.Add("Image Condensed");

			ColorProfiles.SelectedIndex = 0;
			MaxFrames.Text = "2";
			ExportFrames.Enabled = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				OutputFileLocation.Text = saveFileDialog1.FileName;
				ExportFrames.Enabled = true;
			}
			else
			{
				ExportFrames.Enabled = false;
			}
		}

		private void ExportFrames_Click(object sender, EventArgs e)
		{
			//create file content
			new PIC_Array().CreateOutput(new DMD64(), OutputFileLocation.Text + "/out.img", ValidImages.Items.Cast<string>()
				.Select(f => System.IO.Path.Combine(OutputFileLocation.Text, f)).ToList(), new Core.GammaInfo());

			//update existing items
			OutputFileLocation.Text = "";
			ExportFrames.Enabled = false;
		}
	}
}
