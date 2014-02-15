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
        [HttpGet]
        public string GetUser(Guid id)
        {
            User user = dbModel.Users.FirstOrDefault(w => w.id.Equals(id));
            if (user != null)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(user);
            }
            return "null";
        }

        [HttpPost]
        // POST api/user
        public string Login(User test)
        {
            List<User> user = dbModel.Users.Where(w => w.email.Equals(test.email) && w.password.Equals(test.password)).ToList();
            if (user.Count > 0)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(user[0]);
            }
            return "false";
        }

        [HttpPost]
        public string Register(User test)
        {
            List<User> users = dbModel.Users.Where(w => w.email.Equals(test.email)).ToList();
            if (users.Count > 0)
            {
                return "Already Registered";
            }
            User user = new User();
            user.id = Guid.NewGuid();
            user.name = test.name;
            user.image = test.image;
            user.email = test.email;
            user.password = test.password;
            user.noOfMeetings = 0;
            user.isOfficial = false;
            user.following = new List<Guid>();
            user.followers = new List<Guid>();
            user.mayorships = new List<Guid>();
            try
            {
                dbModel.Users.Add(user);
                dbModel.SaveChanges();
                return "true";
            }
            catch (Exception e)
            {
                return "false";
            }
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