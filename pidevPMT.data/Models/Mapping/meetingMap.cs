using pidevPMT.domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class meetingMap : EntityTypeConfiguration<meeting>
    {
        public meetingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Title)
                .HasMaxLength(255);
            HasOptional(p => p.categorymeeting)
              .WithMany(c => c.list)
              .HasForeignKey(p => p.CategoryID)
              .WillCascadeOnDelete(true);
            // Table & Column Mappings
            this.ToTable("meeting");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Private).HasColumnName("Private");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");


            HasMany(p => p.UsersM) //esm table lo5ra
.WithMany(v => v.meetingUser)
.Map(m =>
{
    m.ToTable("MeetingUser");   //esm Table d'association
                m.MapLeftKey("User");
    m.MapRightKey("Meeting");
});

        }
    }
}
