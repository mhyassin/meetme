using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meetme.Entities
{
    public class MeetingRoom
    {
        public Guid id { set; get; }
        public double longitude { set; get; }
        public double latitude { set; get; }
        public string name { set; get; }
        public string image { set; get; }
        public string mayorId { set; get; }
        public bool isOfficial { set; get; }
        public int noOfMeetings { set; get; }
    }
}
