using Day1Training.APIServices.ServiceConnector;
using Day1Training.Model;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.ViewModels
{
    public class StudentDetailsViewModel : ViewModelBase
    {
        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; RaisePropertyChanged("SelectedStudent"); }
        }

        public StudentDetailsViewModel(INavigationService navigationService, ILoginService loginService, ICarService carService, IRegisterService registerService, IPageDialogService pageDialogService) : base(navigationService, loginService, carService, registerService, pageDialogService)
        {
            
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            SelectedStudent = ((Student)parameters["_selectedStudent"]);
        }
    }
}
