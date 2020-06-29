using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopAPI.Errors
{
    public class ApiResponce
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponce(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "You are not authorized",
                404 => "Not found",
                500 => "Dark side error",
                _ => null
            };
        }


    }
}
