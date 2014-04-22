using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EnvironmentalApp.Core.Models;


namespace EnvironmentalApp.Data.SQLServer.Mapping
{
    public class WIND_SUM_BY_DAYMap : EntityTypeConfiguration<WindDailyTotals>
    {
        public WIND_SUM_BY_DAYMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("WIND_SUM_BY_DAY");
            this.Property(t => t.Id).HasColumnName("WindSumByDayID");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.DailySum).HasColumnName("DailySum");
            this.Property(t => t.DailyAverage).HasColumnName("DailyAverage");
            this.Property(t => t.HighValue).HasColumnName("HighValue");
            this.Property(t => t.LowValue).HasColumnName("LowValue");
        }
    }
}
