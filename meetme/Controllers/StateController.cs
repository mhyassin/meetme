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
            List<State> feed = dbModel.States.Where(w=> user.following.Contains(w.UserId.id) || user.following.Contains(w.OtherUserId.id)).ToList();
            if (feed != null)
            {
                return feed;
            }
            return null;
        }

        [HttpGet]
        public List<State> GetFeedforUser(Guid id)
        {
            User user = dbModel.Users.FirstOrDefault(w => w.id.Equals(id));
            List<State> feed = dbModel.States.Where(w => user.following.Contains(w.UserId.id) || user.following.Contains(w.OtherUserId.id)).ToList();
            if (feed != null)
            {
                return feed;
            }
            return null;
        }

        [HttpPost]
        public bool AddState(State state)
        {
            State test = new State();
            test.id = Guid.NewGuid();

            User firstuser = dbModel.Users.FirstOrDefault(w => w.id.Equals(state.UserId.id));
            if (state.OtherUserId != null)
            {
                User seconduser = dbModel.Users.FirstOrDefault(w => w.id.Equals(state.UserId.id));
                test.OtherUserId = seconduser;
            }
            else
            {
                MeetingRoom room = dbModel.MeetingRooms.FirstOrDefault(w => w.id.Equals(state.RoomId.id));
                test.RoomId = room;
            }

            test.UserId = firstuser;
            test.isRoom = state.OtherUserId == null ? true : false;
            test.isOfficial = state.OtherUserId == null ? true : false;
            test.startDate = DateTime.UtcNow;
            test.duration = 0;
            
            try
            {
                dbModel.States.Add(test);
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