using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERMService.Core.CSVProcess;
using ERMService.Core.Structure;

namespace ERMService.Core.Process
{
	public class CSVProcess : IProcess
	{
		private FileParser _ParseSvc;
		private IO.FileSvc _FileSvc;
		private Service.ERMReportingService _ERMSvc;

		public CSVProcess()
		{
			_ParseSvc = new FileParser();
			_FileSvc = new IO.FileSvc();
			_ERMSvc = new Service.ERMReportingService();
		}

		public string Name
		{
			get { return "CSV"; }
		}

		public void Load(string InputDirectory, string OutputDirectory, string ErrorDirectory)
		{
			//validate
			if (String.IsNullOrEmpty(InputDirectory))
				throw new ArgumentNullException("InputDirectory");
			if (String.IsNullOrEmpty(OutputDirectory))
				throw new ArgumentNullException("OutputDirectory");
			if (String.IsNullOrEmpty(ErrorDirectory))
				throw new ArgumentNullException("ErrorDirectory");

			//execute routine
			Logging.Logger.Info("Load Files");
			LoadUnloadRoutine(InputDirectory, OutputDirectory, ErrorDirectory, LoadFileGroup);
		}

		public void Unload(string InputDirectory, string OutputDirectory, string ErrorDirectory)
		{
			//validate
			if (String.IsNullOrEmpty(InputDirectory))
				throw new ArgumentNullException("InputDirectory");
			if (String.IsNullOrEmpty(OutputDirectory))
				throw new ArgumentNullException("OutputDirectory");
			if (String.IsNullOrEmpty(ErrorDirectory))
				throw new ArgumentNullException("ErrorDirectory");

			//execute routine
			Logging.Logger.Info("Unload Files");
			LoadUnloadRoutine(InputDirectory, OutputDirectory, ErrorDirectory, UnloadFileGroup);
		}

		internal void LoadUnloadRoutine(string InputDirectory, string OutputDirectory, string ErrorDirectory, Action<IEnumerable<RunName>> Process)
		{
			//validate
			if (String.IsNullOrEmpty(InputDirectory))
				throw new ArgumentNullException("InputDirectory");
			if (String.IsNullOrEmpty(OutputDirectory))
				throw new ArgumentNullException("OutputDirectory");
			if (String.IsNullOrEmpty(ErrorDirectory))
				throw new ArgumentNullException("ErrorDirectory");
			if (Process == null)
				throw new ArgumentNullException("Process");

			//setup
			Logging.Logger.Debug("Setting up directories");
			var inDir = new DirectoryInfo(InputDirectory);
			var outDir = new DirectoryInfo(OutputDirectory);
			var errDir = new DirectoryInfo(ErrorDirectory);

			//retreive files and process
			Logging.Logger.Debug("Locating and grouping files in directory");
			var files = _FileSvc.ScanInputDirectory(inDir, Name).Where(f => _ParseSvc.ValidFileName(f));
			var fileGroups = files.Select(f => _ParseSvc.ParseFileName(f)).GroupBy(f => f.CompatibleFileName);
			foreach (var fileGroup in fileGroups)
			{
				var groupFiles = fileGroup.Select(f => f).ToList();
				//key is the compatiable file name
				try
				{
					Logging.Logger.Info("Processing group: " + groupFiles.First().CompatibleFileName);

					//load then move file to output directory
					Process(groupFiles);
					_FileSvc.MoveFileGroup(groupFiles, inDir, outDir);
				}
				catch (Exception ex)
				{
					//move file group to error directory
					List<string> errors = new List<string>();
					do
					{
						errors.Add(ex.Message);
					} while ((ex = ex.InnerException) != null);
					Logging.Logger.Error("Error during process: " + String.Join(System.Environment.NewLine, errors));
					_FileSvc.MoveFileGroup(groupFiles, inDir, errDir);
				}
			}
			Logging.Logger.Info("Process complete");
		}

		/// <summary>
		/// Parent is set up to group by their compatible file name
		/// </summary>
		/// <param name="Files">Collection of shocked csv files by their compatible file name</param>
		internal void LoadFileGroup(IEnumerable<RunName> Files)
		{
			//validate
			if (Files == null)
				throw new ArgumentNullException("Files");

			//soft validation
			if (!Files.Any())
				return;

			//load run id and parse shock files
			Logging.Logger.Info("Loading run id and variable data");
			int runId = _ERMSvc.NextAvailableRunId();

			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();

			var variableData = Files.AsParallel().SelectMany(f => _ParseSvc.LoadFile(f)).ToList();

			//add any new variable names found to the lookup table
			Logging.Logger.Info("Add new variables into database");
			_ERMSvc.VariableNameCheck(variableData.Select(f => f.VariableName).Distinct());

			//insert into database and commit
			Logging.Logger.Info("Inserting values into database");
			_ERMSvc.AddVariableValues(runId, variableData);

			sw.Stop();
			Logging.Logger.Debug("run id: " + runId.ToString() + " completed in: " + sw.ToString());

			Logging.Logger.Info("Loading group complete: " + Files.First().CompatibleFileName);
		}

		/// <summary>
		/// Parent is set up to group by their compatible file name
		/// </summary>
		/// <param name="Files">Collection of shocked csv files by their compatible file name</param>
		internal void UnloadFileGroup(IEnumerable<RunName> Files)
		{
			//validate
			if (Files == null)
				throw new ArgumentNullException("Files");

			//soft validation
			if (!Files.Any())
				return;

			//load run id
			Logging.Logger.Info("Parsing run name from file");
			string runName = Files.First().CompatibleFileName;
			var record = Data.DBContext.NewContext.ERM_RUN.OrderByDescending(f => f.ERM_RUN_ID).FirstOrDefault(f => f.ERM_RUN_DESC == runName);
			if (record == null)
				return; //nothing to delete

			//delete all data associated with the BaseRunName
			//financial value records
			Logging.Logger.Info("Removing variables from run");
			_ERMSvc.ClearValuesForRun(record.ERM_RUN_ID);

			//run record
			Logging.Logger.Info("Removing run entry");
			_ERMSvc.ClearRun(record.ERM_RUN_ID);

			Logging.Logger.Info("Unload group complete: " + runName);
		}

	}
}
