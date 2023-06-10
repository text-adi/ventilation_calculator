using Microsoft.EntityFrameworkCore;

namespace VentilationCalculator.DataAccess
{
    static public class Tool
    {
        public static bool CheckTableExists<T>(DbContext context) where T : class
        {
            try
            {
                context.Database.ExecuteSqlRaw("SELECT name FROM sqlite_master WHERE type='table' AND name='';");
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
