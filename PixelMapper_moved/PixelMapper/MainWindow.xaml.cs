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

namespace PixelMapper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public MainWindow()
		{
			InitializeComponent();

			//tie in message events
			PixelMapper.Core.ErrorHandler.MessageEvent += ErrorHandler_MessageEvent;
		}

		~MainWindow()
		{
			PixelMapper.Core.ErrorHandler.MessageEvent -= ErrorHandler_MessageEvent;
		}

		void ErrorHandler_MessageEvent(string Message)
		{
			this.Message = Message;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		string _Message = " ";
		public string Message
		{
			get { return _Message; }
			set
			{
				_Message = value;
				Notify("Message");
			}
		}

		void SourceFolderControl_FolderChanged(string FolderPath)
		{
			//load images from folder
			var images = new PixelMapper.Core.FolderAccess().Images(FolderPath);

			//pass off to image viewer
			ImageViewerControl.LoadedImages = images;
			ImageViewerControl.ImageFormat = ConversionProfileControl.SelectedProfile;
			ExportControl.OutputFormat = ConversionProfileControl.OutputSelectedProfile;

			//update export
			ExportControl.LoadedFiles = images.Select(f => f.Value).ToList();
			Message = "Images loaded";
		}

		void ConversionProfileControl_ConversionFormatChanged(IConversionFormat Format)
		{
			ImageViewerControl.ImageFormat = Format;
		}

		void ConversionProfileControl_OutputFormatChanged(IOutputFormat Format)
		{
			ExportControl.OutputFormat = Format;
		}

		private void ExportControl_GenerateExport(string ExportFullFileName)
		{
			if(ConversionProfileControl.OutputSelectedProfile == null)
			{
				Message = "No output profile selected";
				return;
			}

			Message = "Exporting Frames";
			new System.Threading.Tasks.Task(() =>
			{
				var validFiles = ExportControl.LoadedFiles.Where(f => System.IO.File.Exists(f)).ToList();
				ConversionProfileControl.OutputSelectedProfile.CreateOutput(ConversionProfileControl.SelectedProfile, ExportFullFileName, validFiles, ConversionProfileControl.SelectedProfile.GammaInfo);
				Message = "Frames Exported";
			}).Start();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			new System.Threading.Tasks.Task(() =>
			{
				ExportControl.OutputFormat = ConversionProfileControl.OutputSelectedProfile;
				ImageViewerControl.ImageFormat = ConversionProfileControl.SelectedProfile;
			}).Start();
		}
	}
}
