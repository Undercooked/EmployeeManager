using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.UI.Model.UserModels;
using EmployeeManager.UI.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeManager.UI.Tests.Service.UserExportServiceTests
{
	[TestClass]
	public class UserExportServiceTests
	{
		private Mock<IUserRepository> mockUserRepository;
		private Mock<IExportFormatService> mockExportFormatService;
		private UserExportService sut;

		[TestInitialize]
		public void TestInitialize()
		{
			mockUserRepository = new Mock<IUserRepository>();
			mockExportFormatService = new Mock<IExportFormatService>();

			sut = new UserExportService(mockUserRepository.Object, mockExportFormatService.Object);
		}

		[TestMethod]
		public async Task ExportAllUsersOrchestratesCorrectly()
		{
			var mockUsers = new List<UserResponse>();

			mockUserRepository.Setup(m => m.GetAllUsersAsync()).ReturnsAsync(mockUsers);
			mockExportFormatService.Setup(m => m.ExportRecordsAsync(mockUsers)).Returns(Task.CompletedTask);

			await sut.ExportAllUsers();

			Mock.VerifyAll(
				mockUserRepository,
				mockExportFormatService);
		}
	}
}
