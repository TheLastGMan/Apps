using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
    public interface IConversionFormat
    {
		string SettingFileName { get; }

		OutputPlugin BaseInfo { get; }

		Image Preview(string InputImageFile);

		GammaInfo GammaInfo { get; }

		System.Windows.Controls.UserControl CustomControl { get; }
    }
}
