namespace VentilationCalculator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            clearToolStripMenuItem = new ToolStripMenuItem();
            tableToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            airExchangeRateTableToolStripMenuItem = new ToolStripMenuItem();
            cO2ConcentrationTableToolStripMenuItem = new ToolStripMenuItem();
            tableOfAirDensityValuesToolStripMenuItem = new ToolStripMenuItem();
            heatReleaseTableToolStripMenuItem = new ToolStripMenuItem();
            heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel2 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutInputGroupBoxPanel = new TableLayoutPanel();
            tabPage2 = new TabPage();
            menuStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, tableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(2448, 49);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, databaseToolStripMenuItem, toolStripSeparator1, clearToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(87, 45);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(448, 54);
            newToolStripMenuItem.Text = "New";
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, exportToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(448, 54);
            databaseToolStripMenuItem.Text = "Database";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(274, 54);
            importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(274, 54);
            exportToolStripMenuItem.Text = "Export";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(445, 6);
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(448, 54);
            clearToolStripMenuItem.Text = "Clear all";
            // 
            // tableToolStripMenuItem
            // 
            tableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editToolStripMenuItem, airExchangeRateTableToolStripMenuItem, cO2ConcentrationTableToolStripMenuItem, tableOfAirDensityValuesToolStripMenuItem, heatReleaseTableToolStripMenuItem, heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem });
            tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            tableToolStripMenuItem.Size = new Size(92, 45);
            tableToolStripMenuItem.Text = "Edit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(947, 54);
            editToolStripMenuItem.Text = "Table of options";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // airExchangeRateTableToolStripMenuItem
            // 
            airExchangeRateTableToolStripMenuItem.Name = "airExchangeRateTableToolStripMenuItem";
            airExchangeRateTableToolStripMenuItem.Size = new Size(947, 54);
            airExchangeRateTableToolStripMenuItem.Text = "Air exchange rate table";
            airExchangeRateTableToolStripMenuItem.Click += airExchangeRateTableToolStripMenuItem_Click;
            // 
            // cO2ConcentrationTableToolStripMenuItem
            // 
            cO2ConcentrationTableToolStripMenuItem.Name = "cO2ConcentrationTableToolStripMenuItem";
            cO2ConcentrationTableToolStripMenuItem.Size = new Size(947, 54);
            cO2ConcentrationTableToolStripMenuItem.Text = "CO2 concentration table";
            cO2ConcentrationTableToolStripMenuItem.Click += cO2ConcentrationTableToolStripMenuItem_Click;
            // 
            // tableOfAirDensityValuesToolStripMenuItem
            // 
            tableOfAirDensityValuesToolStripMenuItem.Name = "tableOfAirDensityValuesToolStripMenuItem";
            tableOfAirDensityValuesToolStripMenuItem.Size = new Size(947, 54);
            tableOfAirDensityValuesToolStripMenuItem.Text = "Table of air density values";
            tableOfAirDensityValuesToolStripMenuItem.Click += tableOfAirDensityValuesToolStripMenuItem_Click;
            // 
            // heatReleaseTableToolStripMenuItem
            // 
            heatReleaseTableToolStripMenuItem.Name = "heatReleaseTableToolStripMenuItem";
            heatReleaseTableToolStripMenuItem.Size = new Size(947, 54);
            heatReleaseTableToolStripMenuItem.Text = "Heat release table";
            heatReleaseTableToolStripMenuItem.Click += heatReleaseTableToolStripMenuItem_Click;
            // 
            // heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem
            // 
            heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem.Name = "heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem";
            heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem.Size = new Size(947, 54);
            heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem.Text = "Heat transfer from solar radiation through glazed surfaces";
            heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem.Click += heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.ControlLight;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.2745094F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.72549F));
            tableLayoutPanel2.Controls.Add(tabControl1, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 49);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(2448, 1039);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(279, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2166, 1033);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutInputGroupBoxPanel);
            tabPage1.Location = new Point(10, 58);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2146, 965);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Input data";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutInputGroupBoxPanel
            // 
            tableLayoutInputGroupBoxPanel.ColumnCount = 2;
            tableLayoutInputGroupBoxPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.63437F));
            tableLayoutInputGroupBoxPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.36563F));
            tableLayoutInputGroupBoxPanel.Dock = DockStyle.Fill;
            tableLayoutInputGroupBoxPanel.Location = new Point(3, 3);
            tableLayoutInputGroupBoxPanel.Name = "tableLayoutInputGroupBoxPanel";
            tableLayoutInputGroupBoxPanel.RowStyles.Add(new RowStyle());
            tableLayoutInputGroupBoxPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutInputGroupBoxPanel.Size = new Size(2140, 959);
            tableLayoutInputGroupBoxPanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(10, 58);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2146, 965);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Calculated data";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(2448, 1088);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        // Меню
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutInputGroupBoxPanel;
        private TabPage tabPage2;
        private ToolStripMenuItem tableToolStripMenuItem;
        internal ToolStripMenuItem editToolStripMenuItem;
        internal ToolStripMenuItem airExchangeRateTableToolStripMenuItem;
        internal ToolStripMenuItem cO2ConcentrationTableToolStripMenuItem;
        internal ToolStripMenuItem tableOfAirDensityValuesToolStripMenuItem;
        internal ToolStripMenuItem heatReleaseTableToolStripMenuItem;
        internal ToolStripMenuItem heatTransferFromSolarRadiationThroughGlazedSurfacesToolStripMenuItem;
    }
}