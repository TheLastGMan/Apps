using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public interface IOutputFormat
	{
		string ExportDescription { get; }

		string ExportExtension { get; }

		string SettingFileName { get; }

		OutputPlugin BaseInfo { get; }

		void CreateOutput(IConversionFormat ConversionProfile, string OutputImageFile, List<string> InputImageFiles, GammaInfo Gamma);
	}
}
