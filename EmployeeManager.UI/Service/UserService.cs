using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI.Service
{
	internal class UserService : IUserService
	{
		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			this.userRepository = userRepository;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
		{
			var users = await userRepository.GetUsersAsync().ConfigureAwait(false);
			var userViewModels = mapper.Map<IEnumerable<UserViewModel>>(users);

			return userViewModels;
		}
	}
}
