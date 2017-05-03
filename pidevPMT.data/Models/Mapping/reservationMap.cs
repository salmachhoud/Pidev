using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class reservationMap : EntityTypeConfiguration<reservation>
    {
        public reservationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.title)
                .HasMaxLength(255);

            this.Property(t => t.username)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("reservation");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.eventproject_id).HasColumnName("eventproject_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
        }
    }
}
