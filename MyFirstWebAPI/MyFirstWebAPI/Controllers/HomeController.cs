using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebAPI.Controllers
{
    //../api/Home
    public class HomeController : ApiController
    {
        private string[] _S = { "apple", "orange", "banana" };
        //...api/Home
        public string[] Get()
        {
            return _S;  
        }

        //...api/Home/{id}
        public string Get(int id)
        {
            return _S[id];
        }

        //...api/Home/exists/{name}
        [Route("api/Home/exists/{name}")]
        public bool Get(string name)
        {
            return _S.Contains(name);
        }
    }
}
