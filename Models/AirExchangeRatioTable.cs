using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentilationCalculator.Models
{
    /// <summary>
    /// Таблиця А.16. Таблиця кратності повітрообміну
    /// </summary>
    internal class AirExchangeRatioTable 
    {
        public string RoomType { get; set; }
        public double AirExchangeMultiplier { get; set; }
    }

    /// <summary>
    /// Таблиця А.17. Концентрації СО2
    /// </summary>
    internal class Co2LevelTable
    {
        public string Teritory { get; set; }
        public double Co2Limit { get; set; }
    }

    /// <summary>
    /// Таблиця А.18. Значення густини повітря при різних температурах і тисках
    /// </summary>
    internal class AirDensityTable
    {
        public int AirTemp { get; set; }
        public double airDensity { get; set; }
        public double atmosphericPressure { get; set; }
    }

    /// <summary>
    /// Таблиця А.19. Кількість теплоти, що виділяється людьми, Qл, кВт
    /// </summary>
    internal class PeopleHeatOutput
    {
        public string CategoryWork { get; set; }
        public int CountPerson { get; set; }
        public double AirTemp { get; set; }
    }
    /// <summary>
    /// Таблиця А.20. Теплонадходження від сонічної радіації крізь засклені поверхні, q_заск, кДж/(м2∙год)
    /// </summary>
    internal class SolarHeatGainThroughGlazing
    {
        public string FrameType { get; set; }
        public int СompassDirection { get; set; }

        public double InletTemp { get; set; }
    }
}
