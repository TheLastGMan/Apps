using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PixelMapper.Core;

namespace PixelMapper.Profile.RpgDmd.ConversionProfile.DMD64
{
	public class DMD64 : IConversionFormat
	{
		private Gamma _Gamma = new Gamma();
		private readonly byte _RColors = 3;
		private readonly byte _GColors = 3;
		private readonly byte _BColors = 3;

		internal static DMD64Settings _Settings { get; private set; }
		internal DMD64Settings Settings
		{
			get
			{ 
				if(_Settings == null)
				{
					var defaults = new DMD64Settings()
					{
						OutputWidth = 128,
						OutputHeight = 32,
						PluginInfo = new OutputPlugin()
						{
							Name = "DMD64",
							Description = "64 Color DMD",
							Version = "1.0",
							CreatedBy = "RPGCor | Ryan Gau | 2015"
						},
						GammaInfo = new GammaInfo()
					};

					//create and/or load current settings
					_Settings = new FolderAccess().LoadSettings(SettingFileName, defaults);
				}
				_Gamma.GammaInfo = _Settings.GammaInfo;
				_Gamma.EnforceDecodeGammaValues(true);
				return _Settings;
			}
			set
			{
				_Settings = value;
				new FolderAccess().SaveSettings(SettingFileName, _Settings);
				_Gamma.GammaInfo = _Settings.GammaInfo; //clear cache
			}
		}

		public string SettingFileName
		{
			get { return "RPG-DMD64.xml";  }
		}
		public System.Windows.Controls.UserControl CustomControl
		{
			get { return new DMD64SettingEditor(); }
		}

		public OutputPlugin BaseInfo
		{
			get { return Settings.PluginInfo; }
		}

		public GammaInfo GammaInfo
		{
			get { return Settings.GammaInfo; }
		}

		public Image Preview(string InputImageFile)
		{
			//create scaled down image
			Image scaled;
			using(var bitmap = new Bitmap(InputImageFile))
			{
				var imageAttributes = new System.Drawing.Imaging.ImageAttributes();
				imageAttributes.SetOutputChannelColorProfile(@"C:\Windows\System32\spool\drivers\color\blackWhite.icc");

				var g = Graphics.FromImage(bitmap);
				g.DrawImage(
				   bitmap,
				   new Rectangle(0, 0, Settings.OutputWidth, Settings.OutputHeight),  // destination rectangle 
				   0, 0,        // upper-left corner of source rectangle 
				   Settings.OutputWidth,       // width of source rectangle
				   Settings.OutputHeight,      // height of source rectangle
				   GraphicsUnit.Pixel,
				   imageAttributes);

				scaled = bitmap.GetThumbnailImage(Settings.OutputWidth, Settings.OutputHeight, null, System.IntPtr.Zero);
			}
			

			//run filter
			scaled = new Core.Service.ImageService().ConvertImage(scaled, (c) => { }, Filter);
			return scaled;
		}

		internal Color Filter(Color Pixel)
		{
			//convert color channels
			byte r = _Gamma.AssociatedColor(Pixel.R, _RColors);
			byte g = _Gamma.AssociatedColor(Pixel.G, _GColors);
			byte b = _Gamma.AssociatedColor(Pixel.B, _BColors);
			
			//return converted pixel color
			var color = Color.FromArgb(r, g, b);
			return color;
		}
	}
}
