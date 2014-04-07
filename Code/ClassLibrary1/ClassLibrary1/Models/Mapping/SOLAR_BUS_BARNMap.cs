using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class SOLAR_BUS_BARNMap : EntityTypeConfiguration<SOLAR_BUS_BARN>
    {
        public SOLAR_BUS_BARNMap()
        {
            // Primary Key
            this.HasKey(t => t.SolarBusBarnID);

            // Properties
            // Table & Column Mappings
            this.ToTable("SOLAR_BUS_BARN");
            this.Property(t => t.SolarBusBarnID).HasColumnName("SolarBusBarnID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
