using VentilationCalculator.Models;

namespace VentilationCalculator.DataAccess
{


    internal class Pack
    {
        public SystemContext connect_db { get; }
        public Pack(SystemContext db)
        {
            connect_db = db;
        }
        public void airExchangeRateTable()
        {

        }
        public void inputData()
        {

        }
    }
    internal class UnPack
    {
        public SystemContext connect_db { get; }
        public UnPack(SystemContext db)
        {
            connect_db = db;
        }
        public List<AirDensityTable> AirDensityTable()
        {
            return connect_db.AirDensityTables.ToList();
        }
        public List<InputDatum> inputData()
        {
            return connect_db.InputData.ToList();
        }

     
    }
}
