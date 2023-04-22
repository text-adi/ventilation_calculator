

namespace VentilationCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Text = editToolStripMenuItem.Text;
            tableForm.Show();
        }

        private void airExchangeRateTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Text = airExchangeRateTableToolStripMenuItem.Text;
            tableForm.Show();
        }

        private void cO2ConcentrationTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Text = cO2ConcentrationTableToolStripMenuItem.Text;
            tableForm.Show();
        }

        private void tableOfAirDensityValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Text = tableOfAirDensityValuesToolStripMenuItem.Text;
            tableForm.Show();
        }

        private void heatReleaseTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Text = heatReleaseTableToolStripMenuItem.Text;
            tableForm.Show();
        }

        private void heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Text = heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem.Text;
            tableForm.Show();

        }
    }
}