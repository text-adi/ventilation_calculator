using VentilationCalculator.Models;

namespace VentilationCalculator.Logics
{
    public class NeedOneVentilator
    {
        public VentilatorTable Need { get; }
        public int Count { get; }
        public NeedOneVentilator(VentilatorTable Need, int Count)
        {
            this.Need = Need;
            this.Count = Count;
        }
    }
    public class  NeedVentilator
    {
        
        public static NeedOneVentilator GetVariadnVentialot(double NeedValue, double min, double max)
        {
            VentilatorTable needVentilator = null;
            using SystemContext db = new();
            int countVentilator = 0;
            foreach (var item in db.VirantVentilator)
            {
                double procent = (NeedValue / item.Power) % 1; // отримуємо дробове число, яке вистапає в ролі точності. Чим менше дробове число, тим точний результат

                if ( needVentilator is null || procent < needVentilator.Power)
                {
                    int count = (int)(NeedValue /item.Power); // отримуємо кількість вентиляцій
                    double vat = item.Power * count; // обраховуємо остаточну потужність
                    if (vat < min || max < vat) // перевіряємо чи потужність входить в межі, якщо ні, то не записуємо
                    {
                        continue;
                    }
                    countVentilator = count;
                    needVentilator = item;
                }


            }
            return new NeedOneVentilator(needVentilator, countVentilator);
            

        }
    }
}
