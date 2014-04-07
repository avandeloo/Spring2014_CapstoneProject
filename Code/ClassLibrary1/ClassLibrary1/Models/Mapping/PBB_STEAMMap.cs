using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class PBB_STEAMMap : EntityTypeConfiguration<PBB_STEAM>
    {
        public PBB_STEAMMap()
        {
            // Primary Key
            this.HasKey(t => t.PBB_SteamID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PBB_STEAM");
            this.Property(t => t.PBB_SteamID).HasColumnName("PBB_SteamID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
