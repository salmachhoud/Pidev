using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ActivationToken)
                .HasMaxLength(255);

            this.Property(t => t.PasswordAnswer)
                .HasMaxLength(255);

            this.Property(t => t.PasswordQuestion)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(256);

            this.Property(t => t.SecurityStamp)
                .HasMaxLength(255);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(255);

            this.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ActivationToken).HasColumnName("ActivationToken");
            this.Property(t => t.PasswordAnswer).HasColumnName("PasswordAnswer");
            this.Property(t => t.PasswordQuestion).HasColumnName("PasswordQuestion");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}
