﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentilationCalculator.Logics
{
    public class NeedVentilator
    {
        public static void GetVariadnVentialot(double NeedValue)
        {
            // 1. Зробит вибірку до БД, та отримати весь список вентиляцій
            // 2. В нас є 200, 300, 150,(потрібно 100) визначаємо, яке значення із запропонованих найблище до 100.
            //    Якщо в нас є 2,5,7,9, 5,5 і потрібно 20, то формується спочатку найбільш підходящі комбінації, типу 5 5 5 5, 5 5 9 , 2 7 5 5, 2 7 9. із видаленям дублікатів відповідей
            //    Чи зробити щоб кожної потужності писало 
        }
    }
}
