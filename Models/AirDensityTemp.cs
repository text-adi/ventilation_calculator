namespace VentilationCalculator.Models;

public partial class AirDensityTemp
{
    public long Id { get; set; }

    public double Temperature { get; set; }

    public virtual ICollection<AirDensityTable> AirDensityTables { get; set; } = new List<AirDensityTable>();
}
