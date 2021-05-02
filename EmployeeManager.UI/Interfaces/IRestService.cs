using System;
using System.Threading.Tasks;

namespace EmployeeManager.UI
{
	public interface IRestService
	{
		Task<T> PerformGetRequestAsync<T>(Uri uri);
	}
}
