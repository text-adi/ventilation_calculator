namespace VentilationCalculator.Text
{
    public static class ResultText
    {
        public const string TEMPLATETEXT = "{INT_VALUE}";


        public const string labelVolumeOffice = "Офіс V = {INT_VALUE}";
        public const string labelVolumeServerRoom = "Серверна V = {INT_VALUE}";

        public const string labelAirExchangeRateOffice = "Офіс L = {INT_VALUE}";
        public const string labelAirExchangeRateServerRoom = "Серверна L = {INT_VALUE}";
        public const string labelAirMoistureExchangeOffce = "Офіс L = {INT_VALUE}";

        public const string labelInfoCity = "Місто/У місті {CITY}. Населення: {INT_VALUE_1} чол. ({TYPE_CITY})\r\nГранична концентрація {INT_VALUE_2} л/м^3";
        public const string labelAirExchangeFromCO2Concentration = "L = {INT_VALUE}";

        public const string labelQpeopleOffice = "Qл = {INT_VALUE}";
        public const string labelQequirementOffice = "Qобл = {INT_VALUE}";
        public const string labelQaverageOffice = "Qсер = {INT_VALUE}";
        public const string labelQSumOffice = "Q = Qл + Qобл + Qсер = {INT_VALUE}";

        public const string labelQoblServerRoom = "Qобл = {INT_VALUE}";

        public const string labelNeedWatOffice = "Вентиляція в офісі повинна забезпечувати \r\n{INT_VALUE} м^3/год";
        public const string labelNeedWatServerRoom = "Вентиляція в серверній повинна забезпечувати \r\n{INT_VALUE} м^3/год";
        
        //5
        public const string labelBetweenNeedWatOffice = "Потужність кондиціонера для офіса повинно бути в межах {INT_VALUE_1} кВт ... {INT_VALUE_2} кВт";
        public const string labelBeetwenNeedWatServerRoom = "Потужність кондиціонера для серверної повинно бути в межах {INT_VALUE_1} кВт ... {INT_VALUE_2} кВт";


    }
}
