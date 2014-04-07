using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class TOTAL_CAMPUS_CHILLED_WATERMap : EntityTypeConfiguration<TOTAL_CAMPUS_CHILLED_WATER>
    {
        public TOTAL_CAMPUS_CHILLED_WATERMap()
        {
            // Primary Key
            this.HasKey(t => t.TotalCampusChilledWaterID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TOTAL_CAMPUS_CHILLED_WATER");
            this.Property(t => t.TotalCampusChilledWaterID).HasColumnName("TotalCampusChilledWaterID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
