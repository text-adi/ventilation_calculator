using Microsoft.EntityFrameworkCore;
using VentilationCalculator.DataAccess;
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
            InputDataDataGridView(TableForm);

            TableForm.Show();

        }
        private void InputDataDataGridView(TableForm tableForm)
        {

            if (Tool.CheckTableExists<T>(DBConnect))
            {
                switch (DBtable)
                {
                    case AirDensityTable:
                        {
                            var data = new UnPack(DBConnect);
                            tableForm.dataGridView1.DataSource = data.AirDensityTable();
                            break;
                        }

                    default:
                        {
                            var data = DBtable.ToList();
                            tableForm.dataGridView1.DataSource = data;
                            break;
                        }
                }


                tableForm.dataGridView1.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Помилка виконання операції: Дана таблиця відсутня. Вам потрібно створити її", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}