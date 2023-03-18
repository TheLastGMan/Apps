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
using EDSdkWrapper.Enums;
using EDSdkWrapper.Session.Properties;

namespace EosViewer.Views.SettingsSmall
{
	/// <summary>
	/// Interaction logic for Mode.xaml
	/// </summary>
	public partial class Mode : UserControl
	{
		public Mode()
		{
			InitializeComponent();
		}

		public AEMode AEMode
		{
			get { return (AEMode)GetValue(AEModeProperty); }
			set { SetValue(AEModeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for AEMode.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AEModeProperty =
			DependencyProperty.Register("AEMode", typeof(AEMode), typeof(Mode), new PropertyMetadata(AEMode.Invalid));

	}
}
