using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.Helpers
{
    /// <summary>
    /// singleton instanse to hold the access token
    /// </summary>
    public class AccessTokenSingleton
    {
         
        private static AccessTokenSingleton instance;

        private AccessTokenSingleton() { } 

        public static AccessTokenSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccessTokenSingleton();
                }
                return instance;
            }
        }
        public string AccessToken { get; set; }
    }
}
