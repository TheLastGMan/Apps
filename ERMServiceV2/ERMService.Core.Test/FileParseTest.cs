using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERMService.Core.Test
{
	[TestClass]
	[DeploymentItem(@"TestFiles\*")]
	public class FileParseTest
	{
		private readonly CSVProcess.FileParser _FileParseSvc = new CSVProcess.FileParser();

		[TestMethod]
		public void FileParse_ParseFileName_Valid()
		{
			//arrange
			var fileInfo = new FileInfo("certs_inf_nat_20150331_7_v1.csv");

			//act
			var result = _FileParseSvc.ParseFileName(fileInfo);

			//assert
			Assert.AreEqual("certs", result.LineOfBusiness, "LOB Does Not Match");
			Assert.AreEqual("inf", result.InforceFlag, "Inforce Does Not Match");
			Assert.AreEqual("nat", result.CompanyCode, "Company Code Does Not Match");
			Assert.AreEqual(new DateTime(2015, 3, 31), result.QuarterDate, "Quarter End Date Does Not Match");
			Assert.AreEqual(7, result.Shock, "Shock Does Not Match");
			Assert.AreEqual("v1", result.Description, "Description Does Not Match");
		}

		[TestMethod]
		public void FileParse_ParseFileName_MissingShock()
		{
			//arrange
			var fileInfo = new FileInfo("certs_inf_nat_20150331_7_v1.csv");

			//act
			try
			{
				_FileParseSvc.ParseFileName(fileInfo);
				Assert.Fail("File Parsed with missing shock");
			}
			catch
			{
				//passed
			}

			//assert
		}

		[TestMethod]
		public void FileParse_LoadFile_Valid()
		{
			//arrange
			var fileInfo = new FileInfo("certs_inf_nat_20150331_7_v1.csv");
			var runName = _FileParseSvc.ParseFileName(fileInfo);

			//act
			var result = _FileParseSvc.LoadFile(runName);

			//assert
			string variable = "xfer_init_assets";
			Assert.IsTrue(result.Any(), "No Values Found");
			Assert.IsTrue(result.Any(f => f.VariableName == variable), "Variable (" + variable + ") Not Found");
			Assert.IsTrue(result.First(f => f.VariableName == variable).Values[0].Value == 0, "P0 Value For (" + variable + ") Not Accurate");
		}

		[TestMethod]
		public void FileParse_LoadFile_NoContent()
		{
			//arrange
			var fileInfo = new FileInfo("NoContent");
			var runName = _FileParseSvc.ParseFileName(fileInfo);

			//act
			try
			{
				_FileParseSvc.LoadFile(runName);
				Assert.Fail("File Parsed with no valid content");
			}
			catch
			{
			}

			//assert
		}

		[TestMethod]
		public void FileParse_FileName_Valid()
		{
			//arrange
			string fileName = "certs_inf_nat_20150331_7_v1.csv";
			var file = new FileInfo(fileName);

			//act
			bool valid = _FileParseSvc.ValidFileName(file);

			//assert
			Assert.IsTrue(valid, "Invalid file name: " + fileName);
		}

		[TestMethod]
		public void FileParse_FileName_Invalid()
		{
			//arrange
			string fileName = "certs_inf_nat_20150331_v1.csv";
			var file = new FileInfo(fileName);

			//act
			bool valid = _FileParseSvc.ValidFileName(file);

			//assert
			Assert.IsFalse(valid, "Invalid file name passed: " + fileName);
		}

	}
}
