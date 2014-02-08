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
        public Guid UserId  { set; get; }
        public bool isRoom { set; get; }
        public bool isOfficial { set; get; }
        public Guid RoomId { set; get; }
        public Guid OtherUserId { set; get; }
        public DateTime startDate { set; get; }
        public double duration { set; get; }
    }
}
