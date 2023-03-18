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
using EosViewer.Model;

namespace EosViewer.Views
{
	/// <summary>
	/// Interaction logic for ManualView.xaml
	/// </summary>
	public partial class ManualView : UserControl, INotifyPropertyChanged
	{
		public ManualView()
		{
			InitializeComponent();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void Notify(string Name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
		}

		private CameraPropertyModel _Settings;
		public CameraPropertyModel Settings
		{
			get { return _Settings; }
			set
			{
				_Settings = value;
				Notify("Settings");
			}
		}

		public CameraSession Session
		{
			get { return (CameraSession)GetValue(SessionProperty); }
			set
			{
				if (Session != null)
					Session.StateChanged -= Session_StateChanged;

				SetValue(SessionProperty, value);
				Notify("Session");
				Settings = new CameraPropertyModel(value);
				value.StateChanged += Session_StateChanged;
				value.PropertyChanged += Value_PropertyChanged;
			}
		}

		private void Session_StateChanged(EDSdkWrapper.Enums.StateEvent Event)
		{
			//prevent camera from shutting down, will lose control of it
			if (Event == EDSdkWrapper.Enums.StateEvent.WillSoonShutdown)
				EDSdkWrapper.EDSDK.SendCommand(Session, EDSdkWrapper.Enums.Camera.Command.ExtendShutdownTimer);
		}

		private void Value_PropertyChanged(EDSdkWrapper.Enums.PropertyEvent Event, EDSdkWrapper.Enums.Camera.Property Property)
		{
			Notify("Settings");
			Settings.NotifyProperty(Property);
			//Settings.Refresh();
		}

		// Using a DependencyProperty as the backing store for Session.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SessionProperty =
			DependencyProperty.Register("Session", typeof(CameraSession), typeof(ManualView), new PropertyMetadata(null));
	}
}
