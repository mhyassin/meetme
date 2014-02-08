using meetme.Entities;
using Meetme.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Meetme.Models
{
    public class MeetmeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Jokes.Models.JokesContext>());

        public MeetmeContext()
            : base("name=MeetmeContext")
        {
            Database.Connection.ConnectionString = "MeetmeContext";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MeetmeContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        
    }
}
