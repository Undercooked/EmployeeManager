using System;
using System.Text.Json.Serialization;

namespace EmployeeManager.UI.Model.UserModels
{
	public class UserResponse
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Email { get; set; }
		
		public Gender Gender { get; set; }
		
		public UserStatus Status { get; set; }
		
		[JsonPropertyName("created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTimeOffset UpdatedAt { get; set; }
	}
}
