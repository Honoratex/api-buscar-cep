using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuscarCepApi.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get(string login, string senha)
        {
            string usuario = ConfigurationManager.AppSettings["usuario"];
            string password = ConfigurationManager.AppSettings["password"];

            if (login == usuario && senha == password)
            {
                return new string[] { "true"};
            }
            else
            {
                return new string[] { "false" };
            }


            //var loginA = "felipe";

            //var senhaA = "1234";

            //if (login == loginA && senha == senhaA)
            //{
            //    return new string[] { "true" };
            //}
            //else
            //{
            //    return new string[] { "false" };
            //}
               
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
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
