using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using VentilationCalculator.Models;

namespace VentilationCalculator.DataAccess
{
    internal class ProductContext: DbContext
    {

        public DbSet<InputData> InputData { get; set; }
        public DbSet<AirExchangeRatioTable> AirExchangeRatioTable { get; set; }
        public DbSet<Co2LevelTable> Co2LevelTable { get; set; }
        public DbSet<AirDensityTable> AirDensityTable { get; set; }
        public DbSet<PeopleHeatOutput> PeopleHeatOutput { get; set; }
        public DbSet<SolarHeatGainThroughGlazing> SolarHeatGainThroughGlazing { get; set; }

        public string DbPath { get; }

        public ProductContext() {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, "system.db");
        }

        public ProductContext(string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, fileName);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
