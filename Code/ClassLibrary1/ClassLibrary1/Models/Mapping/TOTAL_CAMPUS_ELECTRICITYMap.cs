using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class TOTAL_CAMPUS_ELECTRICITYMap : EntityTypeConfiguration<TOTAL_CAMPUS_ELECTRICITY>
    {
        public TOTAL_CAMPUS_ELECTRICITYMap()
        {
            // Primary Key
            this.HasKey(t => t.TotalCampusElectricityID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TOTAL_CAMPUS_ELECTRICITY");
            this.Property(t => t.TotalCampusElectricityID).HasColumnName("TotalCampusElectricityID");
            this.Property(t => t.Reading).HasColumnName("Reading");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.ReadingDateTime).HasColumnName("ReadingDateTime");
            this.Property(t => t.TimeStep).HasColumnName("TimeStep");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
