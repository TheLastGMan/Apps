using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public class GammaInfo
	{
		public const decimal Default_Brightness = 1.0M;
		public const decimal Default_Contrast = 2.2M;

		public GammaInfo()
		{
			this.Brightness = Default_Brightness;
			this.Contrast = Default_Contrast;
		}

		/// <summary>
		/// Gamma Information
		/// </summary>
		/// <param name="Brightness">Brightness as percentance / 100</param>
		/// <param name="Contrast">Contrast ratio as Gamma value</param>
		public GammaInfo(decimal Brightness = Default_Brightness, decimal Contrast = Default_Contrast)
		{
			this.Brightness = Brightness;
			this.Contrast = Contrast;
		}

		public decimal Brightness { get; set; }

		private decimal _Contrast = 0;
		public decimal Contrast
		{
			get { return _Contrast; }
			set
			{
				//validate contrast value (non zero positive number)
				if(value <= 0.0M)
					value = 0.0001M;
				_Contrast = value;
			}
		}
	}
}
