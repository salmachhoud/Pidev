using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class trainingsessionMap : EntityTypeConfiguration<trainingsession>
    {
        public trainingsessionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("trainingsession");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.enddate).HasColumnName("enddate");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.startdate).HasColumnName("startdate");
            this.Property(t => t.teamnumber).HasColumnName("teamnumber");
        }
    }
}
