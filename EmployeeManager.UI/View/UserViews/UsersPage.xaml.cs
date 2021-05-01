using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI.View.UserViews
{
	/// <summary>
	/// Interaction logic for Users.xaml
	/// </summary>
	public partial class UsersPage : Page
	{
		private readonly IUserService userService;
		
		private IEnumerable<UserViewModel> userData;

		public UsersPage()
		{

		}

		public UsersPage(IUserService userService)
		{
			InitializeComponent();

			this.userService = userService;

			userDataGrid.DataContext = userData;
			userDataGrid.Loaded += new RoutedEventHandler(OnUserDataGridLoaded);
		}

		private async void OnUserDataGridLoaded(object sender, RoutedEventArgs e)
		{
			userData = await userService.GetUsersAsync();
		}
	}
}
