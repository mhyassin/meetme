using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meetme.Entities
{
    public class User
    {
        public Guid id { set; get; }
        public string name { set; get; }
        public string image { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public int noOfMeetings { set; get; }
        public bool isOfficial { set; get; }
        public List<Guid> following { set; get; }
        public List<Guid> followers { set; get; }
        public List<Guid> mayorships { set; get; }
    }
}
