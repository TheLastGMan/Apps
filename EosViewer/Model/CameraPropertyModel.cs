using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Session;
using EDSdkWrapper.Session.Properties;
using EosViewer.AppCode;

namespace EosViewer.Model
{
	public class CameraPropertyModel : CameraProperty, INotifyPropertyChanged, IRefresh
	{
		public CameraPropertyModel(CameraSession Session) : base(Session)
		{ }

		public event PropertyChangedEventHandler PropertyChanged;
		internal void Notify(string Name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
		}

		public void NotifyProperty(Property Property)
		{
			string prop = Property.ToString().Replace("_", "");
			Notify(prop);
		}

		public void Refresh()
		{
			foreach (var p in this.GetType().GetProperties())
				Notify(p.Name);
		}
	}
}
