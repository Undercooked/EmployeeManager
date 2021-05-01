using System.Collections.Generic;
using System.Windows;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IUserService userService;

		//private IEnumerable<UserViewModel> userData;

		public MainWindow(IUserService userService)
		{
			InitializeComponent();
		
			this.userService = userService;

			//userDataGrid.DataContext = userData;
			userDataGrid.Loaded += new RoutedEventHandler(OnUserDataGridLoaded);
		}

		private async void OnUserDataGridLoaded(object sender, RoutedEventArgs e)
		{
			userDataGrid.DataContext = await userService.GetUsersAsync();
		}
	}
}
