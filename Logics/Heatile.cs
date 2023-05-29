/// Подивится, чи є аналог super().func() як в python тільки C#
namespace VentilationCalculator.Logic
{
    class Heatile
    {
        public double Heat { get; set; } = 0;
        public int Count { get; set; } = 0;
        public double Total()
        {
            return Heat * Count;
        }
    }

}
