using Day1Training.APIServices;
using Day1Training.ViewModels;
using Day1Training.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Day1Training.APIServices.ServiceConnector;
using Xamarin.Forms.Xaml;
using Day1Training.SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Day1Training
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/Register");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage,MainPageViewModel>();
            Container.RegisterTypeForNavigation<Register, RegisterViewModel>();
            Container.RegisterTypeForNavigation<Login, LoginViewModel>();
            Container.RegisterTypeForNavigation<Cars, CarsViewModel>();
            Container.RegisterTypeForNavigation<StudentDetails, StudentDetailsViewModel>();

            Container.RegisterType<IServiceManager, ServiceManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRegisterService, RegisterService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILoginService, LoginService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICarService, CarService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDataAccess, DataAccess>(new ContainerControlledLifetimeManager());
        }
    }
}
