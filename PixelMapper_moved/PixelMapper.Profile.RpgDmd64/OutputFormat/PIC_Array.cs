using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PixelMapper.Core;

namespace PixelMapper.Profile.RpgDmd.OutputFormat
{
	public class PIC_Array : IOutputFormat
	{
		private Gamma _Gamma = new Gamma();
		private readonly byte _RColors = 3;
		private readonly byte _GColors = 3;
		private readonly byte _BColors = 3;

		public string ExportDescription { get; private set; }
		public string ExportExtension { get; private set; }

		public string SettingFileName
		{
			get { return "Matrix-64.xml"; }
		}

		private static OutputPlugin _BaseInfo;
		public OutputPlugin BaseInfo
		{
			get
			{
				if (_BaseInfo == null)
				{
					//extension info
					ExportExtension = "mat";
					ExportDescription = "";

					//plugin info
					_BaseInfo = new OutputPlugin()
					{
						Name = "Matrix-64",
						Description = "64 Color Matrix (1 byte contains 2 bits each of R,G,B (0-3) as 0b00BBGGRR)",
						Version = "1.0",
						CreatedBy = "RPGCor | Ryan Gau | 2015"
					};
				}

				return _BaseInfo;
			}
		}

		public void CreateOutput(IConversionFormat ConversionProfile, string OutputImageFile, List<string> InputImageFiles, GammaInfo Gamma)
		{
			if (InputImageFiles == null)
				throw new ArgumentNullException("InputImageFiles");
			if (String.IsNullOrEmpty(OutputImageFile))
				throw new ArgumentNullException("OutputImageFile");

			try
			{
				//convert
				_Gamma.GammaInfo = Gamma;
				var converted = InputImageFiles.AsParallel().AsOrdered().Select(f => FrameFormat(ImageFormat(ConversionProfile.Preview(f)))).ToList();
				string file = "{\r\n" + String.Join("\r\n}\r\n,\r\n{\r\n", converted) + "\r\n}";

				//save file
				using (var sw = new System.IO.StreamWriter(OutputImageFile, false))
					sw.Write(file);

				ErrorHandler.RaiseMessageEvent("Frames Exported");
			}
			catch (Exception ex)
			{
				ErrorHandler.RaiseMessageEvent("Frame Save Error: " + ex.Message);
			}
		}

		List<List<string>> ImageFormat(Image img)
		{
			var rows = new List<List<string>>();
			var bm = new Bitmap(img);
			for (int y = 0; y < img.Height; y++)
			{
				var columns = new List<string>();
				for (int x = 0; x < img.Width; x++)
				{
					var pixel = bm.GetPixel(x, y);
					byte data = (byte)_Gamma.GammaCorrection(pixel.B, _RColors);
					data += (byte)((byte)_Gamma.GammaCorrection(pixel.G, _GColors) * 4);
					data += (byte)((byte)_Gamma.GammaCorrection(pixel.R, _BColors) * 16);
					string cell = "0x" + data.ToString("X").PadLeft(2, '0');
					columns.Add(cell);
				}
				rows.Add(columns);
			}
			return rows;
		}

		string FrameFormat(List<List<string>> Frame)
		{
			string output = String.Join(",\r\n", Frame.Select(cols => "{" + String.Join(",", cols) + "}"));
			return output;
		}
	}
}
