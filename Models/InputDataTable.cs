using System.Reflection;

namespace VentilationCalculator.Models;

//Таблиця вхідних даних
public partial class InputDataTable
{
    public long Id { get; set; }
    // Серверна
    public long VariantId { get; set; }

    public long CountPrinter { get; set; }

    public long CountServer { get; set; }

    public double WidthRoomServer { get; set; }

    public double LengthRoomServer { get; set; }

    public long InletTemp { get; set; }

    public long OutletTemp { get; set; }
    // Офіс
    public double WidthRoomOffice { get; set; }

    public double LengthRoomOffice { get; set; }
    public double HeigthRoomOffice { get; set; }
    public long CountPlace { get; set; }
    public long AvgTemp { get; set; }

    // 2. Кратність повітрообміну
    public double OfficeAir { get; set; }
    public double ServerAir { get; set; }

    public double OutputAir { get; set;}

    // 3. Гранично допустима концетрація
    public double TimeSavePlace { get; set; }
    public long City { get; set; }
    public long TypeCity { get; set; }
    public long Concetration { get; set; }
    public double GCO2 { get; set; }
    //4

    public double OutputTempPeople { get; set;}
    public double OutputTempPC { get; set;}
    public double OutputTempTV { get; set;}
    public double OutputTempAnother { get; set;}
    public double OutputTempServer { get; set;}
    //
    public double Zask { get; set;}
    //
    public long TypeFrame { get; set;}
    public long SideWorld { get; set;}
    public long Coordinate { get; set;}
    public double InputTempSolar { get; set;}
    
    //
    public double CoefK { get; set;}
    public bool SaveMaterialSolar { get; set;}
    public double MaterialP { get; set;}
    public double MaterialPFromTable { get; set;}
    public double ReplaceTempC { get; set;}










}
