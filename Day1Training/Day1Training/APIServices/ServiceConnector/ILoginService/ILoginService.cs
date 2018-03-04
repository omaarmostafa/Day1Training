using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices.ServiceConnector
{
   public interface ILoginService
    {
        Task<ServiceResponse> Login(string username, string password);
    }
}
