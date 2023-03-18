using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ERMService.Core.Structure;

namespace ERMService.Core.CSVProcess
{
	public class FileParser
	{
		private readonly int _TimePeriodColumnIndex = 2;
		private readonly int _VariableStartIndex = 3;
		private readonly int _MinRequiredColumns = 4;
		public static readonly string DateTimeFormat = "yyyyMMdd";

		public RunName ParseFileName(FileInfo FileName)
		{
			//validate
			if (FileName == null)
				throw new ArgumentNullException("FileName");

			//defined format
			//<Line of Business>_<Inforce Flag>_<Company Code>_<Full date (yyyyMMdd)>_<Shock>_<description>.csv
			Logging.Logger.Debug("Parsing File Name");
			string extenionlessName = FileName.Name.Substring(0, FileName.Name.IndexOf(FileName.Extension));
			string[] parts = extenionlessName.Split('_');
			if (parts.Length < 5)
				throw new Exception("Invalid File Name: " + FileName);

			//piece together previous filename by removing the Shock number
			Logging.Logger.Debug("Generating compatible file name");
			string compatibleFileName = String.Join("_", parts.Take(4));
			if (parts.Length >= 6)
				compatibleFileName += "_" + String.Join("_", parts.Skip(5));

			//map file
			Logging.Logger.Debug("Creating File Info");
			var runName = new RunName()
			{
				FullFileName = FileName.Name,
				FullFilePath = FileName.FullName,
				CompatibleFileName = compatibleFileName,
				Created = FileName.CreationTime,
				LineOfBusiness = parts[0],
				InforceFlag = parts[1],
				CompanyCode = parts[2],
				QuarterDate = DateTime.ParseExact(parts[3], DateTimeFormat, null),
				Shock = int.Parse(parts[4]),
				Description = (parts.Length >= 6) ? parts[5] : ""
			};
			return runName;
		}

		public bool ValidFileName(FileInfo File)
		{
			//validate
			if (File == null)
				throw new ArgumentException("File");

			try
			{
				Logging.Logger.Debug("Checking if file name is valid");
				ParseFileName(File);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<Variable> LoadFile(RunName ShockFile)
		{
			//validate
			if (ShockFile == null)
				throw new ArgumentNullException("ShockFile");

			//parse file
			Logging.Logger.Debug("Parsing shocked file");
			var variables = new List<Variable>();
			using (var sr = new StreamReader(ShockFile.FullFilePath))
			{
				//first line is the header (column names start at defined position)
				variables = sr.ReadLine().Split(',').Skip(_VariableStartIndex).Select(f => new Variable(f, ShockFile.Shock)).ToList();

				//iterate through each line to pull variable values
				while (!sr.EndOfStream)
				{
					//parse line and pull time period
					string[] line = sr.ReadLine().Split(',');
					if (line.Length >= _MinRequiredColumns)
					{
						int period = int.Parse(line[_TimePeriodColumnIndex]);

						//convert variable values
						for (int i = _VariableStartIndex; i < line.Length; i++)
						{
							decimal value = 0;
							decimal.TryParse(line[i], out value);

							//add value to associated variable
							var varValue = new VariableValue(period, value);
							variables[i - _VariableStartIndex].Values.Add(varValue);
						}
					}
				}
			}

			//remove variables that provided no name
			Logging.Logger.Debug("Removing variables that did not provide a name");
			variables = variables.Where(f => !String.IsNullOrEmpty(f.VariableName)).ToList();

			return variables;
		}

	}
}
