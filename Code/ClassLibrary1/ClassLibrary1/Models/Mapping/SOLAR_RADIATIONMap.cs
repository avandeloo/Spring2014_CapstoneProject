using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class SOLAR_RADIATIONMap : EntityTypeConfiguration<SOLAR_RADIATION>
    {
        public SOLAR_RADIATIONMap()
        {
            // Primary Key
            this.HasKey(t => t.Solar_RadiationID);

            // Properties
            // Table & Column Mappings
            this.ToTable("SOLAR_RADIATION");
            this.Property(t => t.Solar_RadiationID).HasColumnName("Solar_RadiationID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
