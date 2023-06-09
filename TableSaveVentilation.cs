﻿using VentilationCalculator.Logics;
using VentilationCalculator.Models;
using TextBox = System.Windows.Forms.TextBox;

namespace VentilationCalculator
{
    public partial class TableSaveVentilation : Form
    {

        OpenFileDialog openFileDialog;
        public TableSaveVentilation()
        {
            InitializeComponent();
            RefreshList();

            RefreshPicture();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Images Files(*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";  // Фільтр файлів, які можна вибрати
            DialogResult result = openFileDialog.ShowDialog();

            /*if (result == DialogResult.OK)
            {
                return;
                label4.Text = openFileDialog.FileName;

            }*/
        }

        private void SaveVentilation_Click(object sender, EventArgs e)
        {
            using SystemContext db = new();
            if (openFileDialog == null)
            {
                MessageBox.Show("Не можна зберегти дані, так як фото кондиціонера не вибрано", "Збереження кондиціонера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Не можна зберегти дані, так як назва кондиціонера не вказана", "Збереження кондиціонера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DateTime currentTime = DateTime.UtcNow;
                long timestamp = currentTime.Ticks / TimeSpan.TicksPerSecond;
                Directory.CreateDirectory("images");
                string path = "images\\" + timestamp + ".png";
                File.Copy(openFileDialog.FileName, path);

                var newInputData = new VentilatorTable
                {

                    PathToFile = path,

                    Power = Convert.ToDouble(textBoxPower.Text),
                    Price = Convert.ToInt32(textBoxPrice.Text),
                    Name = textBoxName.Text,
                };
                db.VirantVentilator.Add(newInputData);
                db.SaveChanges();
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при копіюванні та збереженні фото: " + ex.Message);
            }
        }
        private void RefreshList()
        {
            using SystemContext db = new();

            var inputData = db.VirantVentilator.ToList();

            listBox1.DataSource = inputData;
            listBox1.DisplayMember = "Name";
            listBox1.SelectedItem = -1;

        }
        private void RefreshPicture()
        {
            VentilatorTable selectObject = (VentilatorTable)listBox1.SelectedItem;
            if (selectObject != null)
            {
                textBoxEditVent.Text = selectObject.Power.ToString();
                textBoxPriceView.Text = selectObject.Price.ToString();
                pictureBoxPhoto.Image = Image.FromFile(selectObject.PathToFile);
            }
            else
            {
                pictureBoxPhoto.Image = null;
            }

        }
        private void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }


        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {

                RefreshPicture();

            }
        }

        private void видалитиВентиляціюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                VentilatorTable selectObject = (VentilatorTable)listBox1.SelectedItem;
                using SystemContext db = new();
                VentilatorTable itemToDelete = db.VirantVentilator.Find(selectObject.Id);

                if (itemToDelete != null)
                {
                    // Видаляємо елемент з контексту та бази даних
                    db.VirantVentilator.Remove(itemToDelete);
                    db.SaveChanges();

                    // Оновлюємо ListBox, щоб відобразити новий стан списку
                    RefreshList();
                    RefreshPicture();
                }
            }
        }

        private void textBox_TextChanged_floatFilter(object sender, EventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //Validation.floatNumberFilter(textBox);
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }
            if (string.IsNullOrWhiteSpace(input) && input.StartsWith(","))
            {
                // Додати "0" перед комою
                textBox.Text = "0" + input;
                textBox.SelectionStart = textBox.Text.Length;
            }
            if (!string.IsNullOrEmpty(input) && input.StartsWith("0"))
            {
                int zeroCount = input.Count(c => c == '0');

                if (zeroCount > 1)
                {
                    // Заборонити введення додаткових нулів
                    textBox.Text = "0";
                    textBox.SelectionStart = 1;
                }
            }


            if (input.Length > 1 && input.StartsWith("0") && char.IsDigit(input[1]))
            {
                // Видалити "0" з початку тексту
                textBox.Text = input.Substring(1);
                textBox.SelectionStart = textBox.Text.Length;
            }


        }

        private void textBoxPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (e.KeyChar == '\b' && textBox.Text.Length == 3 && textBox.Text.StartsWith("0"))
            {
                e.Handled = true; // Заборонити видалення числа перед комою
            }

            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true; // Заборонити додаткову обробку символу коми
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                // Заборонити введення текстових символів
                e.Handled = true;
            }




        }

        private void textBoxPower_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.EndsWith(","))
            {
                // Видалити кому з кінця тексту
                textBox.Text = textBox.Text.TrimEnd(',');
            }
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }

        }

        private void textBox_IntLeave(object sender, EventArgs e)
        {
            new Validator(sender).Leave(e);
        }

        private void textBox_IntKeyPress(object sender, KeyPressEventArgs e)
        {
            new IntValidator(sender).KeyPress(e);
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Validator(sender).KeyPress(e);
        }


    }
}
