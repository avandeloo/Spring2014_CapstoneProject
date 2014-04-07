using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class PBB_CHILLED_WATERMap : EntityTypeConfiguration<PBB_CHILLED_WATER>
    {
        public PBB_CHILLED_WATERMap()
        {
            // Primary Key
            this.HasKey(t => t.PBB_ChilledWaterID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PBB_CHILLED_WATER");
            this.Property(t => t.PBB_ChilledWaterID).HasColumnName("PBB_ChilledWaterID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
