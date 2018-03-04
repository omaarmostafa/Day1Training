using Day1Training.APIServices.ServiceConnector;
using Day1Training.Helpers;
using Day1Training.Model;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Day1Training.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        #region Properties

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { SetProperty(ref _ConfirmPassword, value); }
        }
        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { SetProperty(ref _IsLoading, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand _Regsitercommand;
        public DelegateCommand Regsitercommand
        {
            get { return this._Regsitercommand; }
            set { SetProperty(ref _Regsitercommand, value); }
        }

        //public ICommand Regsitercommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            await Regiter();
        //        });
        //    }
        //}

        #endregion

        public RegisterViewModel(INavigationService navigationService, ILoginService loginService, ICarService carService, IRegisterService registerService, IPageDialogService pageDialogService) : base(navigationService, loginService, carService, registerService, pageDialogService)
        {
            Regsitercommand = new DelegateCommand(async()=> await RegisterVM());
        }

        public async Task RegisterVM()
        {

            if (NetworkCheck.IsInternet())
            {

                IsLoading = true;
                var response = await registerService.Register(UserName, Password, ConfirmPassword);
                if (response.Success)
                {
                    IsLoading = false;
                    var result = response.ResponseObject as UserAccount;

                    // AccessTokenSingleton.Instance.AccessToken = result.AccessToken;
                    var parameter = new NavigationParameters();
                    parameter.Add(AppConstants.UserNameKey, UserName);
                    parameter.Add(AppConstants.PasswordKey, Password);
                    await NavigationService.NavigateAsync("Login", parameter);
                }
                else
                {
                    await pageDialogService.DisplayAlertAsync(response.ErrorObject.Message, "", "Ok", "Cancel");
                }
            }

        }

     


      


   
    }
}
