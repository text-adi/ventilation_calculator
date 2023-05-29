namespace VentilationCalculator.Models;

public partial class SolarHeatGainThroughGlazing
{
    public long Id { get; set; }

    public long? FrameTypeId { get; set; }

    public string СompassDirection { get; set; } = null!;

    public double InletTemp { get; set; }

    public virtual FrameType? FrameType { get; set; }
}
