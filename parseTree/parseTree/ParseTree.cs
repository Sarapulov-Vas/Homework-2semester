using System.Text;

internal class ParseTree
{
    private Node root;

    public ParseTree(string path)
    {
        string expression = File.ReadAllText(path);
        root = CreateParseTree(expression).Item1;
    }

    private (Node, int) CreateParseTree(string expression)
    {
        if (expression[0] == '(' && expression[2] == ' ' &&
            (expression[1] == '+' || expression[1] == '-' || expression[1] == '*' || expression[1] == '/'))
        {
            int i = 3;
            Node leftOperand, rightOperand;
            if (expression[i] == '(')
            {
                int j = 0;
                (leftOperand, j) = CreateParseTree(expression[i..]);
                i += j;
            }
            else
            {
                var stringNumber = new StringBuilder();
                int number;
                while (expression[i] != ' ')
                {
                    if ((int)expression[i] > 57 || (int)expression[i] < 48)
                    {
                        throw new IncorrectOperandException("Operand is not a number.");
                    }

                    stringNumber.Append(expression[i]);
                    ++i;
                }

                if (int.TryParse(stringNumber.ToString(), out number))
                {
                    leftOperand = new NumberOperand(number);
                }
                else
                {
                    throw new IncorrectOperandException("Operand is not a number.");
                }
            }

            ++i;
            if (expression[i] == '(')
            {
                int j = 0;
                (rightOperand, j) = CreateParseTree(expression[i..]);
                i += j;
            }
            else
            {
                var stringNumber = new StringBuilder();
                int number;
                while (expression[i] != ')')
                {
                    if ((int)expression[i] > 57 || (int)expression[i] < 48)
                    {
                        throw new IncorrectOperandException("Operand is not a number.");
                    }

                    stringNumber.Append(expression[i]);
                    ++i;
                }

                if (int.TryParse(stringNumber.ToString(), out number))
                {
                    rightOperand = new NumberOperand(number);
                }
                else
                {
                    throw new IncorrectOperandException("Operand is not a number.");
                }
            }

            switch (expression[1])
            {
                case '+':
                    return (new AdditionOperator(leftOperand, rightOperand), i + 1);
                case '-':
                    return (new SubtractionOperator(leftOperand, rightOperand), i + 1);
                case '*':
                    return (new MultiplicationOperator(leftOperand, rightOperand), i + 1);
                case '/':
                    return (new DivisionOperator(leftOperand, rightOperand), i + 1);
                default:
                    throw new IncorrectInputException("Unsupported Operation.");
            }
        }
        else
        {
            throw new IncorrectInputException("Incorrect parse tree.");
        }
    }
}