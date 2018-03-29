using System;

namespace Calculator_61_
{
    public class CalculatorFunction
    {
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
            }
            throw new InputErrorException();
        }
    }
}
