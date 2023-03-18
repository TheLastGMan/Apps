using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PixelMapper.Core;

namespace PixelMapper.Profile.RpgDmd.OutputFormat
{
	public class DMDBytePackedStream : IOutputFormat
	{
		private readonly byte _VColors = 3;

		public string ExportDescription
		{
			get { return ""; }
		}

		public string ExportExtension
		{
			get { return "vid"; }
		}

		public string SettingFileName
		{
			get { return "DMDBytePackedStream.xml"; }
		}

		public OutputPlugin BaseInfo
		{
			get
			{
				return new OutputPlugin()
				{
					Name = "DMD Byte Packed Stream",
					Description = "DMD 1 Color 4 Shades (1 byte is 4 pixels 0b11223344)",
					Version = "1.0",
					CreatedBy = "RPGCor | Ryan Gau | 2015"
				};
			}
		}

		private static Gamma _Gamma = new Gamma();
		public void CreateOutput(IConversionFormat ConversionProfile, string OutputImageFile, List<string> InputImageFiles, GammaInfo Gamma)
		{
			try
			{
				_Gamma.GammaInfo = Gamma;
				_Gamma.CachedGammaMap(_VColors); //pre-cache values
				InputImageFiles = InputImageFiles.Where(f => System.IO.File.Exists(f)).ToList();

				List<byte[]> animation = InputImageFiles.AsParallel().AsOrdered().Select(f => ConvertFile(ConversionProfile, f)).ToList();
				using (var sw = new System.IO.StreamWriter(OutputImageFile))
				{
					foreach(var content in animation)
					{
						char[] buffer = content.Select(f => Convert.ToChar(f)).ToArray();
						sw.Write(buffer);
					}
				}

				ErrorHandler.RaiseMessageEvent("Frames Exported");
			}
			catch (Exception ex)
			{
				ErrorHandler.RaiseMessageEvent("Frame Export Error: " + ex.Message);
			}
		}

		internal byte[] ConvertFile(IConversionFormat Profile, string ImageFile)
		{
			var lst = new List<byte>();
			var img = new Bitmap(Profile.Preview(ImageFile));
			for (int y = 0; y < img.Height; y++)
			{
				byte packed = 0;
				for (int x = 0; x < img.Width; x ++)
				{
					//back 4 pixels into each byte (look at red channel)
					packed <<= 2;

					//pixel data
					var pixel = img.GetPixel(x, y);
					byte corrected = (byte)_Gamma.BrightnessGammaCorrected(pixel.R, _VColors);
					packed += corrected;

					//have we reached 4 pixels, then add to list
					if (x % 4 == 3)
						lst.Add(packed);
				}
			}
			return lst.ToArray();
		}
	}
}
