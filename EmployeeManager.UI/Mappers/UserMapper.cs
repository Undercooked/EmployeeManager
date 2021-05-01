using AutoMapper;
using EmployeeManager.UI.Models.UserModels;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI.Mappers
{
	class UserMapper : Profile
	{
		public UserMapper()
		{
			CreateMap<User, UserViewModel>();
		}
	}
}
