using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.Helpers
{

    /// <summary>
    /// Class to hold app constants and keys
    /// </summary>
   public class AppConstants
    {
         #region fields
        private static Dictionary<string, string> settingsCollection = null;
        public static string AuthenticateLogin = "Token";
        public static string Register = "api/Account/Register";
        public static string GetCarById = "api/Cars/{0}";
        public static string GetCars = "api/Cars";
        public static string UserNameKey = "userName";
        public static string Email = "Email";
        public static string PasswordKey = "password";
        public static string grant_type = "grant_type";
        public static string ConfirmPassword = "ConfirmPassword";

        public static string UnhandledException = "UnhandledException";
        public static string SerilizationExceptoin = "SerilizationExceptoin";
        public static string CantReadSettingfile = "CantReadSettingFile";
        public static string NoInternetConnection = "Please check your internet connection";
        public static string HttpRequestException = "HttpRequestException";
        public static string AccessToken = "accesstoken";
        public static string TokenValue;
        #endregion

         #region methods
        /// <summary>
        /// method to get setting item by its key from Dictionary collection
        /// </summary>
        /// <param name="settingkey"></param>
        /// <returns></returns>
        public static string GetSettingsItem(string settingkey)
        {
            if (settingsCollection == null)
            {
                settingsCollection = new Dictionary<string, string>();
                settingsCollection.Add("BaseURL", "http://asgatech-sampleapi.azurewebsites.net/");
            }

            if (settingsCollection.Keys.Contains(settingkey))
            {
                return settingsCollection[settingkey];
            }
            return string.Empty;
        }
        #endregion
    }
}
