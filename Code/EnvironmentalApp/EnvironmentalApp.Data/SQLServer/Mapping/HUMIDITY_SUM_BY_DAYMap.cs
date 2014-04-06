using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EnvironmentalApp.Core.Models;


namespace EnvironmentalApp.Data.SQLServer.Mapping
{
    public class HUMIDITY_SUM_BY_DAYMap : EntityTypeConfiguration<HumidityDailyTotals>
    {
        public HUMIDITY_SUM_BY_DAYMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("HUMIDITY_SUM_BY_DAY");
            this.Property(t => t.Id).HasColumnName("HumiditySumByDayID");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.DailySum).HasColumnName("DailySum");
            this.Property(t => t.DailyAverage).HasColumnName("DailyAverage");
            this.Property(t => t.HighValue).HasColumnName("HighValue");
            this.Property(t => t.LowValue).HasColumnName("LowValue");
        
        }
    }
}
