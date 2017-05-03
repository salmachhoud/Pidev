using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class userroleMap : EntityTypeConfiguration<userrole>
    {
        public userroleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.RoleId });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("userrole");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
        }
    }
}
