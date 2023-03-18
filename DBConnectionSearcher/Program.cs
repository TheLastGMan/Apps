using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DBConnectionSearcher
{
	class Program
	{
		static void Main(string[] args)
		{
			//validate
			if (args.Length == 0)
				Console.WriteLine("Input directory and output file not specified.");
			else if (args.Length == 1)
				Console.WriteLine("output file not specified");
			else
			{
				try
				{
					//variables
					DirectoryInfo inputFolder = new DirectoryInfo(args[0]);
					string outputFile = args[1];

					var sb = new StringBuilder();
					var results = new Program().Recurse(inputFolder);
					foreach (var result in results)
					{
						sb.AppendLine(result.FullFileName);
						foreach (var conn in result.ConnectionStrings)
							sb.AppendLine('\t' + conn.Name + " | " + conn.Server + " | " + conn.TableName);
					}

					//write to console
					foreach (var line in sb.ToString().Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None))
						Console.WriteLine(line);

					//save to file
					using (var sw = new StreamWriter(outputFile, false))
						sw.Write(sb.ToString());
				}
				catch (Exception ex)
				{
					do
					{
						Console.WriteLine("Error: " + ex.Message);
					} while ((ex = ex.InnerException) != null);
				}
			}
#if DEBUG
			Console.ReadKey();
#endif
		}

		public IEnumerable<SearchResult> Recurse(DirectoryInfo SearchDirectory)
		{
			var result = Navigate(SearchDirectory, false).ToList();
			var subresults = Directory.GetDirectories(SearchDirectory.FullName).AsParallel().SelectMany(dir => Navigate(new DirectoryInfo(dir)));
			result.AddRange(subresults);
			return result;
		}

		IEnumerable<SearchResult> Navigate(DirectoryInfo Directory, bool SubDirectories = true)
		{
			//validate
			if (Directory == null)
				throw new ArgumentNullException("Directory");

			//locate config files in current directory
			var files = Directory.GetFiles("*.config", (SubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));

			//parse connection information
			var results = new List<SearchResult>();
			foreach (var file in files)
			{
				var result = new SearchResult() { FullFileName = file.FullName };

				//parse as xml and add connection info
				var connections = ParseFile(file).connectionStrings;
				var strings = connections.Connections.Select(f =>
					{
						var connection = new ConnectionInfo() { Name = f.name };
						try
						{
							var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(f.connectionString);
							connection.Server = builder.DataSource;
							connection.TableName = builder.InitialCatalog;
						}
						catch (Exception ex)
						{
							//parse different way
							connection.Server = ServerNameFromConnection(f.connectionString);
							connection.TableName = TableNameFromConnection(f.connectionString);
						}
						return connection;
					});
				result.ConnectionStrings = strings.ToList();

				//add result
				results.Add(result);
			}

			return results;
		}

		string ServerNameFromConnection(string Connection)
		{
			//validate
			if (Connection == null)
				throw new ArgumentNullException("Connection");

			//soft validation
			if (Connection == String.Empty)
				return Connection;

			//parse
			return PartInformation("data source=", Connection);
		}

		string TableNameFromConnection(string Connection)
		{
			//validate
			if (Connection == null)
				throw new ArgumentNullException("Connection");

			//soft validation
			if (Connection == String.Empty)
				return Connection;

			//parse
			return PartInformation("initial catalog=", Connection);
		}

		string PartInformation(string Search, string Content)
		{
			//validate
			if (String.IsNullOrEmpty(Search))
				throw new ArgumentNullException("Search");
			if (String.IsNullOrEmpty(Content))
				throw new ArgumentNullException("Content");

			//locate
			Search = Search.ToLower();
			Content = Content.ToLower();
			int start = Content.IndexOf(Search) + Search.Length;
			int end = Content.IndexOf(";", start);
			string value = Content.Substring(start, end - start);
			return value;
		}

		ConfigStructure.configuration ParseFile(FileInfo File)
		{
			//validate
			if (File == null)
				throw new ArgumentNullException("File");

			//result placeholder
			ConfigStructure.configuration result;

			//deserialize
			try
			{
				var xmlDes = new System.Xml.Serialization.XmlSerializer(typeof(ConfigStructure.configuration));
				using (var sr = new StreamReader(File.FullName))
					result = (ConfigStructure.configuration)xmlDes.Deserialize(sr);
			}
			catch
			{
				//unable to read file, not a valid configuration file
				result = new ConfigStructure.configuration();
			}

			return result;
		}

	}
}
