using ArenaChessGameAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Core
{
	public class EcoReader
	{

		public static IList<EcoData> ArenaEcoCodes(FileInfo ecoCodes)
		{
			//validate
			if (!ecoCodes.Exists)
				throw new Exception("Eco Code file must exist");

			//validate
			if (!ecoCodes.Exists)
				throw new Exception("Eco Code file must exist");

			//read ECO codes
			var result = new List<EcoData>();
			using (var sr = new StreamReader(ecoCodes.FullName))
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();

					//check for ECO opening
					if (line.StartsWith("{"))
					{
						var eco = new EcoData();
						string info = line.Substring(1, line.LastIndexOf('}') - 1);

						eco.Code = info.Split(' ')[0];
						eco.Name = String.Join(" ", info.Split(' ').Skip(1)).Trim();

						string moves = line.Substring(line.LastIndexOf('}') + 1);
						string[] plys = moves.Split(' ');

						//remove move numbers from ply depth
						for (int i = 0; i < plys.Length; i++)
						{
							if (plys[i].Contains('.'))
								plys[i] = plys[i].Substring(plys[i].IndexOf('.') + 1);

							eco.Moves.Add(plys[i]);
						}

						result.Add(eco);
					}
				}

			return result;
		}

		public static ILookup<EcoData, EcoData> ArenaEcoLookup(FileInfo ecoCodes)
		{
			var codes = ArenaEcoCodes(ecoCodes);
			return codes.ToLookup(f => f, new EcoEqualityComparer());
		}
	}
}
