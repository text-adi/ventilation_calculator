namespace VentilationCalculator.Models;

public partial class PeopleHeatOutput
{
    public long Id { get; set; }

    public long CategoryWorkId { get; set; }

    public long TempWorkId { get; set; }

    public double AirTemp { get; set; }

    public virtual TempWork TempWork { get; set; } = null!;
}
