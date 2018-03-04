using Day1Training.APIServices.ServiceConnector;
using Day1Training.Helpers;
using Day1Training.Model;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.ViewModels
{
    public class CarsViewModel:ViewModelBase
    {
        public CarsViewModel(INavigationService navigationService, ILoginService loginService, ICarService carService, IRegisterService registerService, IPageDialogService pageDialogService) : base(navigationService, loginService, carService, registerService, pageDialogService)
        {
             GetCars();
        }

        #region Proterties
        private List<Car> _CarsCollection;
        public List<Car> CarsCollection
        {
            get { return _CarsCollection; }
            set { SetProperty(ref _CarsCollection, value); }
        }

        


        private Car _SelectedCar;
        public Car SelectedCar
        {
            get { return _SelectedCar; }
            set { SetProperty(ref _SelectedCar, value);  if (value != null) { GetCarById(value.Id); } }
        }

        private Car _Car;
        public Car Car
        {
            get { return _Car; }
            set { SetProperty(ref _Car, value); }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { SetProperty(ref _IsLoading, value); }
        }


        #endregion


        #region Methods

        async Task GetCars()
        {
            if (NetworkCheck.IsInternet())
            {
                IsLoading = true;
                var response = await carService.GetCars();
                if (response.Success)
                {
                    IsLoading = false;
                    var result = response.ResponseObject as List<Car>;
                    CarsCollection = result;
                }
            }
        }

        async Task GetCarById( long Id)
        {
            if (NetworkCheck.IsInternet())
            {
                IsLoading = true;
                var response = await carService.GetCarById((int)Id);
                if (response.Success)
                {
                    IsLoading = false;
                    var result = response.ResponseObject as Car;
                    Car = result;
                }
            }
        }

        #endregion




    }
}
