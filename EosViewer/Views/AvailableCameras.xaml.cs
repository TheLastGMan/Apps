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
using EDSdkWrapper.Session;

namespace EosViewer.Views
{
	/// <summary>
	/// Interaction logic for AvailableCameras.xaml
	/// </summary>
	public partial class AvailableCameras : UserControl, INotifyPropertyChanged
	{
		public delegate void ConnectToCameraHandler(ConnectedCamera Camera);
		public event ConnectToCameraHandler ConnectToCamera;

		public AvailableCameras()
		{
			InitializeComponent();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
		}

		private IList<ConnectedCamera> _Cameras;
		public IList<ConnectedCamera> Cameras
		{
			get { return _Cameras; }
			set
			{
				_Cameras = value;
				Notify("Cameras");
			}
		}

		private void CameraLineItem_ConnectRequest(ConnectedCamera Camera)
		{
			ConnectToCamera?.Invoke(Camera);
		}
	}
}
