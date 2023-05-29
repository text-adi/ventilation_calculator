using Microsoft.EntityFrameworkCore.Metadata.Internal;
/// Подивится, чи є аналог super().func() як в python тільки C#
namespace VentilationCalculator.Logic
{
    /// <summary>
    /// Рівні складності
    /// </summary>
    public enum DifficultWork
    {
        Default = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3
    }
    /// <summary>
    /// Базовий клас, який зберігає відповідні значення при відповідній складності роботи
    /// </summary>
    public class Normatile<T, V>  where T: struct

    {
        /// <summary>
        /// Комбінує рівень складності та відповідних значень при відповідній складності роботи
        /// </summary>
        public Dictionary<T, V> Table { get; }
        public T VerticalColumn { get;  set; }

        public Normatile(Dictionary<T, V> table)
        {
            Table = table;
        }


        public void SetVerticalColumn(T verticalColumn)
        {
            if (!CheckVerticalColumn(verticalColumn))
            {
                throw ThrowVerticalKeyNotFoundException(verticalColumn);
            }
            VerticalColumn = verticalColumn;
        }
        protected KeyNotFoundException ThrowVerticalKeyNotFoundException(T verticalColumn)
        {
            return new KeyNotFoundException($"Даний ключ '{verticalColumn}' відстуній в списку вертикальних доступних ключів.");
        }
        public bool CheckVerticalColumn(T verticalColumn)
        {
            if (Table.ContainsKey(verticalColumn))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Отримати базове значення для відповідного рівня складності роботи встановлене при інцілізації конструктора
        /// </summary>
        /// <returns></returns>
        public V GetComplexityValue()
        {
            return Table[VerticalColumn];
        }
        public V GetComplexityValue(T verticalColumn)
        {
            if (!CheckVerticalColumn(verticalColumn))
            {
                throw ThrowVerticalKeyNotFoundException(verticalColumn);
            }
            return Table[verticalColumn];
        }
    }

    public class DuoNormatile<T, Q ,V> where Q: struct
    {
        /// Дописати код який працює із двух вимірним масивом класа. Також продумати усі варіанти конструкторів
        public Dictionary<T, Dictionary<Q, V>> Table { get; }
        public Q HorizontalColumn { get; set; }
        public T VerticalColumn { get; set; }


        public DuoNormatile()
        {
        }
        public DuoNormatile(Dictionary<T, Dictionary<Q, V>> table)
        {
            Table = table;
        }


        public KeyNotFoundException ThrowHorazontalKeyNotFoundException(Q horizontalColumn)
        {
            return new KeyNotFoundException($"Даний ключ '{horizontalColumn}' відстуній в списку горизонтальних доступних ключів.");
        }
        public void SetHorizontalColumn(T verticalColumn, Q horizontalColumn)
        {
            if (!CheckHorizontalColumn(verticalColumn, horizontalColumn))
            {
                throw ThrowHorazontalKeyNotFoundException(horizontalColumn);
            }
            VerticalColumn = verticalColumn;
            HorizontalColumn = horizontalColumn;
        }

            public bool CheckVerticalColumn(T verticalColumn)
        {
            if (Table.ContainsKey(verticalColumn))
            {
                return true;
            }
            return false;
        }
            public bool CheckHorizontalColumn(T verticalColumn, Q horizontalColumn)
        {
            if (CheckVerticalColumn(verticalColumn) && Table[verticalColumn].ContainsKey(horizontalColumn))
            {
                return true;
            }
            return false;

        }

        public V GetComplexityValue()
        {
            return Table[VerticalColumn][HorizontalColumn];
        }
        protected KeyNotFoundException ThrowVerticalKeyNotFoundException(T verticalColumn)
        {
            return new KeyNotFoundException($"Даний ключ '{verticalColumn}' відстуній в списку вертикальних доступних ключів.");
        }
        public V GetComplexityValue(T verticalColumn, Q horizontalColumn)
        {
            if (!CheckVerticalColumn(verticalColumn))
            {
                throw ThrowVerticalKeyNotFoundException(verticalColumn);
            }
            if (!CheckHorizontalColumn(verticalColumn, horizontalColumn))
            {
                throw ThrowHorazontalKeyNotFoundException(horizontalColumn);
            }
            return Table[verticalColumn][horizontalColumn];
        }

    }


}
