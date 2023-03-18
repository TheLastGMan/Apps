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

namespace PixelMapper.Profile.RpgDmd.ConversionProfile.DMD64
{
	/// <summary>
	/// Interaction logic for DMD64SettingEditor.xaml
	/// </summary>
	public partial class DMD64SettingEditor : UserControl, INotifyPropertyChanged
	{
		private DMD64 BaseControl = new DMD64();

		public DMD64SettingEditor()
		{
			InitializeComponent();
			BrightnessValue = BaseControl.Settings.GammaInfo.Brightness * 100;
			ContrastValue = BaseControl.Settings.GammaInfo.Contrast * 10;
		}

		~DMD64SettingEditor()
		{
			UpdateSettings();
			BaseControl.Settings = BaseControl.Settings; //force a save
		}

		private void UpdateSettings()
		{
			//update display settings
			BaseControl.Settings.GammaInfo.Brightness = BrightnessValue / 100;
			BaseControl.Settings.GammaInfo.Contrast = ContrastValue / 10;
			
			//raise redraw event
			PixelMapper.Core.ErrorHandler.RaiseRedrawImageEvent();
		}

		private void Slider_KeyUp(object sender, KeyEventArgs e)
		{
			UpdateSettings();
		}

		private void Slider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			UpdateSettings();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		void Notify(string Name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		private decimal _BrightnessValue;
		public decimal BrightnessValue
		{
			get { return _BrightnessValue; }
			set
			{
				_BrightnessValue = Math.Round(value);
				Notify("BrightnessValue");
				Notify("BrightnessValueDisplay");
			}
		}

		public string BrightnessValueDisplay
		{
			get { return (BrightnessValue / 100).ToString("P0"); }
		}

		private decimal _ContrastValue;
		public decimal ContrastValue
		{
			get { return _ContrastValue; }
			set
			{
				_ContrastValue = Math.Round(value);
				Notify("ContrastValue");
				Notify("ContrastValueDisplay");
			}
		}
		public string ContrastValueDisplay
		{
			get { return (ContrastValue / 10).ToString("F1"); }
		}
	}
}
