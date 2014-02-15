using meetme.Entities;
using Meetme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace meetme.Controllers
{
    public class StateController : ApiController
    {
        private MeetmeContext dbModel = new MeetmeContext();

        [HttpGet]
        public List<State> GetFeed(Guid id)
        {
            User user = dbModel.Users.FirstOrDefault(w => w.id.Equals(id));
            List<State> feed = dbModel.States.Where(w=> user.following.Contains(w.UserId.id)).ToList();
            if (feed != null)
            {
                return feed;
            }
            return null;
        }

        [HttpPost]
        public bool AddState(State state)
        {
            try
            {
                dbModel.States.Add(state);
                dbModel.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}