using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Finder
{
	public class TypeFinder : ITypeFinder
	{

		private bool loadAppDomainAssemblies = true;
		private string assemblySkipLoadingPatterm = "^System|^mscorlib|^Microsoft|^CppCodeProvider|^VJSharpCodeProvider|^VBCodeProvider|^WebDev|^EntityFramework|^MvcContrib|^AjaxControlToolkit|^SMDiagnostics";
		private string assemblyRestrictToLoadingPattern = ".*";
		private static List<string> assemblyNameCache = new List<string>();
		private static List<Assembly> assemblyCache = new List<Assembly>();

		public TypeFinder()
		{
			LoadMatchingAssemblies(App.BaseDirectory);
			getAssemblies(true);
		}

		private AppDomain App
		{
			get
			{
				return AppDomain.CurrentDomain;
			}
		}

		public IEnumerable<T> FoundClassesOfType<T>() where T : class
		{
			foreach (Type t in FindClassesOfType<T>())
			{
				yield return (T)Activator.CreateInstance(t);
			}
		}

		public List<Type> FindClassesOfType<T>() where T : class
		{
			return FindClassesOfType(typeof(T), getAssemblies());
		}

		public List<Type> FindClassesOfType(Type T)
		{
			return FindClassesOfType(T, getAssemblies());
		}

		private List<Type> FindClassesOfType(Type Type, List<Assembly> assemblies)
		{
			var result = new List<Type>();

			try
			{
				//loop through each assemblly
				foreach (var a in assemblies)
				{
					//go through each type
					foreach (var t in a.GetTypes())
					{
						//check if matches the type we are looking for
						if (Type.IsAssignableFrom(t))
						{
							//it can not be an interface
							if (!t.IsInterface)
							{
								//check for a solid class
								if (t.IsClass && !t.IsAbstract)
								{
									result.Add(t);
								}
							}
						}
					}
				}
			}
			catch
			{
				//not to worried about not finding it
			}

			return result;
		}

		private List<Assembly> getAssemblies(bool refresh = false)
		{
			if (assemblyCache.Count > 0 && !refresh)
				return assemblyCache;

			if (loadAppDomainAssemblies)
			{
				assemblyNameCache.Clear();
				assemblyCache.Clear();
				AddAssembliesInAppdomain(ref assemblyNameCache, ref assemblyCache);
			}

			return assemblyCache;
		}

		private void AddAssembliesInAppdomain(ref List<string> addedAssemblyNames, ref List<Assembly> assemblies)
		{
			foreach (Assembly assembly in App.GetAssemblies())
			{
				if (Matches(assembly.FullName))
				{
					if (!addedAssemblyNames.Contains(assembly.FullName))
					{
						assemblies.Add(assembly);
						addedAssemblyNames.Add(assembly.FullName);
					}
				}
			}
		}

		private bool Matches(string assemblyFullName)
		{
			return (!Matches(assemblyFullName, assemblySkipLoadingPatterm) && Matches(assemblyFullName, assemblyRestrictToLoadingPattern));
		}

		private bool Matches(string assemblyFullName, string pattern)
		{
			return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		private void LoadMatchingAssemblies(string directoryPath)
		{
			var loadedAssemblyNames = getAssemblies().Select(f => f.FullName).ToList();

			if (!System.IO.Directory.Exists(directoryPath))
				return;

			foreach (string dllPath in System.IO.Directory.GetFiles(directoryPath, "*.dll"))
			{
				try
				{
					var an = AssemblyName.GetAssemblyName(dllPath);
					if (Matches(an.FullName) && !loadedAssemblyNames.Contains(an.FullName))
						App.Load(an);
				}
				catch
				{
					//already loaded
				}
			}
		}

	}
}
