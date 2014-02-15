using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meetme.Entities
{
    public class State
    {
        public Guid id { set; get; }
        public User UserId { set; get; }
        public bool isRoom { set; get; }
        public bool isOfficial { set; get; }
        public MeetingRoom RoomId { set; get; }
        public User OtherUserId { set; get; }
        public DateTime startDate { set; get; }
        public double duration { set; get; }
    }
}
