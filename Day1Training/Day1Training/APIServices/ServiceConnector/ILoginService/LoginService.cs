using Day1Training.Helpers;
using Day1Training.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices.ServiceConnector
{
    public class LoginService : ILoginService
    {

        #region Fields 
        public IServiceManager _serviceManager;
        #endregion


        #region CTR
        public LoginService(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        #endregion

        public async Task<ServiceResponse> Login(string username, string password)
        {
            Dictionary<string, string> credentials = new Dictionary<string, string>();
            credentials.Add(AppConstants.UserNameKey, username);
            credentials.Add(AppConstants.PasswordKey, password);
            credentials.Add("grant_type", "password");
            var response = await _serviceManager.PostData<UserAccount>(AppConstants.AuthenticateLogin, credentials);
            return response;
        }
    }
}
