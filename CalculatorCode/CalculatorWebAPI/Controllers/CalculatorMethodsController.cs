using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.Controllers
{
    [ApiController]
    public class CalculatorMethodsController : ControllerBase
    {
        [HttpGet("api/getMethods")]
        public JsonResult GetMethods()
        {
            return new JsonResult(
                new List<object>()
                {
                    new {id=1, Name="Add"},
                    new {id=2, Name="Sub"},
                    new {id=3, Name="Mult"},
                    new {id=4, Name="Div"}
                });
        }

        [HttpPost("api/PerformAdd/{a}/{b}")]
        [HttpPost("api/1/{a}/{b}")]
        public int PerformAdd(int a, int b)
        {
            return a + b;
        }

        [HttpPost("api/PerformSub/{a}/{b}")]
        [HttpPost("api/2/{a}/{b}")]
        public int PerformSub(int a, int b)
        {
            return a - b;
        }

        [HttpPost("api/PerformMult/{a}/{b}")]
        [HttpPost("api/3/{a}/{b}")]
        public int PerformMult(int a, int b)
        {
            return a * b;
        }

        [HttpPost("api/PerformDiv/{a}/{b}")]
        [HttpPost("api/4/{a}/{b}")]
        public int PerformDiv(int a, int b)
        {
            return a / b;
        }
    }
}
