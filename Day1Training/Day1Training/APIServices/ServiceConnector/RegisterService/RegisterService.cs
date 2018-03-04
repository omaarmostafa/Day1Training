using Day1Training.Helpers;
using Day1Training.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices.ServiceConnector
{
    class RegisterService : IRegisterService
    {
        #region Fields 
        public IServiceManager _serviceManager;
        #endregion


        #region CTR
        public RegisterService(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        #endregion

        #region Methods

        public async Task<ServiceResponse> Register(string username, string password, string ConfirmPassword)
        {

            Dictionary<string, string> credentials = new Dictionary<string, string>();
            credentials.Add(AppConstants.Email, username);
            credentials.Add(AppConstants.PasswordKey, password);
            credentials.Add(AppConstants.ConfirmPassword, ConfirmPassword);
            var response = await _serviceManager.PostData<UserAccount>(AppConstants.Register, credentials);
            return response;
        }

        #endregion
    }
}
