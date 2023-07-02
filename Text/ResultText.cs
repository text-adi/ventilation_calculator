namespace VentilationCalculator.Text
{
    public static class SelectText
    {
        public const string labelSelectCategoryWork = "Уп – вміст газу у припливному повітрі: {SELECT}";
        public const string labelYgdk = "Угдк - вміст газу у припливному повітрі: {SELECT}";
        public const string labelCity = "{SELECT}";
        public const string labelCO2Concetracion = "Концетрація фуглекислого газу становить: {SELECT}";
        public const string labelResult = "Для офісу використовується кондиціонер з потужністю {SELECT} кВт. \nВартість  {PRICE} грн. \nКількість кондиціонерів {SELECT_1}. \nЗагальна ціна {PRICE_1}";
    }
    public static class ResultText
    {
        public const string TEMPLATETEXT = "{INT_VALUE}";


        public const string labelVolumeOffice = "Офіс V = {INT_VALUE}";
        public const string labelVolumeServerRoom = "Серверна V = {INT_VALUE}";

        public const string labelAirExchangeRateOffice = "Офіс L = {INT_VALUE}";
        public const string labelAirExchangeRateServerRoom = "Серверна L = {INT_VALUE}";
        public const string labelAirMoistureExchangeOffce = "Офіс L = {INT_VALUE}";

        public const string labelInfoCity = "Гранична концентрація {INT_VALUE} л/м^3";
        public const string labelAirExchangeFromCO2Concentration = "L = {INT_VALUE}";

        public const string labelQpeopleOffice = "Qл = {INT_VALUE}";
        public const string labelQequirementOffice = "Qобл = {INT_VALUE}";
        public const string labelQaverageOffice = "Qсер = {INT_VALUE}";
        public const string labelQSumOffice = "Q = Qл + Qобл + Qсер = {INT_VALUE}";

        public const string labelQoblServerRoom = "Qобл = {INT_VALUE}";

        public const string labelNeedWatOffice = "Кондиціонер в офісі повинен забезпечувати \r\n{INT_VALUE} м^3/год";
        public const string labelNeedWatServerRoom = "Кондиціонер в серверній повинен забезпечувати \r\n{INT_VALUE} м^3/год";

        //5
        public const string labelBetweenNeedWatOffice = "Потужність кондиціонера для офіса повинно бути в межах {INT_VALUE_1} кВт ... {INT_VALUE_2} кВт";
        public const string labelBeetwenNeedWatServerRoom = "Потужність кондиціонера для серверної повинно бути в межах {INT_VALUE_1} кВт ... {INT_VALUE_2} кВт";


    }
}
