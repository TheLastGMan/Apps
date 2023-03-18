using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public class Locator
	{
		private static Finder.TypeFinder TypSvc = new Finder.TypeFinder();

		public static void AddSearchDirectories(params string[] Directories)
		{
			string[] files = Directories.SelectMany(f => System.IO.Directory.GetFiles(f, "*.dll", System.IO.SearchOption.AllDirectories)).ToArray();
			foreach(var dll in files)
			{
				var an = System.Reflection.AssemblyName.GetAssemblyName(dll);
				AppDomain.CurrentDomain.Load(an);
			}
			TypSvc = new Finder.TypeFinder();
		}

		private static List<IConversionFormat> _LoadedProfiles;
		public static List<IConversionFormat> LoadedProfiles
		{
			get { return _LoadedProfiles ?? (_LoadedProfiles = TypSvc.FoundClassesOfType<IConversionFormat>().ToList()); }
		}

		private static List<IOutputFormat> _LoadedOutputProfiles;
		public static List<IOutputFormat> LoadedOutputProfiles
		{
			get { return _LoadedOutputProfiles ?? (_LoadedOutputProfiles = TypSvc.FoundClassesOfType<IOutputFormat>().ToList()); }
		}
	}
}
