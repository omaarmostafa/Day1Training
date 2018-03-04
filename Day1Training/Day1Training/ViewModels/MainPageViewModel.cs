using Day1Training.APIServices.ServiceConnector;
using Day1Training.Model;
using Day1Training.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Day1Training.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
       
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        ITextToSpeech _textToSpeech;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; RaisePropertyChanged("Students");  }
        }

        public MainPageViewModel(INavigationService navigationService,ITextToSpeech textToSpeech, ILoginService loginService, ICarService carService, IRegisterService registerService, IPageDialogService pageDialogService) : base(navigationService, loginService, carService, registerService, pageDialogService)
        {

            _textToSpeech = textToSpeech;
            if (Device.RuntimePlatform == Device.Android)
            {


                Title = "Android";
                Students.Add(new Student() { Id = 0, IsGreen=false, Name = "Peter", Grade = "One" });
                Students.Add(new Student() { Id = 2, IsGreen = true, Name = "Micheal", Grade = "two" });
                Students.Add(new Student() { Id = 3, IsGreen = false, Name = "Sara", Grade = "Three" });
                Students.Add(new Student() { Id = 0, IsGreen = false, Name = "Peter", Grade = "One" });
                Students.Add(new Student() { Id = 2, IsGreen = true, Name = "Micheal", Grade = "two" });
                Students.Add(new Student() { Id = 3, IsGreen = false, Name = "Sara", Grade = "Three" });
                Students.Add(new Student() { Id = 0, IsGreen = false, Name = "Peter", Grade = "One" });
                Students.Add(new Student() { Id = 2, IsGreen = true, Name = "Micheal", Grade = "two" });
                Students.Add(new Student() { Id = 3, IsGreen = false, Name = "Sara", Grade = "Three" });
            }
            else if(Device.RuntimePlatform==Device.UWP)
            {
                Title = "Windows";
                Students.Add(new Student() { Id = 0, IsGreen = true, Name = "Ahmed", Grade = "One" });
                Students.Add(new Student() { Id = 2,IsGreen=false, Name = "Mohamed", Grade = "two" });
                Students.Add(new Student() { Id = 3, IsGreen = true, Name = "Hassan", Grade = "Three" });
                Students.Add(new Student() { Id = 0, IsGreen = true, Name = "Ahmed", Grade = "One" });
                Students.Add(new Student() { Id = 2, IsGreen = false, Name = "Mohamed", Grade = "two" });
                Students.Add(new Student() { Id = 3, IsGreen = true, Name = "Hassan", Grade = "Three" });
                Students.Add(new Student() { Id = 0, IsGreen = true, Name = "Ahmed", Grade = "One" });
                Students.Add(new Student() { Id = 2, IsGreen = false, Name = "Mohamed", Grade = "two" });
                Students.Add(new Student() { Id = 3, IsGreen = true, Name = "Hassan", Grade = "Three" });
            }
        }

        private Student _SelectedStudent;

        public Student SelectedStudent
        {
            get { return _SelectedStudent; }
            set { SetProperty(ref _SelectedStudent, value); RaisePropertyChanged("SelectedStudent");
                Execute(value.Name);

            }
        }

        private void Execute(string _txt)
        {
            _textToSpeech.Speak(_txt);
           // DependencyService.Get<ITextToSpeech>().Speak(_txt);
            NavigationService.NavigateAsync("StudentDetails");
            //var _Par = new NavigationParameters();
            //_Par.Add("_selectedStudent", SelectedStudent);
            //NavigationService.NavigateAsync("StudentDetails", _Par);
        }

    }
}
