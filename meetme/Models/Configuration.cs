using Meetme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Meetme.Models
{
    public class Configuration : DbMigrationsConfiguration<MeetmeContext>  
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}