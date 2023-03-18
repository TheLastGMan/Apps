using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core
{
	public interface IKeyword : IStatement
	{
		CommandCode Command { get; }
	}
}
