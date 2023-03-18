using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Core.Process
{
	public interface IProcess
	{
		string Name { get; }
		void Load(string InputDirectory, string OutputDirectory, string ErrorDirectory);
		void Unload(string InputDirectory, string OutputDirectory, string ErrorDirectory);
	}
}
