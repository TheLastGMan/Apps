using RPGPinEditor.Core.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements.Helpers
{
	/// <summary>
	/// Prefixes list of statements with the size of it's output
	/// </summary>
	public class BLOCKSIZE : StatementBlock, IStatement
	{
		public BLOCKSIZE()
		{ }

		public BLOCKSIZE(StatementBlock block, string comment = "Block Size [lines]") : base(block)
		{
			Comment = comment;
		}

		private string Comment { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			var result = base.DebugCode();
			result.Insert(0, new DebugStatement(result.Count(f => !f.IsComment), Comment, false, false));
			return result;
		}
	}
}
