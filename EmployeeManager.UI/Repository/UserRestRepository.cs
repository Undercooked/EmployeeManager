using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.UI.Models.UserModels;

namespace EmployeeManager.UI.Repository
{
	internal class UserRestRepository : IUserRepository
	{
		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			await Task.Delay(3000).ConfigureAwait(false);

			return new List<User>
			{
				new User
				{
					Id = 1,
					Name = "Gov. Dwaipayana Chopra",
					Email = "chopra_gov_dwaipayana@ledner.io",
					Gender = Gender.Male,
					Status = UserStatus.Active,
					CreatedAt = DateTimeOffset.Parse("2021-05-01T03:50:04.368+05:30"),
					UpdatedAt = DateTimeOffset.Parse("2021-05-01T03:50:04.368+05:30")
				},
				new User
				{
					Id = 3,
					Name = "Anshula",
					Email = "anshula_ahluwalia_gov@brown.name",
					Gender = Gender.Female,
					Status = UserStatus.Active,
					CreatedAt = DateTimeOffset.Parse("2021-05-01T03:50:04.402+05:30"),
					UpdatedAt = DateTimeOffset.Parse("2021-05-01T11:04:33.250+05:30")
				}
			};
		}
	}
}
