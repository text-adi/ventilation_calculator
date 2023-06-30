namespace VentilationCalculator.Logics
{
    internal class Duo
    {
        public string Name { get; }
        public double? MaxValue { get; }
        public double Value { get; }

        public Duo(string name, double value, double maxValue)
        {
            Name = name;
            Value = value;
            MaxValue = maxValue;
        }
        public Duo(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
    internal class City
    {
        public string Name { get; }
        public double People { get; }
        public double Value { get; }

        public City(string name, double value, double people)
        {
            Name = name;
            Value = value;
            People = people;
        }

    }
    internal class CategoryWork
    {
        public string Name { get; }
        public int Level { get; }



        public CategoryWork(string name, int level)
        {
            Name = name;
            Level = level;
        }

    }
    internal class TypeRama
    {
        public string Name { get; }
        public int ID { get; }

        public TypeRama(string name, int ID)
        {
            Name = name;
            this.ID = ID;
        }

    }
    internal class Tables
    {
        public static readonly List<Duo> Table16 = new()
        {
        new Duo("Житлова кімната", 3),
        new Duo("Ванна кімната",7,9),
        new Duo("Туалет", 8,10),
        new Duo("Гардеробна кімната", 1.5),
        new Duo("Гараж",4,8),
        new Duo("Театр, кінозал, конференці-зал", 20,40),
        new Duo("Банк",2,4),
        new Duo("Офісне приміщення", 5,7),
        new Duo("Магазин", 1.5,3),
        new Duo("Гараж і авторемонтна майстерня", 6,8),
        new Duo("Танцювальний зал, дискотека", 8,10),
        new Duo("Серверна", 5,10),
        new Duo("Спортивний зал", 80, double.MaxValue),
        new Duo("Фарбувальний цех",25,40),
        new Duo("Кухня", 6,8),
        new Duo("Душова", 7,9),
        new Duo("Побутова пральня", 7),
        new Duo("Комора", 1),
        new Duo("Погріб", 4,6),
        new Duo("Бар, кафе, пивний зал", 9,11),
        new Duo("Ресторан", 8,10),
        new Duo("Кімната для паління", 10),
        new Duo("Аптека", 3),
        new Duo("Громадський туалет", 10,12),
        new Duo("Кухонне приміщення в кафе, ресторані", 10,15),
        new Duo("Перукарня", 3),
        new Duo("Басейн", 10, 20),
        new Duo("Шкільний клас",3,8)
        };
        public static readonly List<Duo> Table17Room = new()
        {
            new Duo("В місцях постійного перебування людей (житлові кімнати)", 1),
            new Duo("У лікарнях та дитячих установах", 0.7),
            new Duo("В місцях тимчасового перебування людей ", 1.25),
            new Duo("В місцях короткочасного перебування людей", 2)
        };
        public static readonly List<City> Table17City = new()
        {
            new City("Населені пункти (селища, смт)", 0.33, 100),
            new City("Малі міста (до 300 000 осіб)", 0.4, 300000),
            new City("Населені пункти (селища, смт)", 0.5, double.MaxValue),
        };
        public static readonly Dictionary<int, Dictionary<double, int>> Table19Temp = new Dictionary<int, Dictionary<double, int>>()
        {
            { 1, new Dictionary<double, int> { {10,650 },{15,566},{20,545},{25,524},{30,524}, {35,524} } },
            { 2, new Dictionary<double, int>{ { 10, 775 }, { 15, 754}, { 20, 733}, { 25, 712}, { 30, 712 }, { 35, 712  } } },
            { 3, new Dictionary<double, int>{ { 10, 925 }, { 15, 921 }, { 20, 917 }, { 25, 906 }, { 30, 906 }, { 35, 906 } } },
        };
        public static readonly Dictionary<int, Dictionary<int, int>> Table20Word = new Dictionary<int, Dictionary<int, int>>()
        {
            { 0, new Dictionary<int, int> { { 180, 461 }, { 135, 660 }, { 225, 660 }, { 90, 522 }, { 270, 522 }, { 45, 270 }, { 315, 270 }, { 0, 62  } } },
            { 1, new Dictionary<int, int>{ { 180, 594 }, { 135, 461}, { 225, 461 }, { 90, 666 }, { 270, 666 }, { 45, 342 }, { 315, 342 }, { 0, 84 }  } },
            { 2, new Dictionary<int, int>{ { 180, 756 }, { 135, 720}, { 225, 720}, { 90, 692}, { 270, 692 }, { 45, 360}, { 315, 360 }, { 0, 106 } }},
        };
        enum Category
        {
            Easy = 1,
            Medium = 2,
            Hard = 3,
        }
        public static readonly List<CategoryWork> categoryWorks = new()
        {
            new CategoryWork("Легкі", (int) Category.Easy),
            new CategoryWork("Середні", (int)Category.Medium),
            new CategoryWork("Важкі", (int)Category.Hard),
        };
        public static readonly Dictionary<int, double> CO2Output = new Dictionary<int, double>()
        {
            {1, 14.25},
            {2, 19.8},
            {3, 25.6},
        };

        public static readonly List<TypeRama> typeRama = new()
        {
            new TypeRama("Дерев’яна", 0),
            new TypeRama("Металева", 1),
            new TypeRama("Металопластикова", 2),
        };
        public static readonly Dictionary<int, double> kTypeRame = new Dictionary<int, double>()
        {
            { 0, 1.0},
            { 1, 1.15},
            { 2, 1.45},
        };

        public static readonly List<Duo> Word = new()
        {
            new Duo("Південь", 180),
            new Duo("Південний схід", 135 ),
            new Duo("Південний захід", 225),
            new Duo("Схід", 90),
            new Duo("Захід", 270),
            new Duo("Північний схід", 45),
            new Duo("Північний захід", 315),
            new Duo("Північ", 0),
        };
        public static readonly List<int> p = new()
        {
            760,
            745,
        };

    }
}
