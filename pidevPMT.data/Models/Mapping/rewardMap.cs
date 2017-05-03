using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class rewardMap : EntityTypeConfiguration<reward>
    {
        public rewardMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(225);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(225);

            // Table & Column Mappings
            this.ToTable("reward");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
