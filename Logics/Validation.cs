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
            { textBox.Text = "0";
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
                textBox.Text = input.Substring(1);
                textBox.SelectionStart = 1;

            }
            else if (input.StartsWith(","))
            {
                textBox.Text = string.Concat('0', input);
                textBox.SelectionStart = 1;
            }

            var value = input.Where(c => char.IsDigit(c) || c==',');

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
                textBox.Text = input.Substring(1);
                textBox.SelectionStart = 1;

            }

            int cursorPosition = textBox.SelectionStart;
            string newValue = input;
            if (Convert.ToInt32(input) > maxValue)
            {
                newValue = string.Concat(input.AsSpan(0, cursorPosition - 1), input.AsSpan(cursorPosition));
                textBox.Text = newValue;
                if (cursorPosition > 1) textBox.SelectionStart = cursorPosition - 1;

            }

            textBox.Text = Convert.ToInt32(textBox.Text).ToString();

        }

    }
}
