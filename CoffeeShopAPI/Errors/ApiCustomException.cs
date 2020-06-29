using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopAPI.Errors
{
    public class ApiCustomException : ApiResponce
    {
        public ApiCustomException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
