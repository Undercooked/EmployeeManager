using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using EmployeeManager.UI.Model.UserModels;
using EmployeeManager.UI.ViewModel.UserViewModels;

namespace EmployeeManager.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private const int initialPageNumber = 1;

		private readonly IUserRepository userRepository;
		private readonly IMapper mapper;
		private readonly IUserExportService userExportService;

		public MainWindow(IUserRepository userRepository, IMapper mapper, IUserExportService userExportService)
		{
			InitializeComponent();

			this.userRepository = userRepository;
			this.mapper = mapper;
			this.userExportService = userExportService;

			currentPageTextBlock.DataContext = initialPageNumber;

			userDataGrid.Loaded += new RoutedEventHandler(OnUserDataGridLoadedAsync);
			searchTextBox.TextChanged += new TextChangedEventHandler(OnSearchTextBoxChangedAsync);
			searchButton.Click += new RoutedEventHandler(OnSearchButtonClickedAsync);
			exportButton.Click += new RoutedEventHandler(OnExportButtonClickedAsync);
			previousButton.Click += new RoutedEventHandler(OnPreviousButtonClickedAsync);
			nextButton.Click += new RoutedEventHandler(OnNextButtonClickedAsync);
		}

		private async void OnUserDataGridLoadedAsync(object sender, RoutedEventArgs e)
		{
			var usersResponse = await userRepository.GetUsersAsync(null, initialPageNumber);
			SetUserData(usersResponse);
		}

		private async void OnSearchTextBoxChangedAsync(object sender, RoutedEventArgs e)
		{
			searchButton.IsEnabled = !string.IsNullOrEmpty(searchTextBox.Text);
		}

		private async void OnSearchButtonClickedAsync(object sender, RoutedEventArgs e)
		{
			var usersResponse = await userRepository.GetUsersAsync(searchTextBox.Text, 1);
			SetUserData(usersResponse);
		}

		private async void OnExportButtonClickedAsync(object sender, RoutedEventArgs e)
		{
			exportButton.IsEnabled = false;

			await userExportService.ExportAllUsers();

			exportButton.IsEnabled = true;
		}

		private async void OnPreviousButtonClickedAsync(object sender, RoutedEventArgs e)
		{
			previousButton.IsEnabled = false;
			nextButton.IsEnabled = false;

			var page = (int)currentPageTextBlock.DataContext;

			var usersResponse = await userRepository.GetUsersAsync(searchTextBox.Text, page - 1);
			SetUserData(usersResponse);
		}

		private async void OnNextButtonClickedAsync(object sender, RoutedEventArgs e)
		{
			previousButton.IsEnabled = false;
			nextButton.IsEnabled = false;

			var page = (int)currentPageTextBlock.DataContext;

			var usersResponse = await userRepository.GetUsersAsync(searchTextBox.Text, page + 1);
			SetUserData(usersResponse);
		}

		private void SetUserData(UsersResponse usersResponse)
		{
			var userViewModels = mapper.Map<IEnumerable<UserViewModel>>(usersResponse.Data);

			currentPageTextBlock.DataContext = usersResponse.Meta.Pagination.Page;
			userDataGrid.DataContext = userViewModels;
			SetPreviousButtonEnabledState(usersResponse.Meta.Pagination);
			SetNextButtonEnabledState(usersResponse.Meta.Pagination);
		}

		private void SetNextButtonEnabledState(PaginationResponse pagination)
		{
			nextButton.IsEnabled = pagination.Pages > pagination.Page;
		}

		private void SetPreviousButtonEnabledState(PaginationResponse pagination)
		{
			previousButton.IsEnabled = pagination.Page > 1;
		}
	}
}
