using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI
{
	public interface IUserService
	{
		Task<IEnumerable<UserViewModel>> GetUsersAsync();
	}
}
