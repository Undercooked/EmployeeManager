using System.Collections;
using System.Threading.Tasks;

namespace EmployeeManager.UI
{
	public interface IExportFormatService
	{
		Task ExportRecordsAsync(IEnumerable records);
	}
}
