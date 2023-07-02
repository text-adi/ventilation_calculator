namespace VentilationCalculator.Models;

//Таблиця вхідних даних
public partial class InputDataTable
{
    public long Id { get; set; }
    // Серверна
    public long VariantId { get; set; }
    public string? VariantText { get; set; }

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

    public double OutputAir { get; set; }

    // 3. Гранично допустима концетрація
    public int comboBoxCategoryWork { get; set; }
    public int comboBoxRoom { get; set; }
    public int textBoxPeopleInCity { get; set; }
    public int comboBoxTypeRame { get; set; }
    public int comboBoxWord { get; set; }
    public int comboBoxP { get; set; }

    //
    //
    public double InputTempSolar { get; set; }

    //

    public bool SaveMaterialSolar { get; set; }
    public double ReplaceTempC { get; set; }

    public static implicit operator InputDataTable(string v)
    {
        throw new NotImplementedException();
    }
}
