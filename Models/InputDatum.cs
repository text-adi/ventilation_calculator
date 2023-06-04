namespace VentilationCalculator.Models;

//Таблиця вхідних даних
public partial class InputDatum
{
    public long Id { get; set; }

    public long VariantId { get; set; }

    public long CountPrinter { get; set; }

    public long CountServer { get; set; }

    public double WidthRoom { get; set; }

    public double LengthRoom { get; set; }

    public long InletTemp { get; set; }

    public long OutletTemp { get; set; }
}
