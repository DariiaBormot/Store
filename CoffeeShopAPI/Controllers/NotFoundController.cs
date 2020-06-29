using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopAPI.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class NotFoundController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponce(code));
        }
    }
}