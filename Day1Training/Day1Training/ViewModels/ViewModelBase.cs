using Day1Training.APIServices.ServiceConnector;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected ILoginService  loginService { get; private set; }
        protected IPageDialogService pageDialogService  { get; private set; }

        protected IRegisterService  registerService { get; private set; }
        protected ICarService  carService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, ILoginService _loginService, ICarService _carService,IRegisterService _registerService, IPageDialogService _pageDialogService)
        {
            NavigationService = navigationService;
            loginService = _loginService;
            carService = _carService;
            registerService = _registerService;
            pageDialogService = _pageDialogService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
