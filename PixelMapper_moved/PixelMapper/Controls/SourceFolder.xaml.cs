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

namespace PixelMapper.Controls
{
	public delegate void SourceFolderChangedEventHandler(string Folder);

	/// <summary>
	/// Interaction logic for SourceFolder.xaml
	/// </summary>
	public partial class SourceFolder : UserControl, INotifyPropertyChanged
	{
		public SourceFolder()
		{
			InitializeComponent();
		}

		public event SourceFolderChangedEventHandler FolderChanged;
		void RaiseFolderChanged(string FolderPath)
		{
			if (FolderChanged != null)
				FolderChanged(SelectedFolder);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		string _SelectedFolder;
		public string SelectedFolder
		{
			get { return _SelectedFolder; }
			set 
			{
				_SelectedFolder = value;
				Notify("SelectedFolder");
			}
		}

		/// <summary>
		/// Browse button pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BrowseBtn_Click(object sender, RoutedEventArgs e)
		{
			//set up dialog
			var browser = new System.Windows.Forms.FolderBrowserDialog();
			browser.ShowNewFolderButton = false;
			browser.Description = "Source Folder";

			//show dialog
			if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				SelectedFolder = browser.SelectedPath;

			browser.Dispose();
		}

		/// <summary>
		/// Text changed for folder path
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FolderPath_TextChanged(object sender, TextChangedEventArgs e)
		{
			//raise event that the folder is changed
			RaiseFolderChanged(SelectedFolder);
		}
	}
}
