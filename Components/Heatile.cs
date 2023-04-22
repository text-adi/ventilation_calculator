using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Подивится, чи є аналог super().func() як в python тільки C#
namespace VentilationCalculator.Components
{
	class Heatile
    {
        public double Heat { get; set; }
        public int Count { get; set; }
        public double Total()
        {
            return Heat * Count;
        }
    }

}
