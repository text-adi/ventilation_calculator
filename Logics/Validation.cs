using System.Net.NetworkInformation;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace VentilationCalculator.Logics
{
    internal class Validation
    {
        public static double CheckInputValue(string value, string msg = "Помилка! Значення не може дорівнювати, або бути менше нуля")
        {

            double parse_value = Convert.ToDouble(value);
            if (parse_value <= 0)
            {
                MessageBox.Show(msg);
            }
            return parse_value;

        }

        public static void intNumberFilter(TextBox textBox)
        {
            string input = textBox.Text;
            int cursorPosition = textBox.SelectionStart;
            if (string.IsNullOrEmpty(input))
            {
                textBox.Text = "0";
                textBox.SelectionStart = 1;

                return;
            }
            if (input.StartsWith("0") && input.Length > 1)
            {
                input = input.Substring(1);
                textBox.SelectionStart = 1;

            }


            var value = input.Where(char.IsDigit);
            string digitsOnly = new(value.ToArray());
            if (input != digitsOnly)
            {
                textBox.Text = digitsOnly;
                if (cursorPosition > 1) textBox.SelectionStart = cursorPosition - 1;
            }

        }
        public static void floatNumberFilter(TextBox textBox)
        {
            string input = textBox.Text;
            int cursorPosition = textBox.SelectionStart;
            if (string.IsNullOrEmpty(input))
            {
                textBox.Text = "0";
                textBox.SelectionStart = 1;
                return;
            }
            else if (input.StartsWith("0") && input.Length > 1 && input[1] != ',')
            {
                textBox.Text = input[1..];
                textBox.SelectionStart = 1;

            }
            else if (input.StartsWith(","))
            {
                textBox.Text = string.Concat('0', input);
                textBox.SelectionStart = 1;
            }

            var value = input.Where(c => char.IsDigit(c) || c == ',');

            string digitsOnly = new(value.ToArray());

            if (value.Count(c => c == ',') >= 2)
            {
                digitsOnly = string.Concat(digitsOnly.AsSpan(0, cursorPosition - 1), digitsOnly.AsSpan(cursorPosition));
            }


            if (input != digitsOnly)
            {
                textBox.Text = digitsOnly;
                if (cursorPosition > 1) textBox.SelectionStart = cursorPosition - 1;

            }

            //textBox.Text = Convert.ToDouble(textBox.Text).ToString();


        }
        public static void limitValue(TextBox textBox, int maxValue)
        {
            string input = textBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                textBox.Text = "0";
                textBox.SelectionStart = 1;

                return;
            }
            else if (input.StartsWith("0") && input.Length > 1)
            {
                textBox.Text = input[1..];
                textBox.SelectionStart = 1;

            }

            int cursorPosition = textBox.SelectionStart;
            if (Convert.ToInt32(input) > maxValue)
            {
                textBox.Text = string.Concat(input.AsSpan(0, cursorPosition - 1), input.AsSpan(cursorPosition));
                if (cursorPosition > 1) textBox.SelectionStart = cursorPosition - 1;

            }

            textBox.Text = Convert.ToInt32(textBox.Text).ToString();

        }

    }
    public class IntValidator
    {
        object sender;
        TextBox textBox;
        public IntValidator(object sender)
        {
            this.textBox = (TextBox)sender;
            this.sender = sender;

        }
        public void Leave(EventArgs e)
        { 
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                //встановити 0, якщо textBox пустий
                textBox.Text = "0";
            }
        }
        public void KeyUP(KeyEventArgs e, double min, double max)
        {
            if (Convert.ToDouble(textBox.Text) > max)
            {
                textBox.Text = max.ToString();
                textBox.SelectionStart = 999;
                e.Handled = true;

            }
            KeyUP(e, min);
        }
        public void KeyUP(KeyEventArgs e, double min)
        {
            if (Convert.ToDouble(textBox.Text) < min)
            {
                textBox.Text = min.ToString();
                textBox.SelectionStart = 999;
                e.Handled = true;

            }

        }

        public void KeyPress(KeyPressEventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(textBox.Text);

                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    // Заборонити введення текстових символів
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar == ',')
                {
                    // заборонити ведення більше одної коми
                    e.Handled = true;
                    return;
                }

                // замінити одне число, якщо видалемо
                if (e.KeyChar == '\b' && textBox.Text.Length == 1)
                {
                    stringBuilder[0] = '0';
                    textBox.Text = stringBuilder.ToString();
                    textBox.SelectionStart = 1;
                    e.Handled = true;
                    return;
                }
                // замінити при натискані на число, 0, але проігнорити кому
                if (textBox.Text[0] == '0' && textBox.Text.Length == 1)
                {
                    stringBuilder.Remove(0, 1);
                    textBox.Text = stringBuilder.ToString();
                    return;
                }

            }
            catch { }


        }
    }
    public class Validator
    {
        TextBox textBox;
        public Validator(object sender)
        {
            this.textBox = (TextBox)sender;
  

        }
        public Validator(TextBox textBox)
        {
            this.textBox = textBox;

        }

        public void Leave(EventArgs e)
        {
            if (textBox.Text.EndsWith(","))
            {
                // Видалити кому з кінця тексту
                textBox.Text = textBox.Text.TrimEnd(',');
            }
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text.StartsWith(","))
            {
                //встановити 0, якщо textBox пустий
                textBox.Text = "0";
            }
        }


        public void KeyUP( double min, double max)
        {
            if (Convert.ToDouble(textBox.Text) > max)
            {
                textBox.Text = max.ToString();
                textBox.SelectionStart = 999;

            }
            KeyUP(min);
        }
        public void KeyUP(double min)
        {
            if (Convert.ToDouble(textBox.Text) < min)
            {
                textBox.Text = min.ToString();
                textBox.SelectionStart = 999;

            }

        }

        public void KeyPress(KeyPressEventArgs e)
        {
            try
            {
                string[] parts = textBox.Text.Split(',');
                StringBuilder stringBuilder = new StringBuilder(textBox.Text);


                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
                {
                    // Заборонити введення текстових символів
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar == ',' && textBox.Text.Count(c => c == ',') > 0)
                {
                    // заборонити ведення більше одної коми
                    e.Handled = true;
                    return;
                }

                // замінити одне число, якщо видалемо
                if (e.KeyChar == '\b' && textBox.Text.Length == 1)
                {
                    stringBuilder[0] = '0';
                    textBox.Text = stringBuilder.ToString();
                    textBox.SelectionStart = 1;
                    e.Handled = true;
                    return;
                }
                // замінити при натискані на число, 0, але проігнорити кому
                if (textBox.Text[0] == '0' && textBox.Text.Length == 1 && e.KeyChar != ',')
                {
                    stringBuilder.Remove(0, 1);
                    textBox.Text = stringBuilder.ToString();
                    return;
                }

            }
            catch { }


        }
    }
}
