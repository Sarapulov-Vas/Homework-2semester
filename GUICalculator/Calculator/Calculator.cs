using System.Text;

namespace Calculator
{
    /// <summary>
    /// A class that implements a calculator.
    /// </summary>
    public class Calculator
    {
        private double firstNumber;
        private double secondNumber;
        private StringBuilder currentNumber = new();
        private Operations operation;
        private bool inputFirstNumber = false;
        private double epsilon = 1e-10;
        private bool usePoint = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class.
        /// </summary>
        public Calculator()
        {
            currentNumber.Append(0);
        }

        /// <summary>
        /// Enumeration of operations.
        /// </summary>
        public enum Operations
        {
            /// <summary>
            /// Addition operation.
            /// </summary>
            Addition,

            /// <summary>
            /// Subtraction operation.
            /// </summary>
            Subtraction,

            /// <summary>
            /// Multiplication operation.
            /// </summary>
            Multiplication,

            /// <summary>
            /// Division operation.
            /// </summary>
            Division,
        }

        /// <summary>
        /// Method adding a digit to a number.
        /// </summary>
        /// <param name="digit">Digit to add.</param>
        /// <returns>Current number.</returns>
        public string AddDigit(int digit)
        {
            if (currentNumber.Length <= 16)
            {
                if (currentNumber.ToString() == "0")
                {
                    if (digit != 0)
                    {
                        currentNumber.Clear();
                    }
                    else
                    {
                        return currentNumber.ToString();
                    }
                }

                currentNumber.Append(digit);
            }

            return currentNumber.ToString();
        }

        /// <summary>
        /// A method that adds a point to a number.
        /// </summary>
        /// <returns>Current number.</returns>
        public string AddPoint()
        {
            if (usePoint == false)
            {
                currentNumber.Append(',');
                usePoint = true;
            }

            return currentNumber.ToString();
        }

        /// <summary>
        /// A method that removes a digit from the end of a number.
        /// </summary>
        /// <returns>Current number.</returns>
        public string BackSpace()
        {
            if (currentNumber.Length > 0)
            {
                currentNumber.Remove(currentNumber.Length - 1, 1);
            }

            if (currentNumber.Length == 0)
            {
                currentNumber.Append(0);
            }

            return currentNumber.ToString();
        }

        /// <summary>
        /// Method deleting the current number.
        /// </summary>
        /// <returns>A string without a deleted number.</returns>
        public string DelateCurrentNumber()
        {
            currentNumber.Clear();
            currentNumber.Append(0);
            return currentNumber.ToString();
        }

        /// <summary>
        /// Method resetting calculations.
        /// </summary>
        public void ClearAll()
        {
            firstNumber = 0;
            secondNumber = 0;
            inputFirstNumber = false;
            currentNumber.Clear();
            currentNumber.Append(0);
        }

        /// <summary>
        /// Method calling statement.
        /// </summary>
        /// <param name="operation">Operation.</param>
        /// <returns>Calculation result.</returns>
        public double UseOperation(Operations operation)
        {
            if (inputFirstNumber == false)
            {
                this.operation = operation;
                inputFirstNumber = true;
                firstNumber = double.Parse(currentNumber.ToString());
                currentNumber.Clear();
            }
            else
            {
                secondNumber = double.Parse(currentNumber.ToString());
                currentNumber.Clear();
                firstNumber = Calculate(this.operation);
                this.operation = operation;
            }

            currentNumber.Append(0);
            usePoint = false;
            return firstNumber;
        }

        /// <summary>
        /// Method of calculating the result.
        /// </summary>
        /// <returns>Calculated result.</returns>
        public double GetResult()
        {
            secondNumber = double.Parse(currentNumber.ToString());
            firstNumber = Calculate(operation);
            currentNumber = new (firstNumber.ToString());
            inputFirstNumber = false;
            usePoint = false;
            return firstNumber;
        }

        private double Calculate(Operations opeartion)
        {
            switch (opeartion)
            {
                case Operations.Addition:
                    return firstNumber + secondNumber;
                case Operations.Subtraction:
                    return firstNumber - secondNumber;
                case Operations.Multiplication:
                    return firstNumber * secondNumber;
                case Operations.Division:
                    if (Math.Abs(secondNumber) < epsilon)
                    {
                        throw new DivideByZeroException();
                    }

                    return firstNumber / secondNumber;
                default:
                    throw new ArgumentException("Unsupported operation.");
            }
        }
    }
}
