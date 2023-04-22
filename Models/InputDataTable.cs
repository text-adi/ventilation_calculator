using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentilationCalculator.Models
{
    internal class InputData
    {
        public int VariantID { get; set; }

        public int CountPrinter { get; set; }

        public int CountServer { get; set; }

        public double WidthRoom { get; set; }
        public double LengthRoom { get; set; }

        public int InletTemp { get; set; }
        public int  OutletTemp { get; set; }
    }
}
