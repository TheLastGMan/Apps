using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERMService.Core.Test
{
	[TestClass]
	public class ERMReportingTest
	{
		private readonly Service.ERMReportingService _ErmSvc = new Service.ERMReportingService();

		[TestMethod]
		public void ErmReporting_BusinessNameId()
		{
			//arrange
			string business = "Certs";
			int expected = 8;

			//act
			int actual = _ErmSvc.BusinessNameIdMappingCache(business);

			//assert
			Assert.AreEqual(expected, actual, "Expected value for " + business + " did not match");
		}

		[TestMethod]
		public void ErmReporting_VariableId()
		{
			//arrange
			string variable = "inc_reins_asset";
			int expected = 314;

			//act
			int actual = _ErmSvc.VariableColumnMappingCache(variable);

			//assert
			Assert.AreEqual(expected, actual, "Expected value for " + variable + " did not match");
		}

	}
}
