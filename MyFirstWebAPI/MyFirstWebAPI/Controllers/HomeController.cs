using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebAPI.Controllers
{
    //../api/Home
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private string[] _S = { "apple", "orange", "banana" };
        //...api/Home
        [HttpGet]
        public string[] Get()
        {
            return _S;
        }

        //...api/Home/{id}
        [HttpGet]
        [Route("{id}")]
        public string GetById(int id)
        {
            return _S[id];
        }

        //...api/Home/exists/{name}
        // returns a bool if the item exists in the string
        [HttpGet]
        [Route("exists/{name}")]
        public bool Get(string name)
        {
            return _S.Contains(name);
        }

        //...api/Home/{value}
        //adds an item to the list
        [HttpPost]
        [Route("{value}")]
        public IEnumerable<string> Post(string value)
        {
            List<string> listString = new List<string>(); // new list to store array string values
            
            foreach(var sValue in _S)
            {
                listString.Add(sValue);
            }
            listString.Add(value); // add string to array
            this._S = listString.ToArray();

            return _S;
        } 
    }
}
