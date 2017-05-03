using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class userloginMap : EntityTypeConfiguration<userlogin>
    {
        public userloginMap()
        {
            // Primary Key
            this.HasKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });

            // Properties
            this.Property(t => t.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ProviderKey)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("userlogin");
            this.Property(t => t.LoginProvider).HasColumnName("LoginProvider");
            this.Property(t => t.ProviderKey).HasColumnName("ProviderKey");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
