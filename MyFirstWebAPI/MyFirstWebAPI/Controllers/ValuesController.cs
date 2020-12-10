using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebAPI.Controllers
{   //...api/values
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            IEnumerable<string> vals = Get();
            return vals.ToArray<string>()[id];
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            bool isNum = Int32.TryParse(value, out int num);
            if (isNum)
            {
                IEnumerable<string> vals = Get();
                vals.ToList().Add(value);
                return "POST method value is: " + value;
            }

            return null;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
