using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class TC_ELECTRICITY_SUM_BY_DAYMap : EntityTypeConfiguration<TC_ELECTRICITY_SUM_BY_DAY>
    {
        public TC_ELECTRICITY_SUM_BY_DAYMap()
        {
            // Primary Key
            this.HasKey(t => t.TCElectricitySumByDayID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TC_ELECTRICITY_SUM_BY_DAY");
            this.Property(t => t.TCElectricitySumByDayID).HasColumnName("TCElectricitySumByDayID");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.DailySum).HasColumnName("DailySum");
            this.Property(t => t.DailyAverage).HasColumnName("DailyAverage");
            this.Property(t => t.HighValue).HasColumnName("HighValue");
            this.Property(t => t.LowValue).HasColumnName("LowValue");
        }
    }
}
