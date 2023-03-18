using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDSdkWrapper.Session;
using EosViewer.AppCode;

namespace EosViewer.Model
{
	public class CameraModel : INotifyPropertyChanged, IRefresh
	{
		public CameraModel(CameraSession Session)
		{
			this.Session = Session;
			Settings = new CameraPropertyModel(this.Session);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
		}

		private CameraSession _Session;
		public CameraSession Session
		{
			get { return _Session; }
			private set
			{
				_Session = value;
				Notify("Session");
			}
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

		public void Refresh()
		{
			Notify("Session");
			Notify("Settings");
			Notify("Options");
		}
	}
}
