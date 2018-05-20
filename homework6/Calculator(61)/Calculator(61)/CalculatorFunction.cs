using System;

namespace Calculator
{
    /// <summary>
    /// Класс, отвечающий за логику программы
    /// </summary>
    public class CalculatorFunction
    {
        /// <summary>
        /// Функция, считающая значение арифметической операции
        /// </summary>
        /// <param name="inputValue"> Левый операнд</param>
        /// <param name="nextValue"> Правый операнд</param>
        /// <param name="operation"> Операция, которую нужно выполнить</param>
        /// <exception> Исключение, когда неправильный ввод или деление на ноль</exception>
        /// <returns> Значение выполненной операции</returns>
        public string Calculate(string inputValue, string nextValue, string operation)
        {
            if (inputValue == "")
            {
                throw new InputErrorException("Input error");
            }
            bool inputLeft = Double.TryParse(inputValue, out double valueLeft);
            bool inputRight = Double.TryParse(nextValue, out double valueRight);
            if (!inputLeft || !inputRight)
            {
                throw new InputErrorException("Input Error");
            }
            switch (operation)
            {
                case "-":
                    {
                        return (valueLeft - valueRight).ToString();
                    }
                case "+":
                    {
                        return (valueLeft + valueRight).ToString();
                    }
                case "*":
                    {
                        return (valueLeft * valueRight).ToString();
                    }
                case "/":
                    {
                        if (Math.Abs(valueRight) < 0.00001)
                        {
                            throw new DivideByZeroException("Divide by zero :(");
                        }
                        return (valueLeft / valueRight).ToString();
                    }
                default:
                    {
                        throw new InputErrorException();
                    }
            }
        }
    }
}
