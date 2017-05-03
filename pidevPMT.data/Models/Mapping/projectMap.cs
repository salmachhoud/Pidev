using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace pidevPMT.data.Models.Mapping
{
    public class projectMap : EntityTypeConfiguration<project>
    {
        public projectMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.category)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("project");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.category).HasColumnName("category");
            this.Property(t => t.cost).HasColumnName("cost");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.enddate).HasColumnName("enddate");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.numberofparticipants).HasColumnName("numberofparticipants");
            this.Property(t => t.startdate).HasColumnName("startdate");
        }
    }
}
