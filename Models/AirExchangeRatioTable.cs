namespace VentilationCalculator.Models;

public partial class AirExchangeRatioTable
{
    public long Id { get; set; }

    public string? RoomType { get; set; }

    public string AirExchangeMultiplier { get; set; } = null!;
}
