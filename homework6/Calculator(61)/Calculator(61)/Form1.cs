using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private string inputValue = "";
        private string tempValue = "";
        private string operation = "";
        private int state = 0;
        /// <summary>
        /// state = 0 Ввод
        /// state = 1 Ошибка
        /// state = 2 Есть результат
        /// </summary>

        private CalculatorFunction calculator = new CalculatorFunction();

        public Calculator()
        {
            InitializeComponent();
        }

        private bool IsOperation(object sender)
        {
            return ((sender as Button).Text == "-" || (sender as Button).Text == "+" || (sender as Button).Text =="/" || (sender as Button).Text == "*");
        }

        /// <summary>
        /// Записывает введенный символ
        /// </summary>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (state == 1 || (!(IsOperation(sender)) && state == 2))
            {
                Reset();
            }
            textBox1.Text = textBox1.Text + (sender as Button).Text;
        }
        
        /// <summary>
        /// Записывает оператор и считает промежуточное значение, если нужно
        /// </summary>
        /// <param name="strOperator"> Оператор для записи</param>
        /// <exception> Исключение, когда неправильный ввод или деление на ноль</exception>
        private void Operation(string strOperator )
        {
            try
            {
                if (operation == "")
                {
                    inputValue = textBox1.Text;
                }
                else
                {
                    tempValue = textBox1.Text;
                    inputValue = calculator.Calculate(inputValue, tempValue, operation);
                }
                operation = strOperator;
                textBox1.Text = "";
                state = 0;
            }
            catch (Exception error) when (error is InputErrorException || error is DivideByZeroException)
            {
                textBox1.Text = error.Message;
                state = 1;
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                tempValue = textBox1.Text;
                string str = calculator.Calculate(inputValue, tempValue, operation);
                textBox1.Text = str;
                operation = "";
                state = 2;
            }
            catch (Exception error) when (error is InputErrorException || error is DivideByZeroException)
            {
                textBox1.Text = error.Message;
                state = 1;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Operation("+");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Operation("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Operation("*");
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            Operation("/");
        }

        private void buttonClearError_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Сбрасывает все значения
        /// </summary>
        private void Reset()
        {
            textBox1.Text = "";
            inputValue = "";
            tempValue = "";
            operation = "";
            state = 0;
        }
    }
}
