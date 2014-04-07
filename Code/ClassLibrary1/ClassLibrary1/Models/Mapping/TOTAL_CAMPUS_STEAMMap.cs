using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class TOTAL_CAMPUS_STEAMMap : EntityTypeConfiguration<TOTAL_CAMPUS_STEAM>
    {
        public TOTAL_CAMPUS_STEAMMap()
        {
            // Primary Key
            this.HasKey(t => t.TotalCampusSteamID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TOTAL_CAMPUS_STEAM");
            this.Property(t => t.TotalCampusSteamID).HasColumnName("TotalCampusSteamID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
