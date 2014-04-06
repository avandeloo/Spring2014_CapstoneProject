using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EnvironmentalApp.Data.SQLServer.Mapping;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Data.SQLServer
{
    public partial class EnergyDataContext : DbContext
    {
        static EnergyDataContext()
        {
            Database.SetInitializer<EnergyDataContext>(null);
        }

        public EnergyDataContext(string connString)
            : base(connString)
        {
        }

        public DbSet<AirTemp> OUTSIDE_AIR_TEMP { get; set; }
        public DbSet<AirTempDailyTotals> AIR_TEMP_SUM_BY_DAY { get; set; }
        public DbSet<Humidity> OUTSIDE_HUMIDITY { get; set; }
        public DbSet<HumidityDailyTotals> HUMIDITY_SUM_BY_DAY { get; set; }
        public DbSet<ChilledWater> PBB_CHILLED_WATER { get; set; }
        public DbSet<ChilledWaterDailyTotals> PBB_CHILLED_WATER_SUM_BY_DAY { get; set; }
        public DbSet<Electric> PBB_ELECTRIC { get; set; }
        public DbSet<ElectricDailyTotals> PBB_ELECTRIC_SUM_BY_DAY { get; set; }
        public DbSet<Steam> PBB_STEAM { get; set; }
        public DbSet<SteamDailyTotals> PBB_STEAM_SUM_BY_DAY { get; set; }
        public DbSet<Report> REPORTs { get; set; }
        public DbSet<Solar> SOLAR_BUS_BARN { get; set; }
        public DbSet<SolarDailyTotals> SOLAR_BUS_BARN_SUM_BY_DAY { get; set; }
        public DbSet<Solar> SOLAR_CAR_CHARGING { get; set; }
        public DbSet<SolarDailyTotals> SOLAR_CAR_CHARGING_SUM_BY_DAY { get; set; }
        public DbSet<SolarRadiation> SOLAR_RADIATION { get; set; }
        public DbSet<SolarRadiationDailyTotals> SOLAR_RADIATION_SUM_BY_DAY { get; set; }
        public DbSet<ChilledWaterDailyTotals> TC_CHILLED_WATER_SUM_BY_DAY { get; set; }
        public DbSet<ElectricDailyTotals> TC_ELECTRICITY_SUM_BY_DAY { get; set; }
        public DbSet<SteamDailyTotals> TC_STEAM_SUM_BY_DAY { get; set; }
        public DbSet<ChilledWater> TOTAL_CAMPUS_CHILLED_WATER { get; set; }
        public DbSet<Electric> TOTAL_CAMPUS_ELECTRICITY { get; set; }
        public DbSet<Steam> TOTAL_CAMPUS_STEAM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AIR_TEMP_SUM_BY_DAYMap());
            modelBuilder.Configurations.Add(new OUTSIDE_AIR_TEMPMap());
            modelBuilder.Configurations.Add(new HUMIDITY_SUM_BY_DAYMap());
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
