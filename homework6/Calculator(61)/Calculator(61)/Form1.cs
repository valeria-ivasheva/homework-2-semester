using System;
using System.Windows.Forms;

namespace Calculator_61_
{
    public partial class Calculator : Form
    {
        private string inputValue = "";
        private string tempValue = "";
        private string operation = "";

        private CalculatorFunction calculator = new CalculatorFunction();

        public Calculator()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
        
        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Записывает введенный символ
        /// </summary>
        /// <param name="inputStr"> Введенный символ</param>
        private void Input(string inputStr)
        {
            if (textBox1.Text == "Input Error" || textBox1.Text == "Divide by zero :(")
            {
                Reset();
            }
            textBox1.Text = textBox1.Text + inputStr;
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
            }
            catch (Exception e)
            {
                textBox1.Text = e.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Input("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Input("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Input("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Input("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Input("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Input("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Input("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
           Input("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Input("0");
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                tempValue = textBox1.Text;
                string str = calculator.Calculate(inputValue, tempValue, operation);
                textBox1.Text = str;
                operation = "";
            }
            catch (Exception error)
            {
                textBox1.Text = error.Message;
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

        private void buttonDot_Click(object sender, EventArgs e)
        {
            Input(",");
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
        }
    }
}
