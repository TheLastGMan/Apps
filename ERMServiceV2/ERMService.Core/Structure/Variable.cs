using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Core.Structure
{
	public class Variable
	{

		public Variable()
		{
			VariableName = String.Empty;
			Values = new List<VariableValue>();
		}

		public Variable(string VariableName, int Shock)
		{
			this.VariableName = VariableName;
			this.Shock = Shock;
			Values = new List<VariableValue>();
		}

		public string VariableName { get; set; }

		public int Shock { get; set; }

		public List<VariableValue> Values { get; private set; }

	}
}
