using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PixelMapper.Core.Service
{
	public class ImageService
	{
		/// <summary>
		/// Convert the image using the applied filter
		/// </summary>
		/// <param name="Image">Image to convert</param>
		/// <param name="ColorCheck">Color logic</param>
		/// <param name="Filter">Filter profile</param>
		/// <returns>Converted image</returns>
		public Image ConvertImage(Image Image, Action<Color> ColorCheck, Func<Color, Color> Filter)
		{
			var data = ImageData(Image, ColorCheck);
			data = ConvertPixels(data, Filter);
			var output = UpdateImage(Image, data);
			return output;
		}

		/// <summary>
		/// Load image data out of image and run a color check
		/// </summary>
		/// <param name="Image">Image to load image data</param>
		/// <param name="ColorCheck">Color logic</param>
		/// <returns>Image Data</returns>
		public ImageInfo[] ImageData(Image Image, Action<Color> ColorCheck)
		{
			var output = new List<ImageInfo>(Image.Width * Image.Height);
			
			//load pixel data for image
			using(var bitMap = new Bitmap(Image))
				for (int x = 0; x < Image.Width; x++)
					for (int y = 0; y < Image.Height; y++)
					{
						var pixel = bitMap.GetPixel(x, y);
						//run custom color check and add color info
						ColorCheck(pixel);
						output.Add(new ImageInfo() { x = x, y = y, Color = pixel });
					}

			return output.ToArray();
		}

		/// <summary>
		/// Run Filter profile on the image data
		/// </summary>
		/// <param name="ImageData">Image Data</param>
		/// <param name="Filter">Filter Profile</param>
		/// <returns>Filtered image data</returns>
		public ImageInfo[] ConvertPixels(ImageInfo[] ImageData, Func<Color, Color> Filter)
		{
			var parsed = ImageData.AsParallel().Select(f =>
			{
				f.Color = Filter(f.Color);
				return f;
			}).ToArray();
			return parsed;
		}

		/// <summary>
		/// Update image using the provided image data
		/// </summary>
		/// <param name="Image">Image to update</param>
		/// <param name="ImageData">Data to apply</param>
		/// <returns>Updated image</returns>
		public Image UpdateImage(Image Image, ImageInfo[] ImageData)
		{
			var bitMap = new Bitmap(Image);
			foreach (var imgData in ImageData)
				bitMap.SetPixel(imgData.x, imgData.y, imgData.Color);
			return bitMap;
		}
	}
}
