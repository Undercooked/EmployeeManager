using AutoMapper;
using EmployeeManager.UI.Mappers;
using EmployeeManager.UI.Repository;
using EmployeeManager.UI.Service;
using EmployeeManager.UI.View.UserViews;
using Ninject.Modules;

namespace EmployeeManager.UI.Startup
{
	internal class ContainerModule : NinjectModule
	{
		public override void Load()
		{
			Bind<MainWindow>().ToSelf();
			Bind<UsersPage>().ToSelf();

			Bind<IUserService>().To<UserService>();

			Bind<IUserRepository>().To<UserRestRepository>().InSingletonScope();

			Bind<IMapper>().ToConstant(new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<UserMapper>();
			}).CreateMapper());
		}
	}
}
