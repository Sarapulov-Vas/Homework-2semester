namespace Calculator
{
    using System.Text;

    /// <summary>
    /// A class that implements a calculator.
    /// </summary>
    public class Calculator
    {
        private readonly double epsilon = 1e-10;
        private double firstNumber;
        private double secondNumber;
        private StringBuilder currentNumber = new ();
        private Operations operation;
        private bool inputFirstNumber;
        private bool usePoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class.
        /// </summary>
        public Calculator()
        {
            this.currentNumber.Append(0);
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
            if (this.currentNumber.Length <= 16)
            {
                if (this.currentNumber.ToString() == "0")
                {
                    if (digit != 0)
                    {
                        this.currentNumber.Clear();
                    }
                    else
                    {
                        return this.currentNumber.ToString();
                    }
                }

                this.currentNumber.Append(digit);
            }

            return this.currentNumber.ToString();
        }

        /// <summary>
        /// A method that adds a point to a number.
        /// </summary>
        /// <returns>Current number.</returns>
        public string AddPoint()
        {
            if (this.usePoint == false)
            {
                this.currentNumber.Append(',');
                this.usePoint = true;
            }

            return this.currentNumber.ToString();
        }

        /// <summary>
        /// A method that removes a digit from the end of a number.
        /// </summary>
        /// <returns>Current number.</returns>
        public string BackSpace()
        {
            if (this.currentNumber.Length > 0)
            {
                this.currentNumber.Remove(this.currentNumber.Length - 1, 1);
            }

            if (this.currentNumber.Length == 0)
            {
                this.currentNumber.Append(0);
            }

            return this.currentNumber.ToString();
        }

        /// <summary>
        /// Method deleting the current number.
        /// </summary>
        /// <returns>A string without a deleted number.</returns>
        public string DelateCurrentNumber()
        {
            this.currentNumber.Clear();
            this.currentNumber.Append(0);
            return this.currentNumber.ToString();
        }

        /// <summary>
        /// Method resetting calculations.
        /// </summary>
        public void ClearAll()
        {
            this.firstNumber = 0;
            this.secondNumber = 0;
            this.inputFirstNumber = false;
            this.currentNumber.Clear();
            this.currentNumber.Append(0);
        }

        /// <summary>
        /// Method calling statement.
        /// </summary>
        /// <param name="operation">Operation.</param>
        /// <returns>Calculation result.</returns>
        public double UseOperation(Operations operation)
        {
            if (this.inputFirstNumber == false)
            {
                this.operation = operation;
                this.inputFirstNumber = true;
                this.firstNumber = double.Parse(this.currentNumber.ToString());
                this.currentNumber.Clear();
            }
            else
            {
                this.secondNumber = double.Parse(this.currentNumber.ToString());
                this.currentNumber.Clear();
                this.firstNumber = this.Calculate(this.operation);
                this.operation = operation;
            }

            this.currentNumber.Append(0);
            this.usePoint = false;
            return this.firstNumber;
        }

        /// <summary>
        /// Method of calculating the result.
        /// </summary>
        /// <returns>Calculated result.</returns>
        public double GetResult()
        {
            this.secondNumber = double.Parse(this.currentNumber.ToString());
            this.firstNumber = this.Calculate(this.operation);
            this.currentNumber = new (this.firstNumber.ToString());
            this.inputFirstNumber = false;
            this.usePoint = false;
            return this.firstNumber;
        }

        private double Calculate(Operations opeartion)
        {
            switch (opeartion)
            {
                case Operations.Addition:
                    return this.firstNumber + this.secondNumber;
                case Operations.Subtraction:
                    return this.firstNumber - this.secondNumber;
                case Operations.Multiplication:
                    return this.firstNumber * this.secondNumber;
                case Operations.Division:
                    if (Math.Abs(this.secondNumber) < this.epsilon)
                    {
                        throw new DivideByZeroException();
                    }

                    return this.firstNumber / this.secondNumber;
                default:
                    throw new ArgumentException("Unsupported operation.");
            }
        }
    }
}
