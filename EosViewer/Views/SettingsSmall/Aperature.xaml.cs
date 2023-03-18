using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Session.Properties;

namespace EosViewer.Views.SettingsSmall
{
	/// <summary>
	/// Interaction logic for Aperature.xaml
	/// </summary>
	public partial class Aperature : UserControl
	{
		public Aperature()
		{
			InitializeComponent();
		}

		public AperatureSize AperatureSize
		{
			get { return (AperatureSize)GetValue(AperatureSizeProperty); }
			set { SetValue(AperatureSizeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for AperatureSize.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AperatureSizeProperty =
			DependencyProperty.Register("AperatureSize", typeof(AperatureSize), typeof(Aperature), new PropertyMetadata(AperatureSize.Invalid));

	}
}
