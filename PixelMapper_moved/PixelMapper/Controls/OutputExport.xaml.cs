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
	public delegate void GenerateExportEventHandler(string ExportFullFileName);

	/// <summary>
	/// Interaction logic for OutputExport.xaml
	/// </summary>
	public partial class OutputExport : UserControl, INotifyPropertyChanged
	{
		public OutputExport()
		{
			InitializeComponent();
			LoadedFiles = new List<string>();
		}

		public List<string> LoadedFiles { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		public event GenerateExportEventHandler GenerateExport;
		internal void RaiseGenerateExport(string ExportFullFileName)
		{
			if (GenerateExport != null)
				GenerateExport(ExportFullFileName);
		}

		IOutputFormat _OutputFormat;
		public IOutputFormat OutputFormat
		{
			get { return _OutputFormat; }
			set
			{
				_OutputFormat = value;
				Notify("OutputFormat");
			}
		}

		string _SelectedFile = String.Empty;
		public string SelectedFile
		{
			get { return _SelectedFile; }
			set
			{
				_SelectedFile = value;
				Notify("SelectedFile");
			}
		}

		private void BrowseBtn_Click(object sender, RoutedEventArgs e)
		{
			//create save dialog
			var browser = new System.Windows.Forms.SaveFileDialog()
			{
				AddExtension = true,
				CheckFileExists = false,
				CheckPathExists = true,
				Filter = "Other|*.*",
				SupportMultiDottedExtensions = false,
				Title = "Export Frames",
				ValidateNames = true
			};
#warning ToDo : look into default extensions being set on load
			if(OutputFormat != null)
			{
				browser.DefaultExt = "." + OutputFormat.ExportExtension;
				browser.Filter = String.Format("{0}|*.{1}|{2}", OutputFormat.BaseInfo.Name, OutputFormat.ExportExtension, browser.Filter);
			}

			//show dialog
			if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				SelectedFile = browser.FileName;

			//dispose of dialog
			browser.Dispose();
		}

		private void ExportBtn_Click(object sender, RoutedEventArgs e)
		{
			//run export
			if (!String.IsNullOrEmpty(SelectedFile))
				RaiseGenerateExport(SelectedFile);
			else
				ErrorHandler.RaiseMessageEvent("No output file selected");
		}
	}
}
