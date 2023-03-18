using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core
{
	public interface IStatement
	{
		//List<int> IntCode();
		List<DebugStatement> DebugCode();
	}
}
