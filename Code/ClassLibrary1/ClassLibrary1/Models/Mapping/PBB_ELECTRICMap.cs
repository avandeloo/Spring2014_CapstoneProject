using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class PBB_ELECTRICMap : EntityTypeConfiguration<PBB_ELECTRIC>
    {
        public PBB_ELECTRICMap()
        {
            // Primary Key
            this.HasKey(t => t.PBB_ElectricID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PBB_ELECTRIC");
            this.Property(t => t.PBB_ElectricID).HasColumnName("PBB_ElectricID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
