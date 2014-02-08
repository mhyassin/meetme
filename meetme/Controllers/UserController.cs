using meetme.Entities;
using Meetme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace meetme.Controllers
{
    public class UserController : ApiController
    {
        private MeetmeContext dbModel = new MeetmeContext();
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]string email, [FromBody]string token)
        {
            List<User> user = dbModel.Users.Where(w => w.email.Equals(email) && w.password.Equals(token)).ToList();
            if (user.Count > 0)
            {
                return "true";
            }
            return "false";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}