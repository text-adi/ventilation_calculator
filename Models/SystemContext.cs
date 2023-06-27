using Microsoft.EntityFrameworkCore;

namespace VentilationCalculator.Models;

public partial class SystemContext : DbContext
{
    public SystemContext()
    {
    }

    public SystemContext(DbContextOptions<SystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InputDataTable> InputData { get; set; }
    public virtual DbSet<CityTable> City  { get; set; }
    public virtual DbSet<TypeCityTable> TypeCity { get; set; }
    public virtual DbSet<OutputTempPeopleTable> OutputTempPeople { get; set; }
    public virtual DbSet<InputSolarTable> InputSolar { get; set; }
    public virtual DbSet<TypeFrameTable> TypeFrame { get; set; }
    public virtual DbSet<PTable> P { get; set; }
    public virtual DbSet<ConstantsTable> Constants { get; set; }
    public virtual DbSet<VentilatorTable> VirantVentilator { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=system.db");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }
    /*   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirDensityCategory>(entity =>
            {
                entity.ToTable("AirDensityCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AirDensityTable>(entity =>
            {
                entity.ToTable("AirDensityTable");

                entity.Property(e => e.AtmosphericPressure).HasColumnName("atmosphericPressure");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.TemperatureId).HasColumnName("TemperatureID");

                entity.HasOne(d => d.Category).WithMany(p => p.AirDensityTables)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Temperature).WithMany(p => p.AirDensityTables).HasForeignKey(d => d.TemperatureId);
            });

            modelBuilder.Entity<AirDensityTemp>(entity =>
            {
                entity.ToTable("AirDensityTemp");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AirExchangeRatioTable>(entity =>
            {
                entity.ToTable("AirExchangeRatioTable");
            });



            modelBuilder.Entity<Co2LevelTable>(entity =>
            {
                entity.ToTable("Co2LevelTable");
            });

            modelBuilder.Entity<FrameType>(entity =>
            {
                entity.ToTable("FrameType");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<InputDatum>(entity =>
            {
                entity.Property(e => e.VariantId).HasColumnName("VariantID");
            });

            modelBuilder.Entity<PeopleHeatOutput>(entity =>
            {
                entity.ToTable("PeopleHeatOutput");

                entity.Property(e => e.CategoryWorkId).HasColumnName("CategoryWorkID");
                entity.Property(e => e.TempWorkId).HasColumnName("TempWorkID");



                entity.HasOne(d => d.TempWork).WithMany(p => p.PeopleHeatOutputs)
                    .HasForeignKey(d => d.TempWorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SolarHeatGainThroughGlazing>(entity =>
            {
                entity.ToTable("SolarHeatGainThroughGlazing");

                entity.Property(e => e.FrameTypeId).HasColumnName("FrameTypeID");

                entity.HasOne(d => d.FrameType).WithMany(p => p.SolarHeatGainThroughGlazings).HasForeignKey(d => d.FrameTypeId);
            });

            modelBuilder.Entity<TempWork>(entity =>
            {
                entity.ToTable("TempWork");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }*/

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
