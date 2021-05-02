using System.Threading.Tasks;

namespace EmployeeManager.UI.Service
{
	internal class UserExportService : IUserExportService
	{
		private readonly IUserRepository userRepository;
		private readonly IExportFormatService exportFormatService;

		public UserExportService(IUserRepository userRepository, IExportFormatService exportFormatService)
		{
			this.userRepository = userRepository;
			this.exportFormatService = exportFormatService;
		}

		public async Task ExportAllUsers()
		{
			var allUsers = await userRepository.GetAllUsersAsync().ConfigureAwait(false);

			await exportFormatService.ExportRecordsAsync(allUsers).ConfigureAwait(false);
		}
	}
}
