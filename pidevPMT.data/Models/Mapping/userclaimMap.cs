using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class userclaimMap : EntityTypeConfiguration<userclaim>
    {
        public userclaimMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ClaimType)
                .HasMaxLength(255);

            this.Property(t => t.ClaimValue)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("userclaim");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ClaimType).HasColumnName("ClaimType");
            this.Property(t => t.ClaimValue).HasColumnName("ClaimValue");
        }
    }
}
