using System.Collections.Generic;
using System.Net;

namespace EmployeeManager.UI.Model.UserModels
{
	public class UsersResponse
	{
		public HttpStatusCode Code { get; set; }

		public MetaResponse Meta { get; set; }

		public IEnumerable<UserResponse> Data { get; set; }
	}
}
