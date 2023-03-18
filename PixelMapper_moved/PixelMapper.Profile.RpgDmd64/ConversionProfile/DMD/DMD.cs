using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PixelMapper.Core;

namespace PixelMapper.Profile.RpgDmd.ConversionProfile.DMD
{
	public class DMD : IConversionFormat
	{
		private Gamma _Gamma = new Gamma();
		private readonly byte _VColors = 3;

		internal static DMDSettings _Settings { get; private set; }
		internal DMDSettings Settings
		{
			get
			{
				if (_Settings == null)
				{
					var defaults = new DMDSettings()
					{
						OutputWidth = 128,
						OutputHeight = 32,
						PluginInfo = new OutputPlugin()
						{
							Name = "DMD Classic",
							Description = "Classic 1 Color, 4 Shades DMD (Grayscale Images using Red channel)",
							Version = "1.0",
							CreatedBy = "RPGCor | Ryan Gau | 2015"
						},
						GammaInfo = new GammaInfo(),
						Color = new DMDColor()
						{
							R = 255,
							G = 165,
							B = 0
						}
					};

					//create and/or load current settings
					_Settings = new FolderAccess().LoadSettings(SettingFileName, defaults);
				}

				//set gamma data
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
			get { return "RPG-DMD.xml"; }
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
			//setup
			ErrorHandler.RaiseMessageEvent("");
			bool hasError = false;

			//run profile on image
			var colorCheck = new Action<Color>((c) =>
			{
				//load color data;
				byte[] pDat = {c.R, c.G, c.B};
				byte min = pDat.Min();
				byte max = pDat.Max();

				//check
				if (Math.Abs(max - min) > 5)
					hasError = true;
			});

			//create scaled down image
			Image scaled;
			using(var bitmap = new Bitmap(InputImageFile))
				scaled = bitmap.GetThumbnailImage(Settings.OutputWidth, Settings.OutputHeight, null, System.IntPtr.Zero);
			scaled = new Core.Service.ImageService().ConvertImage(scaled, colorCheck, Filter);

			//show output message and return converted image
			if(hasError)
				ErrorHandler.RaiseMessageEvent("Image is not pure Grayscale (R = G = B), Using weighted color average");

			return scaled;
		}

		internal Color Filter(Color Input)
		{
			//convert to weighted grayscale
			byte gs = GrayScaleWeightedAverage(Input.R, Input.G, Input.B);

			//calculate normal colors based on ratio of R channel
			byte raw = _Gamma.AssociatedColor(gs, _VColors);
			byte r = PixelRatioValue(Settings.Color.R, raw);
			byte g = PixelRatioValue(Settings.Color.G, raw);
			byte b = PixelRatioValue(Settings.Color.B, raw);

			//create converted color
			var color = Color.FromArgb(r, g, b);
			return color;
		}

		internal byte GrayScaleWeightedAverage(byte R, byte G, byte B)
		{
			decimal r = R * 0.2989M;
			decimal g = G * 0.5879M;
			decimal b = B * 0.1140M;
			byte gs = (byte)Math.Round(r + g + b, 0);
			return gs;
		}

		internal byte PixelRatioValue(byte Value, byte RatioValue)
		{
			decimal ratio = (decimal)RatioValue * (Value / 255.0M);
			ratio = Math.Round(ratio, 0);
			return (byte)ratio;
		}

		public System.Windows.Controls.UserControl CustomControl
		{
			get { return new DMDSettingEditor(); }
		}
	}
}
