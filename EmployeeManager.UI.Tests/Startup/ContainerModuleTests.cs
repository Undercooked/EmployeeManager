using EmployeeManager.UI.Startup;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Syntax;

namespace EmployeeManager.UI.Tests.Startup
{
	[TestClass]
	public class ContainerModuleTests
	{
		private IResolutionRoot sut;

		[TestInitialize]
		public void TestInitialize()
		{
			var containerModule = new ContainerModule();

			sut = new StandardKernel(containerModule);
		}

		[TestMethod]
		public void MainWindowResolvesCorrectly()
		{
			var mainWindow = sut.Get<MainWindow>();

			mainWindow.Should().NotBeNull();
		}
	}
}
