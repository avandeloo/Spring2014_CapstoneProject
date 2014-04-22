using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Data.SQLServer.Mapping
{
    public class REPORTMap : EntityTypeConfiguration<Report>
    {
        public REPORTMap()
        {
            // Primary Key
            this.HasKey(t => t.ReportID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DataType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GraphStyle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GeneratedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Active)
                .IsRequired();

            this.Property(t => t.UpdatedBy)
              .IsRequired()
              .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("REPORT");
            this.Property(t => t.ReportID).HasColumnName("ReportID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.DataType).HasColumnName("DataType");
            this.Property(t => t.GraphStyle).HasColumnName("GraphStyle");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.GeneratedBy).HasColumnName("GeneratedBy");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
        }
    }
}
