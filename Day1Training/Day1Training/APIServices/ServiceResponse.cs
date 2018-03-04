using Day1Training.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices
{

    /// <summary>
    /// ServiceResponse is a class to recive the response from the service
    /// </summary>
    public class ServiceResponse
    {
        public bool Success { get; set; } 
        public Error ErrorObject { get; set; }
        public object ResponseObject { get; set; }
    }

 

}
