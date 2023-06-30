using VentilationCalculator.Models;

namespace VentilationCalculator.Logics
{
    public class Databases
    {
        public static void GetAllListVarian(ListBox listBoxInputData)
        {
            using SystemContext db = new();

            var inputData = db.InputData.ToList();

            for (int i = 0; i < inputData.Count; i++)
            {
                inputData[i].VariantText = inputData[i].VariantId.ToString() + " варіант";
            }

            listBoxInputData.DataSource = inputData;
            listBoxInputData.DisplayMember = "VariantText";

        }



    }
}
