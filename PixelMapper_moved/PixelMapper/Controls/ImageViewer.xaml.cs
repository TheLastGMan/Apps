using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PixelMapper.Core;

namespace PixelMapper.Controls
{
	/// <summary>
	/// Interaction logic for ImageViewer.xaml
	/// </summary>
	public partial class ImageViewer : UserControl, System.ComponentModel.INotifyPropertyChanged
	{
		public ImageViewer()
		{
			InitializeComponent();
			ErrorHandler.RedrawImageEvent += ErrorHandler_RedrawImageEvent;
		}

		~ImageViewer()
		{
			ErrorHandler.RedrawImageEvent -= ErrorHandler_RedrawImageEvent;
		}

		void ErrorHandler_RedrawImageEvent()
		{
			//use dispatcher to use the controls thread
			Dispatcher.BeginInvoke(new Action(() =>
			{
				if (ImageFormat != null)
					CreateBitmapImage();
			}), null);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		public string EnableCustomControlDivider
		{
			get
			{
				return (_ImageFormat != null && _ImageFormat.CustomControl != null) ? "Visible" : "Collapsed";
			}
		}

		IConversionFormat _ImageFormat;
		public IConversionFormat ImageFormat
		{
			get { return _ImageFormat; }
			set
			{
				_ImageFormat = value;
				Notify("ImageFormat");
				Notify("EnableCustomControlDivider");
				CreateBitmapImage();
			}
		}

		BitmapImage _PreviewImage;
		public BitmapImage PreviewImage
		{
			get { return _PreviewImage; }
			set
			{
				_PreviewImage = value;
				Notify("PreviewImage");
			}
		}

		KeyValuePair<string, string> _SelectedImage = new KeyValuePair<string, string>(String.Empty, String.Empty);
		public KeyValuePair<string, string> SelectedImage
		{
			get { return _SelectedImage; }
			set
			{
				_SelectedImage = value;
				Notify("SelectedImage");
			}
		}

		int _SelectedIndex = -1;
		public int SelectedIndex
		{
			get { return _SelectedIndex; }
			set
			{
				_SelectedIndex = value;
				Notify("SelectedIndex");
			}
		}

		public Dictionary<string, string> LoadedImages
		{
			get { return (Dictionary<string, string>)GetValue(LoadedImagesProperty); }
			set
			{
				SetValue(LoadedImagesProperty, value);
				Notify("LoadedImages");
				if (value.Any())
					SelectedImage = value.First();
			}
		}

		// Using a DependencyProperty as the backing store to allow model data to be passed in from any parents
		public static readonly DependencyProperty LoadedImagesProperty =
			DependencyProperty.Register("LoadedImages", typeof(Dictionary<string, string>), typeof(ImageViewer), new FrameworkPropertyMetadata(new Dictionary<string, string>()) { BindsTwoWayByDefault = true, Inherits = true });

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CreateBitmapImage();
		}

		internal void CreateBitmapImage()
		{
			//load preview
			if (ImageFormat == null)
				return;

			//remove image if it does not exist anymore
			if(!System.IO.File.Exists(SelectedImage.Value))
			{
				LoadedImages.Remove(SelectedImage.Key);
				
				//update selected index based on number of images left
				SelectedIndex--;
				if (SelectedIndex < 0 && LoadedImages.Any())
					SelectedIndex = 0;

				//exit if no images remaining
				if(SelectedIndex < 0)
					return;

				//set new selected image
				SelectedImage = LoadedImages.ElementAt(SelectedIndex);
			}

			//load and convert to wpf image
			var img = ImageFormat.Preview(SelectedImage.Value);
			PreviewImage = CreateFromGraphic(img);
		}

		internal BitmapImage CreateFromGraphic(System.Drawing.Image Image)
		{
			var output = new BitmapImage();
			using (var ms = new System.IO.MemoryStream())
			{
				Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				ms.Position = 0;
				output.BeginInit();
				output.StreamSource = ms;
				output.CacheOption = BitmapCacheOption.OnLoad;
				output.EndInit();
			}
			return output;
		}
	}
}
