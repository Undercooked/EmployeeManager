using System.Windows;
using EmployeeManager.UI.Startup;
using Ninject;
using Ninject.Syntax;

namespace EmployeeManager.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly IResolutionRoot container;

		public App()
		{
			var containerModule = new ContainerModule();
			
			container = new StandardKernel(containerModule);
		}

		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = container.Get<MainWindow>();
			mainWindow.Show();
		}
	}
}
