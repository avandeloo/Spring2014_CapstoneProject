using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class OUTSIDE_HUMIDITYMap : EntityTypeConfiguration<OUTSIDE_HUMIDITY>
    {
        public OUTSIDE_HUMIDITYMap()
        {
            // Primary Key
            this.HasKey(t => t.OutsideHumidityID);

            // Properties
            // Table & Column Mappings
            this.ToTable("OUTSIDE_HUMIDITY");
            this.Property(t => t.OutsideHumidityID).HasColumnName("OutsideHumidityID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
