using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopAPI.Errors
{
    public class ValidationErrorResponce : ApiResponce
    {
        public ValidationErrorResponce() : base(400)
        {
        } 
        public IEnumerable<string> Errors { get; set; } 
    }
}
