using System.Text;

/// <summary>
/// A class for creating and calculation a parse tree.
/// </summary>
public class ParseTree
{
    private readonly Node root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParseTree"/> class.
    /// </summary>
    /// <param name="path">Path to the parse tree file.</param>
    public ParseTree(string path)
    {
        string expression = File.ReadAllText(path);
        this.root = this.CreateParseTree(expression.Split()).Item1;
    }

    /// <summary>
    /// Parsing tree output.
    /// </summary>
    /// <returns>Parsing Tree.</returns>
    public string PrintParseTree()
    {
        var parseTreeExpression = this.root.Print();
        Console.WriteLine();
        return parseTreeExpression;
    }

    /// <summary>
    /// Calculating an expression using the parse tree.
    /// </summary>
    /// <returns>Calculation result.</returns>
    public int Calculate()
    {
        TreeTraversal((Operator)this.root);
        return this.root.Value;
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

    private (Node, int, int) CreateParseTree(string[] expression)
    {
        if (expression[0] == string.Empty)
        {
            throw new IncorrectInputException("Empty file.");
        }

        if (expression[0][0] == '(' && expression[0].Length == 2 &
            (expression[0][1] == '+' || expression[0][1] == '-' ||
            expression[0][1] == '*' || expression[0][1] == '/'))
        {
            var j = 2;
            Node leftOperand, rightOperand;
            if (expression[1][0] == '(')
            {
                (leftOperand, var currentElement, _) = this.CreateParseTree(expression[1..]);
                j += currentElement;
            }
            else
            {
                var stringNumber = new StringBuilder();
                int number;
                foreach (var element in expression[1])
                {
                    if (element > '9' || element < '0')
                    {
                        throw new IncorrectOperandException("Operand is not a number.");
                    }

                    stringNumber.Append(element);
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

            var currentPosition = 0;
            if (expression[j][0] == '(')
            {
                (rightOperand, var k, currentPosition) = this.CreateParseTree(expression[j..]);
                j += k;
            }
            else
            {
                var stringNumber = new StringBuilder();
                int number;
                var i = 0;
                while (expression[j][i] != ')')
                {
                    if (expression[j][i] > '9' || (int)expression[j][i] < '0')
                    {
                        throw new IncorrectOperandException("Operand is not a number.");
                    }

                    stringNumber.Append(expression[j][i]);
                    ++i;
                }

                currentPosition = i;
                if (int.TryParse(stringNumber.ToString(), out number))
                {
                    rightOperand = new NumberOperand(number);
                }
                else
                {
                    throw new IncorrectOperandException("Operand is not a number.");
                }
            }

            if (expression[j].Length > currentPosition && expression[j][currentPosition] == ')')
            {
                switch (expression[0][1])
                {
                    case '+':
                        return (new AdditionOperator(leftOperand, rightOperand), j, ++currentPosition);
                    case '-':
                        return (new SubtractionOperator(leftOperand, rightOperand), j, ++currentPosition);
                    case '*':
                        return (new MultiplicationOperator(leftOperand, rightOperand), j, ++currentPosition);
                    case '/':
                        return (new DivisionOperator(leftOperand, rightOperand), j, ++currentPosition);
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
            throw new IncorrectInputException("The expression has an imbalance of brackets.");
        }
    }
}