using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERMService.Core.Structure;
using EntityFramework.BulkInsert.Extensions;

namespace ERMService.Core.Service
{
	public class ERMReportingService
	{
		private readonly int _ApplicationVersion = 3;

		public int RunId(RunName RunName)
		{
			//check if BaseRunName exists and delete all values associated with it and attach to existing number,
			Logging.Logger.Debug("Checking for existance of previous run");
			var ctx = Data.DBContext.NewContext;
			var record = ctx.ERM_RUN.FirstOrDefault(f => f.ERM_RUN_DESC == RunName.CompatibleFileName);
			if (record != null)
			{
				Logging.Logger.Debug("Removing previous run (replace value)");
				ClearValuesForRun(record.ERM_RUN_ID);
				return record.ERM_RUN_ID;
			}

			//create since it was not found
			Logging.Logger.Debug("Creating run record");
			var runRecord = new Data.ERM_RUN()
			{
				ERM_RUN_ID = NextAvailableRunId(),
				ERM_RUN_VERSION_ID = _ApplicationVersion,
				ERM_RUN_DESC = RunName.CompatibleFileName,
				VALUATION_DT = RunName.QuarterDate,
				CREATE_DT = RunName.Created,
				ERM_BUSINESS_COMPANY_ASSOC_SEQ_ID = BusinessNameIdMappingCache(RunName.LineOfBusiness),
				INFORCE_FLAG = RunName.InforceFlag,
				INSERT_DT = DateTime.Now
			};
			ctx.ERM_RUN.Add(runRecord);
			ctx.SaveChanges();

			return runRecord.ERM_RUN_ID;
		}

		public void VariableNameCheck(IEnumerable<string> VariableNames)
		{
			//add any missing variable names into the database
			Logging.Logger.Debug("Searching for new variables");
				string[] variables = Data.DBContext.NewContext.ERM_FINANCIAL_COLUMN.Select(f => f.ERM_FINANCIAL_COLUMN_NM).Distinct().ToArray();
				string[] unfoundVariables = VariableNames.Except(variables).ToArray();

				//add new variables to the database
				Logging.Logger.Debug("Inserting new variables");
				Parallel.ForEach(unfoundVariables, variable =>
				{
					using (var ctx = Data.DBContext.NewContext)
					{
						ctx.ERM_FINANCIAL_COLUMN.Add(new Data.ERM_FINANCIAL_COLUMN()
						{
							ERM_FINANCIAL_COLUMN_NM = variable,
							ERM_FINANCIAL_COLUMN_HEADER = variable,
							ERM_FINANCIAL_BUSINESS_NM = String.Empty,
							ERM_FINANCIAL_COLUMN_DESC = variable,
							CASHFLOW_BALANCE_FLAG = String.Empty,
							INSERT_DT = DateTime.Now
						});
						ctx.SaveChanges();
					}
				});
		}

		public void AddVariableValues(int RunId, IEnumerable<Variable> Variables)
		{
			Logging.Logger.Debug("Adding variable values");
			Parallel.ForEach(Variables, (variable) =>
			{
				//don't insert variables whos values are all zero
				if (!variable.Values.All(f => f.Value == 0))
					using (var ctx = Data.DBContext.NewContext)
					{
						//insert time period values for variable
						foreach (var value in variable.Values)
							ctx.ERM_FINANCIAL_VALUE.Add(new Data.ERM_FINANCIAL_VALUE()
							{
								ERM_RUN_ID = RunId,
								ERM_RUN_VERSION_ID = _ApplicationVersion,
								ERM_SHOCK_GROUP_SEQ_ID = variable.Shock,
								ERM_PERIOD_TYPE_SEQ_ID = 3,
								ERM_PERIOD_ID = value.TimePeriod,
								ERM_FINANCIAL_COLUMN_SEQ_ID = VariableColumnMappingCache(variable.VariableName),
								ERM_FINANCIAL_COLUMN_VALUE = value.Value,
								INSERT_DT = DateTime.Now
							});
						ctx.SaveChanges();
					}
			});
		}

		private ConcurrentDictionary<string, int> _VariableCache = new ConcurrentDictionary<string, int>();
		public int VariableColumnMappingCache(string Variable)
		{
			//validate
			if (String.IsNullOrEmpty(Variable))
				throw new ArgumentNullException("Variable");

			Logging.Logger.Debug("Loading cached variable column mapping for: " + Variable);
			return _VariableCache.GetOrAdd(Variable, VariableColumnMapping(Variable));
		}

		private int VariableColumnMapping(string Variable)
		{
			//validate
			if (String.IsNullOrEmpty(Variable))
				throw new ArgumentNullException("Variable");

			//load
			Logging.Logger.Debug("Loading variable column mapping for: " + Variable);
			var record = Data.DBContext.NewContext.ERM_FINANCIAL_COLUMN.FirstOrDefault(f => f.ERM_FINANCIAL_COLUMN_NM == Variable);
			if (record == null)
				throw new Exception("Variable Not Found: " + Variable);

			return record.ERM_FINANCIAL_COLUMN_SEQ_ID;
		}

		public int NextAvailableRunId()
		{
			Logging.Logger.Debug("Finding next available run id");
			var record = Data.DBContext.NewContext.ERM_RUN.OrderByDescending(f => f.ERM_RUN_ID).First();
			return record.ERM_RUN_ID + 1;
		}

		private ConcurrentDictionary<string, int> _BusinessCache = new ConcurrentDictionary<string, int>();
		public int BusinessNameIdMappingCache(string LineOfBusiness)
		{
			//validate
			if (String.IsNullOrEmpty(LineOfBusiness))
				throw new ArgumentNullException(LineOfBusiness);

			Logging.Logger.Debug("Loading cached business id mapping for: " + LineOfBusiness);
			return _BusinessCache.GetOrAdd(LineOfBusiness, BusinessNameIdMapping(LineOfBusiness));
		}

		private int BusinessNameIdMapping(string LineOfBusiness)
		{
			//validate
			if (String.IsNullOrEmpty(LineOfBusiness))
				throw new ArgumentNullException(LineOfBusiness);

			//query for record
			Logging.Logger.Debug("Loading business id mapping for: " + LineOfBusiness);
			var record = Data.DBContext.NewContext.BUSINESSes.FirstOrDefault(f => f.BUSINESS_CODE == LineOfBusiness);
			if (record == null)
				throw new Exception("No Business Found For: " + LineOfBusiness);

			return record.BUSINESS_ID;
		}

		public void ClearValuesForRun(int RunId)
		{
			Logging.Logger.Debug("Removing variables from run id: " + RunId.ToString());
			var toRemove = Data.DBContext.NewContext.ERM_FINANCIAL_VALUE.Where(f => f.ERM_RUN_ID == RunId);
			foreach(var f in toRemove)
			{
				var ctx = Data.DBContext.NewContext;
				ctx.ERM_FINANCIAL_VALUE.Remove(f);
				ctx.SaveChanges();
			}
		}

		public void ClearRun(int RunId)
		{
			Logging.Logger.Debug("Removing run records for run id: " + RunId.ToString());
			var ctx = Data.DBContext.NewContext;
			var records = ctx.ERM_RUN.Where(f => f.ERM_RUN_ID == RunId).ToList();
			records.ForEach(f => ctx.ERM_RUN.Remove(f));
			ctx.SaveChanges();
		}
	}
}
