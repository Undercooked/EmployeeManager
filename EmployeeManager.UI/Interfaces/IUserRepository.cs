using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.UI.Model.UserModels;

namespace EmployeeManager.UI
{
	public interface IUserRepository
	{
		Task<UsersResponse> GetUsersAsync(string searchTerm, int page);

		Task<IEnumerable<UserResponse>> GetAllUsersAsync();
	}
}
