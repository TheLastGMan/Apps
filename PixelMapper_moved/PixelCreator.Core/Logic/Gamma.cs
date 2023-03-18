using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public class Gamma
	{
		public Gamma()
		{
			GammaInfo = new GammaInfo();
		}

		GammaInfo _GammaInfo;
		public GammaInfo GammaInfo
		{
			get { return _GammaInfo; }
			set
			{
				_GammaInfo = value;
				
				//validate lower bounds
				_GammaInfo.Brightness = Math.Max(_GammaInfo.Brightness, 0);
				_GammaInfo.Contrast = Math.Max(_GammaInfo.Contrast, 0);

				ClearGammaCache();
			}
		}

		public void EnforceDecodeGammaValues(bool Enabled = false)
		{
			if (Enabled)
				GammaInfo.Contrast = Math.Max(GammaInfo.Contrast, 1.0M);
		}

		/// <summary>
		/// Finds the associated brightness/gamma corrected color for the (0-255 input) and number of valid colors per pixel color
		/// </summary>
		/// <param name="InputColor">0-255 standard color value</param>
		/// <param name="ValidColors">number of selections per pixel color</param>
		/// <returns>Associated standard pixel color</returns>
		public byte AssociatedColor(byte InputColor, ushort ValidColors)
		{
			//load mapped value
			var map = CachedGammaMap(ValidColors);
			ushort mapped = map[InputColor];

			//correct for brightness (implied round down)
			mapped = (ushort)(GammaInfo.Brightness * mapped);
			mapped = Math.Min(mapped, ValidColors);

			//check for zero value
			if (mapped == 0)
				return 0;

			//find highest associated color
			byte gammacolor = map.Where(f => f.Value == mapped).Max(f => f.Key);
			return gammacolor;
		}

		/// <summary>
		/// Returns gamma/brightness correct pixel color
		/// </summary>
		/// <param name="InputColor">0-255 standard color value</param>
		/// <param name="ValidColors">number of selections per pixel color</param>
		/// <returns>number in the range</returns>
		public ushort BrightnessGammaCorrected(byte InputColor, ushort ValidColors)
		{
			ushort mapped = CachedGammaMap(ValidColors)[InputColor];
			mapped = (ushort)(GammaInfo.Brightness * mapped);
			mapped = Math.Min(mapped, ValidColors);
			return mapped;
		}

		private static ConcurrentDictionary<ushort, Dictionary<byte, ushort>> _cacheGammaMap = new ConcurrentDictionary<ushort,Dictionary<byte,ushort>>();
		//private static Dictionary<ushort, Dictionary<byte, ushort>> _cacheGammaMap = new Dictionary<ushort, Dictionary<byte, ushort>>();
		/// <summary>
		/// Gamma Cache based on the number on number valid colors per pixel color
		/// </summary>
		/// <param name="ValidColors">number of valid colors</param>
		/// <returns>Map of gamma corrected values</returns>
		public Dictionary<byte, ushort> CachedGammaMap(ushort ValidColors)
		{
			var result = _cacheGammaMap.GetOrAdd(ValidColors, GammaMap(ValidColors));
			return result;
		}

		/// <summary>
		/// Clears the gamma cache
		/// </summary>
		public void ClearGammaCache()
		{
			_cacheGammaMap.Clear();
		}

		/// <summary>
		/// Generate the Gamma map for the number of useable colors per pixel color
		/// </summary>
		/// <param name="ValidColors">number of selections per pixel color</param>
		/// <returns>Gamma Map (0-255, gamma corrected)</returns>
		public Dictionary<byte, ushort> GammaMap(ushort ValidColors)
		{
			var output = new Dictionary<byte, ushort>();

			//calculate gamma correction for standard pixel color value (0-255)
			for (byte i = 0; i < 255; i++)
				output.Add(i, GammaCorrection(i, ValidColors));
			output.Add(255, GammaCorrection(255, ValidColors));

			return output;
		}

		/// <summary>
		/// Gamma corrected value for a linear intensity display
		/// </summary>
		/// <param name="InputColor">0-255 standard color value</param>
		/// <param name="ValidColors">number of selections per pixel color</param>
		/// <returns>Gamma corrected pixel value</returns>
		public ushort GammaCorrection(byte InputColor, ushort ValidColors)
		{
			//convert to a linear percentage
			decimal linearReference = (decimal)InputColor / 255.0M;

			//compute gamma ratio
			decimal gammaReference = 1.0M / GammaInfo.Contrast;

			//calculate gamma for color
			double power = Math.Pow((double)linearReference, (double)gammaReference);

			//map to linear value based on the number of valid colors
			ushort corrected = (ushort)Math.Round(ValidColors * (decimal)power);

			//return gamma corrected value
			return corrected;
		}
	}
}
