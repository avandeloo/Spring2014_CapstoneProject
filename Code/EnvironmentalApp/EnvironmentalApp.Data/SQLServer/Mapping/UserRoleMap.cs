using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Data.SQLServer.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.HawkId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserRole");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.HawkId).HasColumnName("HawkId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");

            // Relationships
            this.HasRequired(t => t.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
