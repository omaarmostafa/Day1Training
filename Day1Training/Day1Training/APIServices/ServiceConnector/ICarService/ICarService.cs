using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices.ServiceConnector
{
   public interface ICarService
    {
        Task<ServiceResponse> GetCars();
        Task<ServiceResponse> GetCarById(int Id);
    }

}
