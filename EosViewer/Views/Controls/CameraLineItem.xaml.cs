using System;
using System.Collections.Generic;
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
using EDSdkWrapper.Session;

namespace EosViewer.Views.Controls
{
	/// <summary>
	/// Interaction logic for CameraLineItem.xaml
	/// </summary>
	public partial class CameraLineItem : UserControl
	{
		public delegate void ConnectHandler(ConnectedCamera Camera);
		public event ConnectHandler ConnectRequest;

		public CameraLineItem()
		{
			InitializeComponent();
		}

		public ConnectedCamera Camera
		{
			get { return (ConnectedCamera)GetValue(CameraProperty); }
			set { SetValue(CameraProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Camera.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CameraProperty =
			DependencyProperty.Register("Camera", typeof(ConnectedCamera), typeof(CameraLineItem), new PropertyMetadata(null));

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ConnectRequest?.Invoke(Camera);
		}
	}
}
