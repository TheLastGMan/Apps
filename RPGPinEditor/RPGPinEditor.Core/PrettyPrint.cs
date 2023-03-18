using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core
{
	public static class PrettyPrint
	{
		public static string PrettyView(this IList<DebugStatement> debugCode)
		{
			return String.Join("", debugCode.Where(f => f.ShowInPrettyPrint).Select(f => f.Description));
		}
	}
}
