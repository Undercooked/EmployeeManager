using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.UI.Models.UserModels;

namespace EmployeeManager.UI
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetUsersAsync();
	}
}
