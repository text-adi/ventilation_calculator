namespace VentilationCalculator.Models;

public partial class AirDensityTable
{
    public long Id { get; set; }

    public long TemperatureId { get; set; }

    public long CategoryId { get; set; }

    public double AtmosphericPressure { get; set; }

    public virtual AirDensityCategory Category { get; set; } = null!;

    public virtual AirDensityTemp Temperature { get; set; } = null!;
}
