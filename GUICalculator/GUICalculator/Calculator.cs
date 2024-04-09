using System.Text;

namespace GUICalculator
{
    /// <summary>
    /// A class that implements a calculator.
    /// </summary>
    internal class Calculator
    {
        private double firstNumber;
        private double secondNumber;
        private StringBuilder currentNumber = new ();
        private char? operation = null;
        private double epsilon = 1e-10;

        /// <summary>
        /// Method adding a digit to a number.
        /// </summary>
        /// <param name="digit">Digit to add.</param>
        /// <returns>Current number.</returns>
        public string AddDigit(int digit)
        {
            currentNumber.Append(digit);
            return currentNumber.ToString();
        }

        /// <summary>
        /// A method that adds a point to a number.
        /// </summary>
        /// <returns>Current number.</returns>
        public string AddPoint()
        {
            currentNumber.Append('.');
            return currentNumber.ToString();
        }

        /// <summary>
        /// A method that removes a digit from the end of a number.
        /// </summary>
        /// <returns>Current number.</returns>
        public string BackSpace()
        {
            currentNumber.Remove(currentNumber.Length - 1, 1);
            return currentNumber.ToString();
        }

        /// <summary>
        /// Method deleting the current number.
        /// </summary>
        public void DelateCurrentNumber()
        {
            currentNumber.Clear();
        }

        /// <summary>
        /// Method resetting calculations.
        /// </summary>
        public void ClearAll()
        {
            firstNumber = 0;
            secondNumber = 0;
            operation = null;
            currentNumber.Clear();
        }

        /// <summary>
        /// Method calling statement.
        /// </summary>
        /// <param name="operation">Operation.</param>
        /// <returns>Calculation result.</returns>
        public double UseOperation(char operation)
        {
            if (this.operation == null)
            {
                this.operation = operation;
                firstNumber = double.Parse(currentNumber.ToString());
                return firstNumber;
            }
            else
            {
                secondNumber = double.Parse(currentNumber.ToString());
                firstNumber = Calculate(this.operation);
                this.operation = operation;
                return firstNumber;
            }
        }

        /// <summary>
        /// Method of calculating the result.
        /// </summary>
        /// <returns>Calculated result.</returns>
        public double GetResult()
        {
            if (operation == null)
            {
                firstNumber = double.Parse(currentNumber.ToString());
                return firstNumber;
            }
            else
            {
                secondNumber = double.Parse(currentNumber.ToString());
                firstNumber = Calculate(operation);
                return firstNumber;
            }
        }

        private double Calculate(char? opeartion)
        {
            switch (opeartion)
            {
                case '+':
                    return firstNumber + secondNumber;
                case '-':
                    return firstNumber - secondNumber;
                case '*':
                    return firstNumber * secondNumber;
                case '/':
                    if (Math.Abs(secondNumber) < epsilon)
                    {
                        throw new DivideByZeroException();
                    }

                    return firstNumber / secondNumber;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
