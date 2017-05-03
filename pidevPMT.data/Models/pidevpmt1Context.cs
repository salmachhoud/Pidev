using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using pidevPMT.data.Models.Mapping;
using pidevPMT.domain.Entities;

namespace pidevPMT.data.Models
{
    public partial class pidevpmt1Context : DbContext
    {
        static pidevpmt1Context()
        {
            Database.SetInitializer<pidevpmt1Context>(null);
        }

        public pidevpmt1Context()
            : base("Name=pidevpmt1Context")
        {
        }

        public DbSet<categorymeeting> categorymeeting { get; set; }
        public DbSet<certification> certification { get; set; }
        public DbSet<challenge> challenge { get; set; }
        public DbSet<course> course { get; set; }
        public DbSet<document> document { get; set; }
        public DbSet<eventproject> eventproject { get; set; }
        public DbSet<meeting> meeting { get; set; }
        public DbSet<project> project { get; set; }
        public DbSet<report> report { get; set; }
        public DbSet<reservation> reservation { get; set; }
        public DbSet<reward> reward { get; set; }
        public DbSet<role> role { get; set; }
        public DbSet<sponsor> sponsor { get; set; }
        public DbSet<task> task { get; set; }
        public DbSet<trainingsession> trainingsession { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<userclaim> userclaim { get; set; }
        public DbSet<userlogin> userlogin { get; set; }
        public DbSet<userrole> userrole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new categorymeetingMap());
            modelBuilder.Configurations.Add(new certificationMap());
            modelBuilder.Configurations.Add(new challengeMap());
            modelBuilder.Configurations.Add(new courseMap());
            modelBuilder.Configurations.Add(new documentMap());
            modelBuilder.Configurations.Add(new eventprojectMap());
            modelBuilder.Configurations.Add(new meetingMap());
            modelBuilder.Configurations.Add(new projectMap());
            modelBuilder.Configurations.Add(new reportMap());
            modelBuilder.Configurations.Add(new reservationMap());
            modelBuilder.Configurations.Add(new rewardMap());
            modelBuilder.Configurations.Add(new roleMap());
            modelBuilder.Configurations.Add(new sponsorMap());
            modelBuilder.Configurations.Add(new taskMap());
            modelBuilder.Configurations.Add(new trainingsessionMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Configurations.Add(new userclaimMap());
            modelBuilder.Configurations.Add(new userloginMap());
            modelBuilder.Configurations.Add(new userroleMap());
        }
    }
}
