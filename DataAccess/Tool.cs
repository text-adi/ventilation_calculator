using Microsoft.EntityFrameworkCore;

namespace VentilationCalculator.DataAccess
{
    static public class Tool
    {
        public static bool CheckTableExists<T>(DbContext context) where T : class
        {
            try
            {
                context.Set<T>().ToList();
                return true;
            }
            catch (Microsoft.Data.Sqlite.SqliteException)
            {

                return false;
            }



        }
    }
}
