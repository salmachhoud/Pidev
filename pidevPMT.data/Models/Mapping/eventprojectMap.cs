using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class eventprojectMap : EntityTypeConfiguration<eventproject>
    {
        public eventprojectMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("eventproject");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.title).HasColumnName("title");
        }
    }
}
