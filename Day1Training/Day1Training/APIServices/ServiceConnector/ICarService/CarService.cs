using Day1Training.Helpers;
using Day1Training.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices.ServiceConnector
{
    public class CarService : ICarService
    {

        #region Fields 
        public IServiceManager _serviceManager;
        #endregion


        #region CTR
        public CarService(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        #endregion

        #region Methods
        public async Task<ServiceResponse> GetCarById(int Id)
        {
            var response = await _serviceManager.GetData<Car>(String.Format(AppConstants.GetCarById, Id), AccessTokenSingleton.Instance.AccessToken);
            return response;
        }

        public async Task<ServiceResponse> GetCars()
        {
            var response = await _serviceManager.GetData<List<Car>>(String.Format(AppConstants.GetCars), AccessTokenSingleton.Instance.AccessToken);
            return response;
        }
        #endregion
    }
}
