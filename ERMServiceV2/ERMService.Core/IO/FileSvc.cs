using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ERMService.Core.CSVProcess;
using ERMService.Core.Structure;

namespace ERMService.Core.IO
{
	public class FileSvc
	{

		public void MoveFileGroup(IEnumerable<RunName> Files, DirectoryInfo InputDirectory, DirectoryInfo OutputDirectory)
		{
			//validate
			if (Files == null)
				throw new ArgumentNullException("Files");
			if (InputDirectory == null)
				throw new ArgumentNullException("InputDirectory");
			if (OutputDirectory == null)
				throw new ArgumentNullException("OutputDirectory");

			//move files
			Logging.Logger.Debug("Moving Files: (" + InputDirectory.FullName + ") -> (" + OutputDirectory.FullName + ")");
			foreach (var rn in Files)
			{
				string inputFile = Path.Combine(InputDirectory.FullName, rn.FullFileName);
				string outputFile = Path.Combine(OutputDirectory.FullName, rn.FullFileName);
				if(TryDeleteFile(outputFile))
					System.IO.File.Move(inputFile, outputFile);
			}
		}

		public bool TryDeleteFile(string FilePath)
		{
			//validate
			if (String.IsNullOrEmpty(FilePath))
				throw new ArgumentNullException("FilePath");

			//if not found, it doesn't exist, so mark true that files not there
			Logging.Logger.Debug("Trying to delete file: " + FilePath);
			if (!File.Exists(FilePath))
				return true;

			//try to delete file and mark if able to
			try
			{
				File.Delete(FilePath);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<FileInfo> ScanInputDirectory(DirectoryInfo InputDirectory, string Extension)
		{
			//validate
			if (InputDirectory == null)
				throw new ArgumentNullException("InputDirectory");
			if (String.IsNullOrEmpty(Extension))
				throw new ArgumentNullException("Extension");

			//search directory for files
			string extension = String.Format("*.{0}", Extension.ToLower());
			Logging.Logger.Debug("Scanning directory (" + InputDirectory.FullName + ") for " + extension + " files");
			var files = InputDirectory.GetFiles(extension, SearchOption.TopDirectoryOnly);
			return files;
		}

	}
}
