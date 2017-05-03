using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class challengeMap : EntityTypeConfiguration<challenge>
    {
        public challengeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Name)
                .HasMaxLength(1073741823);

            // Table & Column Mappings
            this.ToTable("challenge");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.reward_id).HasColumnName("reward_id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.BeginDate).HasColumnName("BeginDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
        }
    }
}
