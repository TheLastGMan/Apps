using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Core.Structure
{
	public class RunName
	{
		public RunName()
		{
			LineOfBusiness = String.Empty;
			InforceFlag = String.Empty;
			CompanyCode = String.Empty;
			Description = String.Empty;
			FullFilePath = String.Empty;
			FullFileName = String.Empty;
			CompatibleFileName = String.Empty;
		}

		public string LineOfBusiness { get; set; }

		public string InforceFlag { get; set; }

		public string CompanyCode { get; set; }

		public DateTime QuarterDate { get; set; }

		public int Shock { get; set; }

		public string Description { get; set; }


		public DateTime Created { get; set; }

		public string FullFilePath { get; set; }

		public string FullFileName { get; set; }

		public string CompatibleFileName { get; set; }
	}
}
