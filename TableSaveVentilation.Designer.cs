namespace VentilationCalculator
{
    partial class TableSaveVentilation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            label7 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            listBox1 = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            оновитиToolStripMenuItem = new ToolStripMenuItem();
            видалитиВентиляціюToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            textBoxEditVent = new TextBox();
            label1 = new Label();
            pictureBoxPhoto = new PictureBox();
            panel2 = new Panel();
            label6 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            label5 = new Label();
            textBoxPower = new TextBox();
            button1 = new Button();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.8775711F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 792F));
            tableLayoutPanel1.Size = new Size(1648, 1021);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBoxEditVent);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBoxPhoto);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(1642, 786);
            panel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(664, 230);
            label7.Name = "label7";
            label7.Size = new Size(213, 41);
            label7.TabIndex = 7;
            label7.Text = "Вартість в грн.";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(664, 288);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(395, 47);
            textBox2.TabIndex = 6;
            textBox2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 70);
            label3.Name = "label3";
            label3.Size = new Size(214, 41);
            label3.TabIndex = 5;
            label3.Text = "Кондиціонери";
            // 
            // listBox1
            // 
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 41;
            listBox1.Location = new Point(53, 135);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(580, 578);
            listBox1.TabIndex = 4;
            listBox1.Click += listBox1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(40, 40);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { оновитиToolStripMenuItem, видалитиВентиляціюToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(390, 100);
            // 
            // оновитиToolStripMenuItem
            // 
            оновитиToolStripMenuItem.Name = "оновитиToolStripMenuItem";
            оновитиToolStripMenuItem.Size = new Size(389, 48);
            оновитиToolStripMenuItem.Text = "Оновити";
            оновитиToolStripMenuItem.Click += оновитиToolStripMenuItem_Click;
            // 
            // видалитиВентиляціюToolStripMenuItem
            // 
            видалитиВентиляціюToolStripMenuItem.Name = "видалитиВентиляціюToolStripMenuItem";
            видалитиВентиляціюToolStripMenuItem.Size = new Size(389, 48);
            видалитиВентиляціюToolStripMenuItem.Text = "Видалити вентиляцію";
            видалитиВентиляціюToolStripMenuItem.Click += видалитиВентиляціюToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(664, 81);
            label2.Name = "label2";
            label2.Size = new Size(247, 41);
            label2.TabIndex = 3;
            label2.Text = "Потужність в кВт";
            // 
            // textBoxEditVent
            // 
            textBoxEditVent.Location = new Point(664, 139);
            textBoxEditVent.Name = "textBoxEditVent";
            textBoxEditVent.ReadOnly = true;
            textBoxEditVent.Size = new Size(395, 47);
            textBoxEditVent.TabIndex = 2;
            textBoxEditVent.Text = "0";
            textBoxEditVent.TextChanged += textBox_TextChanged_floatFilter;
            textBoxEditVent.Leave += textBoxPower_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1088, 70);
            label1.Name = "label1";
            label1.Size = new Size(237, 41);
            label1.TabIndex = 1;
            label1.Text = "Фото вентиляції";
            // 
            // pictureBoxPhoto
            // 
            pictureBoxPhoto.Location = new Point(1083, 139);
            pictureBoxPhoto.Name = "pictureBoxPhoto";
            pictureBoxPhoto.Size = new Size(514, 565);
            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPhoto.TabIndex = 0;
            pictureBoxPhoto.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBoxPower);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1642, 223);
            panel2.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(841, 42);
            label6.Name = "label6";
            label6.Size = new Size(213, 41);
            label6.TabIndex = 7;
            label6.Text = "Вартість в грн.";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(841, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(396, 47);
            textBox1.TabIndex = 6;
            textBox1.Text = "0";
            // 
            // button2
            // 
            button2.Location = new Point(1463, 79);
            button2.Name = "button2";
            button2.Size = new Size(170, 70);
            button2.TabIndex = 5;
            button2.Text = "Додати ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SaveVentilation_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(358, 42);
            label5.Name = "label5";
            label5.Size = new Size(247, 41);
            label5.TabIndex = 4;
            label5.Text = "Потужність в кВт";
            // 
            // textBoxPower
            // 
            textBoxPower.Location = new Point(358, 102);
            textBoxPower.Name = "textBoxPower";
            textBoxPower.Size = new Size(396, 47);
            textBoxPower.TabIndex = 3;
            textBoxPower.Text = "0";
            textBoxPower.TextChanged += textBox_TextChanged_floatFilter;
            textBoxPower.KeyDown += textBoxPower_KeyDown;
            textBoxPower.KeyPress += textBoxPower_KeyPress;
            textBoxPower.Leave += textBoxPower_Leave;
            // 
            // button1
            // 
            button1.Location = new Point(21, 79);
            button1.Name = "button1";
            button1.Size = new Size(286, 70);
            button1.TabIndex = 1;
            button1.Text = "Виберіть файл";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 20);
            label4.Name = "label4";
            label4.Size = new Size(225, 41);
            label4.TabIndex = 0;
            label4.Text = "Шлях до файлу";
            // 
            // TableSaveVentilation
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 1021);
            Controls.Add(tableLayoutPanel1);
            Name = "TableSaveVentilation";
            Text = "Таблиця збереження кондиціонерів";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private ListBox listBox1;
        private Label label2;
        private TextBox textBoxEditVent;
        private Label label1;
        private PictureBox pictureBoxPhoto;
        private Panel panel2;
        private Button button2;
        private Label label5;
        private TextBox textBoxPower;
        private Button button1;
        private Label label4;
        public Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem оновитиToolStripMenuItem;
        private ToolStripMenuItem видалитиВентиляціюToolStripMenuItem;
        private Label label6;
        private TextBox textBox1;
        private Label label7;
        private TextBox textBox2;
    }
}