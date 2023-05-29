namespace VentilationCalculator.Models;

public partial class FrameType
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<SolarHeatGainThroughGlazing> SolarHeatGainThroughGlazings { get; set; } = new List<SolarHeatGainThroughGlazing>();
}
