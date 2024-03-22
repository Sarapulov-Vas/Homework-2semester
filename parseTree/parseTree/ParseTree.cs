using System.Text;
using System.Xml.Serialization;

internal class ParseTree
{
    private Node root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParseTree"/> class.
    /// </summary>
    /// <param name="path">Path to the parse tree file.</param>
    public ParseTree(string path)
    {
        string expression = File.ReadAllText(path);
        root = CreateParseTree(expression).Item1;
    }

    /// <summary>
    /// Parsing tree output.
    /// </summary>
    public void PrintParseTree()
    {
        root.Print();
        Console.WriteLine();
    }

    /// <summary>
    /// Calculating an expression using the parse tree.
    /// </summary>
    /// <returns>Calculation result.</returns>
    public int Calculate()
    {
        TreeTraversal((Operator)root);
        Console.WriteLine(root.Value);
        return root.Value;
    }

    private static void TreeTraversal(Operator currentNode)
    {
        if (currentNode.LeftOperand.GetType() != typeof(NumberOperand))
        {
            TreeTraversal((Operator)currentNode.LeftOperand);
        }

        if (currentNode.RightOperand.GetType() != typeof(NumberOperand))
        {
            TreeTraversal((Operator)currentNode.RightOperand);
        }

        currentNode.Calculate();
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

            if (expression[i] == ')')
            {
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
        else
        {
            throw new IncorrectInputException("Incorrect parse tree.");
        }
    }
}