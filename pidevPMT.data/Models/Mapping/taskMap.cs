using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class taskMap : EntityTypeConfiguration<task>
    {
        public taskMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("task");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NumberOfParticipants).HasColumnName("NumberOfParticipants");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.project_id).HasColumnName("project_id");
        }
    }
}
