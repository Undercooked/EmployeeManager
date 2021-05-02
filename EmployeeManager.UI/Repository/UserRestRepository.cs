using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.UI.Model.UserModels;

namespace EmployeeManager.UI.Repository
{
	internal class UserRestRepository : IUserRepository
	{
		private const string usersUriString = "https://gorest.co.in/public-api/users";

		private readonly IRestService restService;

		public UserRestRepository(IRestService restService)
		{
			this.restService = restService;
		}

		public async Task<UsersResponse> GetUsersAsync(int page)
		{
			var uriBuilder = new UriBuilder(usersUriString)
			{
			};

			return await restService.PerformGetRequestAsync<UsersResponse>(uriBuilder.Uri);
		}

		public async Task<UsersResponse> GetUsersAsync(string searchTerm, int page)
		{
			var queryStringBuilder = new StringBuilder($"page={page}");

			if (!string.IsNullOrEmpty(searchTerm))
			{
				queryStringBuilder.Append($"&name={searchTerm}");
			}

			var uriBuilder = new UriBuilder(usersUriString)
			{
				Query = queryStringBuilder.ToString()
			};

			return await restService.PerformGetRequestAsync<UsersResponse>(uriBuilder.Uri);
		}

		public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
		{
			var userResponses = new List<UserResponse>();
			var page = 1;
			PaginationResponse pagination;

			do
			{
				var usersResponse = await GetUsersAsync(page).ConfigureAwait(false);

				pagination = usersResponse.Meta.Pagination;
				userResponses.AddRange(usersResponse.Data);
			}
			while (page++ < pagination.Pages);

			return userResponses;
		}
	}
}
