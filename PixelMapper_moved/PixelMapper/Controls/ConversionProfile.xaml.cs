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
	public delegate void ConversionProfileChangedEventHandler(IConversionFormat Format);
	public delegate void ConversionOutputFormatChangedEventHandler(IOutputFormat Format);

	/// <summary>
	/// Interaction logic for ConversionProfile.xaml
	/// </summary>
	public partial class ConversionProfile : UserControl, INotifyPropertyChanged
	{
		public ConversionProfile()
		{
			InitializeComponent();

			//add search directory
			string searchDir = new PixelMapper.Core.FolderAccess().SettingDirectory();
			PixelMapper.Core.Locator.AddSearchDirectories(searchDir);

			//load profiles
			Profiles = PixelMapper.Core.Locator.LoadedProfiles;
			SelectedProfile = (Profiles.Any() ? Profiles.First() : null);

			//load output profiles
			OutputProfiles = PixelMapper.Core.Locator.LoadedOutputProfiles;
			OutputSelectedProfile = (OutputProfiles.Any() ? OutputProfiles.First() : null);
		}

		~ConversionProfile()
		{
			Settings.ConversionProfileIndex = SelectedIndex;
			Settings.OutputProfileIndex = OutputSelectedIndex;
			new FolderAccess().SaveSettings(Code.Settings.SettingFileName, Settings);
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			//load settings
			Settings = new FolderAccess().LoadSettings<Code.Settings>(Code.Settings.SettingFileName, new Code.Settings());
			SelectedIndex = Settings.ConversionProfileIndex;
			OutputSelectedIndex = Settings.OutputProfileIndex;
		}

		internal Code.Settings Settings { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		public event ConversionProfileChangedEventHandler ConversionFormatChanged;
		public event ConversionOutputFormatChangedEventHandler OutputFormatChanged;
		internal void RaiseConversionFormatChanged(IConversionFormat Format)
		{
			if (ConversionFormatChanged != null)
				ConversionFormatChanged(Format);
		}
		internal void RaiseOutputFormatChanged(IOutputFormat Format)
		{
			if (OutputFormatChanged != null)
				OutputFormatChanged(Format);
		}

		#region Conversion Profile

		IConversionFormat _SelectedProfile;
		public IConversionFormat SelectedProfile
		{
			get { return _SelectedProfile; }
			set
			{
				_SelectedProfile = value;
				ErrorHandler.RaiseMessageEvent("");
				RaiseConversionFormatChanged(value);
				Notify("SelectedProfile");
			}
		}

		List<IConversionFormat> _Profiles = new List<IConversionFormat>();
		public List<IConversionFormat> Profiles
		{
			get { return _Profiles; }
			set
			{
				_Profiles = value;
				Notify("Profiles");
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

		#endregion

		#region Output Profile

		IOutputFormat _OutputSelectedProfile;
		public IOutputFormat OutputSelectedProfile
		{
			get { return _OutputSelectedProfile; }
			set
			{
				_OutputSelectedProfile = value;
				RaiseOutputFormatChanged(value);
				Notify("OutputSelectedProfile");
			}
		}

		List<IOutputFormat> _OutputProfiles = new List<IOutputFormat>();
		public List<IOutputFormat> OutputProfiles
		{
			get { return _OutputProfiles; }
			set
			{
				_OutputProfiles = value;
				Notify("OutputProfiles");
			}
		}

		int _OutputSelectedIndex = -1;
		public int OutputSelectedIndex
		{
			get { return _OutputSelectedIndex; }
			set
			{
				_OutputSelectedIndex = value;
				Notify("OutputSelectedIndex");
			}
		}

		#endregion
	}
}
