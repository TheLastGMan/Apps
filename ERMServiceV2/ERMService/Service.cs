using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace ERMService
{
	public partial class Service : ServiceBase
	{
		private Core.Process.IProcess _Process;

		public Service()
		{
			InitializeComponent();
			_Process = new Core.Process.CSVProcess();
		}

		protected override void OnStart(string[] args)
		{
			//start logger
			Core.Common.Logger = new NLogging();

			//set up database connection
			//Data.DBContext.ConnectionString = Settings.ERMReportingConnection;

			//set up timer
			Timer _Timer = new Timer(Settings.TimerDelaySeconds * 1000);
			_Timer.Elapsed += _Timer_Elapsed;
			_Timer.Start();
		}

		protected override void OnStop()
		{
			//close timer
			base.OnStop();
		}

		private object _RunningLock = new object();
		private bool _Running = false;
		void _Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			RunProcess();
		}

		void RunProcess()
		{
			//check if we are not already running and mark to run
			bool run = false;
			lock (_RunningLock)
			{
				if (!_Running)
				{
					_Running = true;
					run = true;
				}
			}

			//run process
			if (run)
			{
				try
				{
					RunProcess();
				}
				catch
				{
					_Process.Load(Settings.LoadDirectory, Settings.LoadedDirectory, Settings.ErrorDirectory);
					_Process.Unload(Settings.UnloadDirectory, Settings.LoadedDirectory, Settings.ErrorDirectory);
				}
				finally
				{
					_Running = false;
				}
			}
		}

	}
}
