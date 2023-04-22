using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Подивится, чи є аналог super().func() як в python тільки C#
namespace VentilationCalculator.Components
{
    interface INormatile
    {
        double GetComplexityValue();
    }
    /// <summary>
    /// Рівні складності
    /// </summary>
    public enum DifficultWork
    {
        Default=0,
        Easy=1,
        Normal=2,
        Hard=3
    }
    /// <summary>
    /// Базовий клас, який зберігає відповідні значення при відповідній складності роботи
    /// </summary>
    public class Normatile<T> : INormatile where T : struct, Enum 

    {
        /// <summary>
        /// Комбінує рівень складності та відповідних значень при відповідній складності роботи
        /// </summary>
        public Dictionary<T, double> Table { get;  }
        public T VerticalColumn { get; protected set; }

        protected Normatile()
        {
            throw new NotImplementedException();    
        }
        public Normatile(Dictionary<T, double> table)
        {
            Table = table;
        }

        public Normatile(Dictionary<T, double> table, T verticalColumn) : this(table) 
        {
            SetVerticalColumn(verticalColumn);
        }
        protected void SetVerticalColumn(T verticalColumn)
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
        protected bool CheckVerticalColumn(T verticalColumn)
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
        public double GetComplexityValue()
        {
            return Table[VerticalColumn];
        }
        public double GetComplexityValue(T verticalColumn)
        {
            if (!CheckVerticalColumn(verticalColumn))
            {
                throw ThrowVerticalKeyNotFoundException(verticalColumn);
            }
            return Table[verticalColumn];
        }
    }

    public class DuoNormatile<T, Q>: Normatile<T> where T : struct, Enum where Q : struct
    {
        /// Дописати код який працює із двух вимірним масивом класа. Також продумати усі варіанти конструкторів
        public new Dictionary<T, Dictionary<Q,double>> Table { get; }
        public Q HorizontalColumn { get; protected set; }

        protected DuoNormatile() : base()
        {

        }

        public DuoNormatile(Dictionary<T, Dictionary<Q, double>> table)
        {
            Table = table;
        }
        public DuoNormatile(Dictionary<T, Dictionary<Q, double>> table, T verticalColumn, Q horizontalColumn) : this(table)
        {
            SetVerticalColumn(verticalColumn);
            SetHorizontalColumn(verticalColumn, horizontalColumn);
        }
        protected KeyNotFoundException ThrowHorazontalKeyNotFoundException(Q horizontalColumn)
        {
            return new KeyNotFoundException($"Даний ключ '{horizontalColumn}' відстуній в списку горизонтальних доступних ключів.");
        }
        protected void SetHorizontalColumn(T verticalColumn, Q horizontalColumn)
        {
            if (!CheckHorizontalColumn(verticalColumn, horizontalColumn))
            {
                throw ThrowHorazontalKeyNotFoundException(horizontalColumn);
            }
            VerticalColumn = verticalColumn;
        }
        protected bool CheckHorizontalColumn(T verticalColumn, Q horizontalColumn)
        {
            if (CheckVerticalColumn(verticalColumn) && Table[verticalColumn].ContainsKey(horizontalColumn))
            {
                return true;
            }
            return false;

        }

        public new double GetComplexityValue()
        {
            return Table[VerticalColumn][HorizontalColumn];
        }
        public double GetComplexityValue(T verticalColumn, Q horizontalColumn)
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
