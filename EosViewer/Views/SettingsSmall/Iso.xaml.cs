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
	/// Interaction logic for Iso.xaml
	/// </summary>
	public partial class Iso : UserControl
	{
		public Iso()
		{
			InitializeComponent();
		}

		public IsoSpeed IsoSpeed
		{
			get { return (IsoSpeed)GetValue(IsoSpeedProperty); }
			set { SetValue(IsoSpeedProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsoSpeed.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsoSpeedProperty =
			DependencyProperty.Register("IsoSpeed", typeof(IsoSpeed), typeof(Iso), new PropertyMetadata(IsoSpeed.Invalid));

	}
}
