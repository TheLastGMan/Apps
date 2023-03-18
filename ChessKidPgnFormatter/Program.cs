using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKidPgnFormatter
{
	class Program
	{
		static void Main(string[] args)
		{
			if(args.Length == 0)
			{
				Console.WriteLine("Expecting a file name as an input");
				return;
			}
			if(args.Length > 1)
			{
				Console.WriteLine("To many inputs");
				return;
			}

			//read file
			FileInfo f = new FileInfo(args[0]);
			if(!f.Exists)
			{
				Console.WriteLine("File does not exist: " + args[0]);
				return;
			}

			string[] content = File.ReadAllLines(f.FullName);
			using (var sw = new StreamWriter(f.FullName))
				foreach (string line in content)
				{
					string cline = line.Trim(' ');
					int ivalue = -1;
					if (!String.IsNullOrEmpty(cline) && int.TryParse(cline[0].ToString(), out ivalue))
					{
						//PGN notation
						string[] notation = cline.Split(' ');
						int index = 0;
						for(; index < notation.Length - 1; index += 2)
							sw.WriteLine($"{ notation[index] } { notation[index + 1] }");

						if (index < notation.Length)
							sw.WriteLine(notation[index]);
					}
					else
					{
						//not a PGN notation, write it back
						sw.WriteLine(cline);
					}
				}
		}
	}
}
