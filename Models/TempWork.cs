namespace VentilationCalculator.Models;

public partial class TempWork
{
    public long Id { get; set; }

    public double CountInWorkPlace { get; set; }

    public virtual ICollection<PeopleHeatOutput> PeopleHeatOutputs { get; set; } = new List<PeopleHeatOutput>();
}
