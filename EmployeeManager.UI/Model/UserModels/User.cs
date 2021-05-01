using System;
using Newtonsoft.Json;

namespace EmployeeManager.UI.Models.UserModels
{
	public class User
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Email { get; set; }
		
		public Gender Gender { get; set; }
		
		public UserStatus Status { get; set; }
		
		[JsonProperty("created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTimeOffset UpdatedAt { get; set; }
	}
}
