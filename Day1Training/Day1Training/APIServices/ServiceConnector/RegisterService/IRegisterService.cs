using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices.ServiceConnector
{
   public interface IRegisterService
    {
        Task<ServiceResponse> Register(string username, string password,string ConfirmPassword);
    }
}
