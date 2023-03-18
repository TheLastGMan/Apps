using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PixelMapper.Profile.RpgDmd.ConversionProfile.DMD64;

namespace PixelMapper.Profile.RpgDmd.Test
{
	[TestClass]
	public class DMD64_Settings
	{
		[TestMethod]
		public void Generate()
		{
			//Arrange
			var serializer = new Core.Serializer();
			var setting = new DMD64Settings()
			{
				OutputWidth = 128,
				OutputHeight = 32,
				GammaInfo = new Core.GammaInfo(),
				PluginInfo = new Core.OutputPlugin()
				{
					Name = "Name",
					Description = "Desc",
					Version = "Ver",
					CreatedBy = "Owner"
				}
			};

			//Act
			string output = "";
			try
			{
				output = serializer.SerializeXML(setting);
			}
			catch (Exception ex)
			{
				Assert.Fail("Generate Settings File Failed: " + ex.Message);
			}

			//Assert
			Trace.WriteLine(output);
		}
	}
}
