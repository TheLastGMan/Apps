using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ERMService.Core.Test
{
	/// <summary>
	/// Summary description for CSVServiceTest
	/// </summary>
	[TestClass]
	public class CSVServiceTest
	{
		private Core.Process.CSVProcess _Process = new Process.CSVProcess();

		[TestMethod]
		public void CSVLoad_Test()
		{
			//arrange
			Core.Common.Logger = new NLogging();
			Directory.CreateDirectory("./Load");
			Directory.CreateDirectory("./Loaded");
			Directory.CreateDirectory("./Error");

			//act
			try
			{
				_Process.Load("./Load", "./Loaded", "./Error");
			}
			catch (Exception ex)
			{
				Assert.Fail("Error during load: " + ex.Message);
			}

			//assert
		}

		[TestMethod]
		public void CSVUnload_Test()
		{
			//arrange
			Core.Common.Logger = new NLogging();
			Directory.CreateDirectory("./Loaded");
			Directory.CreateDirectory("./Error");

			//act
			try
			{
				_Process.Unload("./", "./Loaded", "./Error");
			}
			catch (Exception ex)
			{
				Assert.Fail("Error during unload: " + ex.Message);
			}

			//assert
		}

	}
}
