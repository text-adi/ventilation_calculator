namespace VentilationCalculator.Logic
{
    /// <summary>
    ///  Містить методи для обрахунку тепловиділення та все, що з ним пов'язано
    /// </summary>
    class Heat
    {
        /// <summary>
        /// Тепловиділення від людей у робітників 
        /// </summary>
        /// <returns>Qл</returns>
        public static double HumanBody(Heatile people)
        {
            return people.Total() / 3600;
        }
        /// <summary>
        /// Тепловиділення від техніки в офісі
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="tv"></param>
        /// <param name="another"></param>
        /// <returns></returns>
        public static double Equipment(Heatile computer, Heatile tv, Heatile another)
        { 
            return computer.Total() + tv.Total() + another.Total();
        }
        /// <summary>
        /// Від сонячної радіації
        /// </summary>
        /// <param name="countHeat"></param>
        /// <returns></returns>
        public static double Solar(double countHeat, double inletTempWindow, double k, bool exist)
        {
            double OUTPUT_HEAT = 0.9;
            if (exist)
            {
                OUTPUT_HEAT = 0.8;
            }
            return (countHeat * inletTempWindow * k * OUTPUT_HEAT) / 3600;



        }
    }

    /// <summary>
    /// Обрахунок повітрообміну під час різних ситуацій. 2-й порядок виконання операцій
    /// </summary>
    public class AirExchange
    {
        /// <summary>
        /// Необхідна кратність обміну повітря
        /// </summary>
        /// <param name="volumeRoom">Об'єм кімнати</param>
        /// <param name="minAirExchangeRate">
        /// Значення береться із таблиці #16
        /// </param>
        /// 
        /// <returns></returns>
        public static double GetAirExchangeRate(double volumeRoom, double minAirExchangeRate)
        {
            return volumeRoom * minAirExchangeRate;
        }

        /// <summary>
        /// Повітрообмін при виділені вологи. Приміщення із людьми
        /// </summary>
        /// <param name="airNormal">
        /// Норма повітря на 1 людину. Легка - 20-25, середня - 45 та важка - 60 фізичні роботи m^3/hour
        /// </param>
        /// <param name="countPeople">
        /// Кількість людей в кімнаті. Вхідні дані
        /// </param>
        /// <returns></returns>
        public static double GetAirMoistureExchange(double airNormal, int countPeople)
        {
            return airNormal * countPeople;
        }

        /// <summary>
        /// Визначення повітрообміну, залежно від гранично допустимої концентрації вуглекислого газу 
        /// </summary>
        /// <param name="CO2AirConcentrationLimit">
        /// У_ГДК – гранично допустима концентрація СО2 у повітрі, що видаляється, л/м3. Значення береться із Таблиці 17
        /// </param>
        /// <param name="CO2InLetAirConcentrationLimit">
        /// У_П – вміст газу у припливному повітрі, л/м3. Розраховується за допомогою попередніх ЛР та для обрахунків потрібно враховувати розміри міста, в якому знаходиться офіс
        /// </param>
        /// <param name="CO2EmissionsPerPerson">
        /// Норма вуглекислого газу, що виділяється однієї людиної під час роботи. Легка - 14,25, середня - 19,8 та важка - 25,6 фізичні роботи m^3/hour
        /// </param>
        /// <param name="countPeople">Кількість людей в приміщені</param>
        /// <returns></returns>
        public static double GetAirExchangeFromCO2Concentration(double CO2EmissionsPerPerson, int countPeople, double CO2AirConcentrationLimit, double CO2InLetAirConcentrationLimit)
        {
            double peopleAirNormal = CO2EmissionsPerPerson * countPeople;
            return peopleAirNormal / (CO2AirConcentrationLimit - CO2InLetAirConcentrationLimit);

        }

        /// <summary>
        /// Визначення повітрообміну для видалення надлишків тепла 
        /// </summary>
        /// <returns></returns>
        public static double GetHeatExchangeRate(double QSum, double p, double c, double outputH, double inputH)
        {

            return (QSum * 1000) / (p * c * (outputH - inputH));

        }

    }

    /// <summary>
    /// Обрахунок перших формул, для визначення розмірів приміщення.
    /// </summary>
    public class Room
    {
        public double width { get; }
        public double length { get; }
        public double height { get; }

        /// <summary>
        /// Дані приміщення
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public Room(double width, double length, double height)
        {
            this.width = width;
            this.length = length;
            this.height = height;
        }

        /// <summary>
        /// Об'єм кімнати
        /// </summary>
        /// <returns></returns>
        public double GetVolume()
        {
            return width * length * height;
        }

    }

}
