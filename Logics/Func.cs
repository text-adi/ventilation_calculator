using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentilationCalculator.Logics
{
    internal static class Func
    {
        public static double FindShortPoint(double[] tables, double temp)
        {

            
            if (temp <= tables[0])
            {
                return tables[0];
            }


            for (int i = 0; i < tables.Length; i++)
            {

           
                if (temp < tables[i])
                {
   
                    double left = temp - tables[i - 1];
                    double rigth = tables[i] - temp;

                    if (left > rigth)
                    {
                        return tables[i];


                    }
                    else
                    {
                        return tables[i - 1];
                    }
                }

            }
            return tables[tables.Length - 1];

        }
    }
}
