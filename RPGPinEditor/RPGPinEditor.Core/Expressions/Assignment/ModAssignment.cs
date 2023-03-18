﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Assignment
{
	public class ModAssignment : BaseAssignment
	{
		public ModAssignment()
		{ }

		public ModAssignment(IExpression index, IExpression value) : base (index, value)
		{ }

		public override string AssignKey
		{
			get
			{
				return "%=";
			}
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.ModAssignment;
			}
		}
	}
}
