using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class OUTSIDE_AIR_TEMPMap : EntityTypeConfiguration<OUTSIDE_AIR_TEMP>
    {
        public OUTSIDE_AIR_TEMPMap()
        {
            // Primary Key
            this.HasKey(t => t.OutsideAirTempID);

            // Properties
            // Table & Column Mappings
            this.ToTable("OUTSIDE_AIR_TEMP");
            this.Property(t => t.OutsideAirTempID).HasColumnName("OutsideAirTempID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
