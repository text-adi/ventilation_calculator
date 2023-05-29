 namespace VentilationCalculator.Models;

public partial class AirDensityCategory
{
    public long Id { get; set; }

    public double AirDensity { get; set; }

    public virtual ICollection<AirDensityTable> AirDensityTables { get; set; } = new List<AirDensityTable>();
}
