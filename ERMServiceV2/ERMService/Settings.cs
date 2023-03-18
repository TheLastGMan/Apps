using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ERMService
{
	class Settings
	{
		internal static string LoadSetting(string Name)
		{
			if (!ConfigurationManager.AppSettings.AllKeys.Contains(Name))
				return null;
			return ConfigurationManager.AppSettings[Name];
		}

		internal static string LoadConnectionString(string Name)
		{
			foreach (ConnectionStringSettings conn in ConfigurationManager.ConnectionStrings)
				if (conn.Name == Name)
					return conn.ConnectionString;
			return null;
		}

		public static string ERMReportingConnection
		{
			get { return LoadConnectionString("ERMReporting"); }
		}

		public static uint TimerDelaySeconds
		{
			get
			{
				//load
				string result = LoadSetting("TimerDelaySeconds");

				//parse
				uint value = 1;
				uint.TryParse(result, out value);

				//validate
				if (value < 1)
					value = 1;

				return value;
			}
		}

		internal static string DirectoryCheck(string SettingName)
		{
			//load
			string dir = LoadSetting(SettingName);

			//validate
			if (dir == null)
				return null;
			if (!System.IO.Directory.Exists(dir))
				try
				{
					System.IO.Directory.CreateDirectory(dir);
				}
				catch
				{
					return null;
				}
			return dir;
		}

		public static string LoadDirectory
		{
			get { return DirectoryCheck("LoadDirectory"); }
		}

		public static string LoadedDirectory
		{
			get { return DirectoryCheck("LoadedDirectory"); }
		}

		public static string UnloadDirectory
		{
			get { return DirectoryCheck("UnloadDirectory"); }
		}

		public static string ErrorDirectory
		{
			get { return DirectoryCheck("ErrorDirectory"); }
		}

	}
}
