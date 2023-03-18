namespace PixelMapper
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BrowseDirectory = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputFileLocation = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.ValidImages = new System.Windows.Forms.ListBox();
			this.SourceImage = new System.Windows.Forms.PictureBox();
			this.OutputImage = new System.Windows.Forms.PictureBox();
			this.ColorProfiles = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.MaxFrames = new System.Windows.Forms.Label();
			this.ExportFrames = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.SourceImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OutputImage)).BeginInit();
			this.SuspendLayout();
			// 
			// BrowseDirectory
			// 
			this.BrowseDirectory.BackColor = System.Drawing.Color.White;
			this.BrowseDirectory.Location = new System.Drawing.Point(96, 11);
			this.BrowseDirectory.Name = "BrowseDirectory";
			this.BrowseDirectory.ReadOnly = true;
			this.BrowseDirectory.Size = new System.Drawing.Size(574, 20);
			this.BrowseDirectory.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Source Folder :";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(676, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "&Browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(676, 498);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Brow&se";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 503);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Output File :";
			// 
			// OutputFileLocation
			// 
			this.OutputFileLocation.BackColor = System.Drawing.Color.White;
			this.OutputFileLocation.Location = new System.Drawing.Point(81, 500);
			this.OutputFileLocation.Name = "OutputFileLocation";
			this.OutputFileLocation.ReadOnly = true;
			this.OutputFileLocation.Size = new System.Drawing.Size(589, 20);
			this.OutputFileLocation.TabIndex = 3;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "IMG Files|*.img";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Output Format :";
			// 
			// ValidImages
			// 
			this.ValidImages.FormattingEnabled = true;
			this.ValidImages.Location = new System.Drawing.Point(14, 74);
			this.ValidImages.Name = "ValidImages";
			this.ValidImages.Size = new System.Drawing.Size(155, 407);
			this.ValidImages.TabIndex = 7;
			this.ValidImages.SelectedIndexChanged += new System.EventHandler(this.ValidImages_SelectedIndexChanged);
			// 
			// SourceImage
			// 
			this.SourceImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SourceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SourceImage.Location = new System.Drawing.Point(180, 111);
			this.SourceImage.Name = "SourceImage";
			this.SourceImage.Size = new System.Drawing.Size(592, 148);
			this.SourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.SourceImage.TabIndex = 8;
			this.SourceImage.TabStop = false;
			// 
			// OutputImage
			// 
			this.OutputImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.OutputImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.OutputImage.Location = new System.Drawing.Point(180, 300);
			this.OutputImage.Name = "OutputImage";
			this.OutputImage.Size = new System.Drawing.Size(592, 148);
			this.OutputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.OutputImage.TabIndex = 9;
			this.OutputImage.TabStop = false;
			// 
			// ColorProfiles
			// 
			this.ColorProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ColorProfiles.FormattingEnabled = true;
			this.ColorProfiles.Location = new System.Drawing.Point(96, 42);
			this.ColorProfiles.Name = "ColorProfiles";
			this.ColorProfiles.Size = new System.Drawing.Size(170, 21);
			this.ColorProfiles.Sorted = true;
			this.ColorProfiles.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(302, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Maximum Frames :";
			// 
			// MaxFrames
			// 
			this.MaxFrames.Location = new System.Drawing.Point(402, 45);
			this.MaxFrames.Name = "MaxFrames";
			this.MaxFrames.Size = new System.Drawing.Size(80, 13);
			this.MaxFrames.TabIndex = 12;
			this.MaxFrames.Text = "[MF]";
			// 
			// ExportFrames
			// 
			this.ExportFrames.Location = new System.Drawing.Point(386, 527);
			this.ExportFrames.Name = "ExportFrames";
			this.ExportFrames.Size = new System.Drawing.Size(96, 23);
			this.ExportFrames.TabIndex = 13;
			this.ExportFrames.Text = "E&xport";
			this.ExportFrames.UseVisualStyleBackColor = true;
			this.ExportFrames.Click += new System.EventHandler(this.ExportFrames_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.ExportFrames);
			this.Controls.Add(this.MaxFrames);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ColorProfiles);
			this.Controls.Add(this.OutputImage);
			this.Controls.Add(this.SourceImage);
			this.Controls.Add(this.ValidImages);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OutputFileLocation);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BrowseDirectory);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.SourceImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OutputImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox BrowseDirectory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox OutputFileLocation;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox ValidImages;
		private System.Windows.Forms.PictureBox SourceImage;
		private System.Windows.Forms.PictureBox OutputImage;
		private System.Windows.Forms.ComboBox ColorProfiles;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label MaxFrames;
		private System.Windows.Forms.Button ExportFrames;
	}
}

