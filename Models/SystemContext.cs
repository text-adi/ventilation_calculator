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

    public virtual DbSet<AirDensityCategory> AirDensityCategories { get; set; }

    public virtual DbSet<AirDensityTable> AirDensityTables { get; set; }

    public virtual DbSet<AirDensityTemp> AirDensityTemps { get; set; }

    public virtual DbSet<AirExchangeRatioTable> AirExchangeRatioTables { get; set; }

    public virtual DbSet<Co2LevelTable> Co2LevelTables { get; set; }

    public virtual DbSet<FrameType> FrameTypes { get; set; }

    public virtual DbSet<InputDatum> InputData { get; set; }

    public virtual DbSet<PeopleHeatOutput> PeopleHeatOutputs { get; set; }

    public virtual DbSet<SolarHeatGainThroughGlazing> SolarHeatGainThroughGlazings { get; set; }

    public virtual DbSet<TempWork> TempWorks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=system.db");

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
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
