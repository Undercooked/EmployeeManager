using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;

namespace EmployeeManager.UI.Service
{
	internal class CsvExportFormatService : IExportFormatService
	{
		private readonly string exportDirectoryPath;

		public CsvExportFormatService()
		{
			exportDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "technical-assessment-export");
		}
	
		public async Task ExportRecordsAsync(IEnumerable records)
		{
			Directory.CreateDirectory(exportDirectoryPath);

			var exportName = $"users.{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.csv";

			using var streamWriter = new StreamWriter(Path.Combine(exportDirectoryPath, exportName));
			using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

			await csvWriter.WriteRecordsAsync(records);
		}
	}
}
