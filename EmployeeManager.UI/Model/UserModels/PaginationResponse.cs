namespace EmployeeManager.UI.Model.UserModels
{
	public class PaginationResponse
	{
		public int Total { get; set; }
		
		public int Pages { get; set; }
		
		public int Page { get; set; }
		
		public int Limit { get; set; }
	}
}
