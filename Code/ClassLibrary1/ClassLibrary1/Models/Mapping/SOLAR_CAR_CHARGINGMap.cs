using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class SOLAR_CAR_CHARGINGMap : EntityTypeConfiguration<SOLAR_CAR_CHARGING>
    {
        public SOLAR_CAR_CHARGINGMap()
        {
            // Primary Key
            this.HasKey(t => t.SolarCarChargingID);

            // Properties
            // Table & Column Mappings
            this.ToTable("SOLAR_CAR_CHARGING");
            this.Property(t => t.SolarCarChargingID).HasColumnName("SolarCarChargingID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
