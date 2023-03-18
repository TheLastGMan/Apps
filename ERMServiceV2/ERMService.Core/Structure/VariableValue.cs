using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Core.Structure
{
	public class VariableValue
	{
		public VariableValue()
		{ }

		public VariableValue(int TimePeriod, decimal Value)
		{
			this.TimePeriod = TimePeriod;
			this.Value = Value;
		}

		public int TimePeriod { get; set; }
		public decimal Value { get; set; }
	}
}
