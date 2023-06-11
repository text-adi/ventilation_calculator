using Microsoft.EntityFrameworkCore;
using VentilationCalculator.Models;

namespace VentilationCalculator.Components
{
    internal class Automatization<T> where T : class
    {
        public DbSet<T> DBtable { get; }
        public SystemContext DBConnect { get; }
        public TableForm TableForm { get; }
        public Automatization(SystemContext DBConnect, DbSet<T> DBtable)
        {
            TableForm = new TableForm();
            this.DBtable = DBtable;
            this.DBConnect = DBConnect;
        }
        internal void ShowTables(ToolStripMenuItem item)
        {

            TableForm.Text = item.Text;
            //InputDataDataGridView(TableForm);

            TableForm.Show();

        }

    }

}