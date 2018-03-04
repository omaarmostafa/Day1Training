using Day1Training.APIServices.ServiceConnector;
using Day1Training.Helpers;
using Day1Training.Model;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace Day1Training.ViewModels
{
   public class LoginViewModel :ViewModelBase, INavigatedAware
    {
        public LoginViewModel(INavigationService navigationService, ILoginService loginService, ICarService carService, IRegisterService registerService, IPageDialogService pageDialogService) : base(navigationService, loginService, carService, registerService, pageDialogService)
        {
            LoginCommand = new DelegateCommand(async () => await Login());
        }
        public override void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
          //   UserName =(string) parameters[AppConstants.UserNameKey];
          //  Password = (string)parameters[AppConstants.PasswordKey];
          
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                SetProperty(ref _UserName, value);
            }
        }


        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { SetProperty(ref _IsLoading, value); }
        }


        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                SetProperty(ref _Password, value);
            }
        }

        private DelegateCommand logincommand;
        public DelegateCommand LoginCommand
        {
            get { return this.logincommand; }
            set { SetProperty(ref logincommand, value); }
        }


       public async Task Login()
        {

            if (NetworkCheck.IsInternet())
            {
            
                IsLoading = true;
                var response = await loginService.Login(UserName, Password);
                var result = response.ResponseObject as UserAccount;
                if (response.Success)
                {
                    IsLoading = false;

                    AccessTokenSingleton.Instance.AccessToken = result.AccessToken;
                    await NavigationService.NavigateAsync("Cars");
                }
                else
                {
                    if (response.ErrorObject != null)
                    {
                      //  await pageDialogService.DisplayAlertAsync(response.ErrorObject.Message, "", "ok", "");
                    }
                }
            }
        }

    }
}
