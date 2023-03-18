using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public class FolderAccess
	{
		private readonly Serializer XmlSvc = new Serializer();

		public Dictionary<string, string> Images(string FolderPath)
		{
			string[] formats = { ".bmp", ".gif", ".png", ".jpg" };
			var files = new Dictionary<string, string>();

			//validate
			if (String.IsNullOrEmpty(FolderPath) || !System.IO.Directory.Exists(FolderPath))
				return files;

			//load image files
			files = System.IO.Directory.GetFiles(FolderPath, "*.*", System.IO.SearchOption.TopDirectoryOnly)
				.Select(f => new System.IO.FileInfo(f)).Where(f => formats.Contains(f.Extension.ToLower()))
				.OrderBy(f => f.Name).ToDictionary(f => f.Name, f => f.FullName);
			return files;
		}

		public string FindFile(string FileName, string SourceFolder)
		{
			if (!System.IO.Directory.Exists(SourceFolder))
				return "";
			if (String.IsNullOrEmpty(FileName))
				return "";

			//find file
			var files = System.IO.Directory.GetFiles(SourceFolder, FileName, System.IO.SearchOption.AllDirectories);
			if (files.Length > 0)
				return files[0];
			return "";
		}

		public T LoadSettings<T>(string SettingsFileName, T Defaults) where T : class
		{
			try
			{
				string settingsFile = SettingsFile(SettingsFileName);
				if (!System.IO.File.Exists(settingsFile))
					SaveSettings(SettingsFileName, Defaults);
				return XmlSvc.DeserializeXML<T>(System.IO.File.ReadAllText(settingsFile));
			}
			catch (Exception ex)
			{
				ErrorHandler.RaiseMessageEvent("Load Settings Error for (" + SettingsFileName + "): " + ex.Message);
				return Defaults;
			}
		}

		public void SaveSettings<T>(string SettingsFileName, T Value) where T : class
		{
			string settingsFile = SettingsFile(SettingsFileName);
			using (var sw = new System.IO.StreamWriter(settingsFile, false, System.Text.Encoding.UTF8))
				sw.Write(XmlSvc.SerializeXML(Value));
		}

		public string SettingsFile(string SettingsFileName)
		{
			return System.IO.Path.Combine(SettingDirectory(), SettingsFileName);
		}

		public string SettingDirectory()
		{
			string baseFolder = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments;
			string appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
			appName = appName.Substring(0, appName.IndexOf('.'));
			string basePath = System.IO.Path.Combine(baseFolder, appName);

			if (!System.IO.Directory.Exists(basePath))
				System.IO.Directory.CreateDirectory(basePath);

			return basePath;
		}
	}
}
