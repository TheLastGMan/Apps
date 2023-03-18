using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using EosViewer.Model;

namespace EosViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private EDSdkWrapper.Terminal.TerminalService _Terminal = new EDSdkWrapper.Terminal.TerminalService();
		private EDSdkWrapper.Session.CameraSession _Session;
		private Timer _Timer;

		public MainWindow()
		{
			InitializeComponent();
			_Terminal.Connect();
			_Terminal.CameraAdded += _Terminal_CameraAdded;
			_Timer = new Timer(5000);
			_Timer.Elapsed += _Timer_Elapsed;
		}

		~MainWindow()
		{
			_Terminal.CameraAdded -= _Terminal_CameraAdded;
            _Terminal.Disconnect();
			_Timer.Elapsed -= _Timer_Elapsed;
		}

		private void _Terminal_CameraAdded()
		{
			CamerasList.Cameras = _Terminal.ConnectedCameras;
			//if (CamerasList.Cameras.Any())
			//	CamerasList_ConnectToCamera(CamerasList.Cameras[0]);
			_Timer.Stop();
			_Timer.Start();
		}

		private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			_Terminal_CameraAdded();
		}

		private void CamerasList_ConnectToCamera(ConnectedCamera Camera)
		{
			if (_Session != null)
			{
				_Session.StateChanged -= _Session_StateChanged;
				_Session.Close();
			}
			_Session = Camera.Connect();
			_Session.StateChanged += _Session_StateChanged;
			CameraSession.Session = _Session;

			//change visiblility state
			CameraSession.Visibility = Visibility.Visible;
			CamerasList.Visibility = Visibility.Collapsed;

			//stop timer, no use for it
			_Timer.Stop();
		}

		private void _Session_StateChanged(EDSdkWrapper.Enums.StateEvent Event)
		{
			if (Event == EDSdkWrapper.Enums.StateEvent.Shutdown)
			{
				_Session.StateChanged -= _Session_StateChanged;
				_Terminal_CameraAdded();
				CamerasList.Visibility = Visibility.Visible;
				CameraSession.Visibility = Visibility.Collapsed;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (_Terminal.ConnectedCameras.Any())
				_Terminal_CameraAdded();
		}
	}
}
