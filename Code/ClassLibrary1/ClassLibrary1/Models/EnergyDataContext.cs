using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClassLibrary1.Models.Mapping;

namespace ClassLibrary1.Models
{
    public partial class EnergyDataContext : DbContext
    {
        static EnergyDataContext()
        {
            Database.SetInitializer<EnergyDataContext>(null);
        }

        public EnergyDataContext()
            : base("Name=EnergyDataContext")
        {
        }

        public DbSet<OUTSIDE_AIR_TEMP> OUTSIDE_AIR_TEMP { get; set; }
        public DbSet<OUTSIDE_HUMIDITY> OUTSIDE_HUMIDITY { get; set; }
        public DbSet<PBB_CHILLED_WATER> PBB_CHILLED_WATER { get; set; }
        public DbSet<PBB_CHILLED_WATER_SUM_BY_DAY> PBB_CHILLED_WATER_SUM_BY_DAY { get; set; }
        public DbSet<PBB_ELECTRIC> PBB_ELECTRIC { get; set; }
        public DbSet<PBB_ELECTRIC_SUM_BY_DAY> PBB_ELECTRIC_SUM_BY_DAY { get; set; }
        public DbSet<PBB_STEAM> PBB_STEAM { get; set; }
        public DbSet<PBB_STEAM_SUM_BY_DAY> PBB_STEAM_SUM_BY_DAY { get; set; }
        public DbSet<REPORT> REPORTs { get; set; }
        public DbSet<SOLAR_BUS_BARN> SOLAR_BUS_BARN { get; set; }
        public DbSet<SOLAR_BUS_BARN_SUM_BY_DAY> SOLAR_BUS_BARN_SUM_BY_DAY { get; set; }
        public DbSet<SOLAR_CAR_CHARGING> SOLAR_CAR_CHARGING { get; set; }
        public DbSet<SOLAR_CAR_CHARGING_SUM_BY_DAY> SOLAR_CAR_CHARGING_SUM_BY_DAY { get; set; }
        public DbSet<SOLAR_RADIATION> SOLAR_RADIATION { get; set; }
        public DbSet<SOLAR_RADIATION_SUM_BY_DAY> SOLAR_RADIATION_SUM_BY_DAY { get; set; }
        public DbSet<TC_CHILLED_WATER_SUM_BY_DAY> TC_CHILLED_WATER_SUM_BY_DAY { get; set; }
        public DbSet<TC_ELECTRICITY_SUM_BY_DAY> TC_ELECTRICITY_SUM_BY_DAY { get; set; }
        public DbSet<TC_STEAM_SUM_BY_DAY> TC_STEAM_SUM_BY_DAY { get; set; }
        public DbSet<TOTAL_CAMPUS_CHILLED_WATER> TOTAL_CAMPUS_CHILLED_WATER { get; set; }
        public DbSet<TOTAL_CAMPUS_ELECTRICITY> TOTAL_CAMPUS_ELECTRICITY { get; set; }
        public DbSet<TOTAL_CAMPUS_STEAM> TOTAL_CAMPUS_STEAM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OUTSIDE_AIR_TEMPMap());
            modelBuilder.Configurations.Add(new OUTSIDE_HUMIDITYMap());
            modelBuilder.Configurations.Add(new PBB_CHILLED_WATERMap());
            modelBuilder.Configurations.Add(new PBB_CHILLED_WATER_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new PBB_ELECTRICMap());
            modelBuilder.Configurations.Add(new PBB_ELECTRIC_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new PBB_STEAMMap());
            modelBuilder.Configurations.Add(new PBB_STEAM_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new REPORTMap());
            modelBuilder.Configurations.Add(new SOLAR_BUS_BARNMap());
            modelBuilder.Configurations.Add(new SOLAR_BUS_BARN_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new SOLAR_CAR_CHARGINGMap());
            modelBuilder.Configurations.Add(new SOLAR_CAR_CHARGING_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new SOLAR_RADIATIONMap());
            modelBuilder.Configurations.Add(new SOLAR_RADIATION_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new TC_CHILLED_WATER_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new TC_ELECTRICITY_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new TC_STEAM_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new TOTAL_CAMPUS_CHILLED_WATERMap());
            modelBuilder.Configurations.Add(new TOTAL_CAMPUS_ELECTRICITYMap());
            modelBuilder.Configurations.Add(new TOTAL_CAMPUS_STEAMMap());
        }
    }
}
