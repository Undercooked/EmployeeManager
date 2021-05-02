using AutoMapper;
using EmployeeManager.UI.Model.UserModels;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI.Mappers
{
	internal class UserMapper : Profile
	{
		public UserMapper()
		{
			CreateMap<UserResponse, UserViewModel>();
		}
	}
}
