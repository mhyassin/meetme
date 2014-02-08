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

        // GET api/user/5
        public string Get(Guid id)
        {
            User user = dbModel.Users.FirstOrDefault(w => w.id.Equals(id));
            if (user != null)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(user);
            }
            return "null";
        }

        // POST api/user
        public string Post([FromBody]string email, [FromBody]string token)
        {
            List<User> user = dbModel.Users.Where(w => w.email.Equals(email) && w.password.Equals(token)).ToList();
            if (user.Count > 0)
            {
                return user[0].id.ToString();
            }
            return "false";
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}