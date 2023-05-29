namespace VentilationCalculator.Models;

public partial class Co2LevelTable
{
    public long Id { get; set; }

    public string? Teritory { get; set; }

    public double Co2Limit { get; set; }
}
