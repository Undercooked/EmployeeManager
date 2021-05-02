using System;
using EmployeeManager.UI.Model.UserModels;

namespace EmployeeManager.UI.ViewModel.UserViewModels
{
	public class UserViewModel
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public Gender Gender { get; set; }

		public UserStatus Status { get; set; }

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset UpdatedAt { get; set; }
	}
}
