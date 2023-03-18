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

namespace PixelMapper.Profile.RpgDmd.ConversionProfile.DMD
{
	/// <summary>
	/// Interaction logic for DMDSettingEditor.xaml
	/// </summary>
	public partial class DMDSettingEditor : UserControl, INotifyPropertyChanged
	{
		private DMD BaseControl = new DMD();

		public DMDSettingEditor()
		{
			InitializeComponent();
			BrightnessValue = BaseControl.Settings.GammaInfo.Brightness * 100;
			ContrastValue = BaseControl.Settings.GammaInfo.Contrast * 10;
			RValue = BaseControl.Settings.Color.R;
			GValue = BaseControl.Settings.Color.G;
			BValue = BaseControl.Settings.Color.B;
		}

		~DMDSettingEditor()
		{
			UpdateSettings();
			BaseControl.Settings = BaseControl.Settings; //force a save
		}

		internal void UpdateSettings()
		{
			//update display settings
			BaseControl.Settings.GammaInfo.Brightness = BrightnessValue / 100;
			BaseControl.Settings.GammaInfo.Contrast = ContrastValue / 10;
			BaseControl.Settings.Color.R = RValue;
			BaseControl.Settings.Color.G = GValue;
			BaseControl.Settings.Color.B = BValue;

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

		public Brush RColor
		{
			get { return new SolidColorBrush(Color.FromArgb(255, RValue, 0, 0)); }
		}

		private byte _RValue = 0;
		public byte RValue
		{
			get { return _RValue; }
			set
			{
				_RValue = value;
				Notify("RValue");
				Notify("RColor");
				Notify("FColor");
			}
		}

		public Brush GColor
		{
			get { return new SolidColorBrush(Color.FromArgb(255, 0, GValue, 0)); }
		}

		private byte _GValue = 0;
		public byte GValue
		{
			get { return _GValue; }
			set
			{
				_GValue = value;
				Notify("GValue");
				Notify("GColor");
				Notify("FColor");
			}
		}

		public Brush BColor
		{
			get { return new SolidColorBrush(Color.FromArgb(255, 0, 0, BValue)); }
		}

		private byte _BValue = 0;
		public byte BValue
		{
			get { return _BValue; }
			set
			{
				_BValue = value;
				Notify("BValue");
				Notify("BColor");
				Notify("FColor");
			}
		}

		public Brush FColor
		{
			get { return new SolidColorBrush(Color.FromArgb(255, RValue, GValue, BValue)); }
		}
	}
}
