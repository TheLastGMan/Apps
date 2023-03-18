using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERMService.Core.Test
{
	[TestClass]
	[DeploymentItem(@"TestFiles\*")]
	public class FileServiceTest
	{
		private readonly IO.FileSvc _FileService = new IO.FileSvc();
		private readonly CSVProcess.FileParser _ParseSvc = new CSVProcess.FileParser();

		[TestMethod]
		public void FileService_ScanInputDirectory()
		{
			//arrange
			

			//act
			var files = _FileService.ScanInputDirectory(new DirectoryInfo("./"), "csv");

			//assert
			Assert.IsTrue(files.Any(), "No csv Files Found");
		}

		[TestMethod]
		public void FileService_MoveFileGroup()
		{
			//arrange
			System.IO.Directory.CreateDirectory("./Loaded");
			System.IO.Directory.CreateDirectory("./Load");
			var baseDir = new System.IO.DirectoryInfo("./Load");
			var destDir = new System.IO.DirectoryInfo("./Loaded");
			var files = _FileService.ScanInputDirectory(baseDir, "csv");
			var validFiles = files.Where(f => _ParseSvc.ValidFileName(f)).Select(f => _ParseSvc.ParseFileName(f));

			//act
			_FileService.MoveFileGroup(validFiles, baseDir, destDir);
			int count = System.IO.Directory.GetFiles("./Loaded", "*.csv", System.IO.SearchOption.TopDirectoryOnly).Length;

			//assert
			Assert.IsTrue(count > 0, "No Files in Moved directory");
		}
	}
}
