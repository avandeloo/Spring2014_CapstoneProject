using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class SOLAR_CAR_CHARGING_SUM_BY_DAYMap : EntityTypeConfiguration<SOLAR_CAR_CHARGING_SUM_BY_DAY>
    {
        public SOLAR_CAR_CHARGING_SUM_BY_DAYMap()
        {
            // Primary Key
            this.HasKey(t => t.SolarCarChargingSumByDayID);

            // Properties
            // Table & Column Mappings
            this.ToTable("SOLAR_CAR_CHARGING_SUM_BY_DAY");
            this.Property(t => t.SolarCarChargingSumByDayID).HasColumnName("SolarCarChargingSumByDayID");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.DailySum).HasColumnName("DailySum");
            this.Property(t => t.DailyAverage).HasColumnName("DailyAverage");
            this.Property(t => t.HighValue).HasColumnName("HighValue");
            this.Property(t => t.LowValue).HasColumnName("LowValue");
        }
    }
}
