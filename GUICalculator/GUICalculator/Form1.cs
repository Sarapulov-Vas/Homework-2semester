namespace GUICalculator;
using Calculator;

public partial class Form1 : Form
{
    private Calculator calculator = new();
    private string expression;
    private string currentExpression = "0";
    private bool displayResult = false;

    public Form1()
    {
        InitializeComponent();
        TextScale("0");
    }

    private void Number0_Click(object sender, EventArgs e)
    {
        DisplayDigit(0);
    }

    private void Number1_Click(object sender, EventArgs e)
    {
        DisplayDigit(1);
    }

    private void Number2_Click(object sender, EventArgs e)
    {
        DisplayDigit(2);
    }

    private void Number3_Click(object sender, EventArgs e)
    {
        DisplayDigit(3);
    }

    private void Number4_Click(object sender, EventArgs e)
    {
        DisplayDigit(4);
    }

    private void Number5_Click(object sender, EventArgs e)
    {
        DisplayDigit(5);
    }

    private void Number6_Click(object sender, EventArgs e)
    {
        DisplayDigit(6);
    }

    private void Number7_Click(object sender, EventArgs e)
    {
        DisplayDigit(7);
    }

    private void Number8_Click(object sender, EventArgs e)
    {
        DisplayDigit(8);
    }

    private void Number9_Click(object sender, EventArgs e)
    {
        DisplayDigit(9);
    }

    private void Point_Click(object sender, EventArgs e)
    {
        RichTextBox1.Text = expression + calculator.AddPoint();
    }

    private void Addition_Click(object sender, EventArgs e)
    {
        MakeOperation(Calculator.Operations.Addition);
    }

    private void Subtraction_Click(object sender, EventArgs e)
    {
        MakeOperation(Calculator.Operations.Subtraction);
    }

    private void Multiplication_Click(object sender, EventArgs e)
    {
        MakeOperation(Calculator.Operations.Multiplication);
    }

    private void Division_Click(object sender, EventArgs e)
    {
        try
        {
            MakeOperation(Calculator.Operations.Division);
        }
        catch
        {
            RichTextBox1.Text = "NaN";
            calculator.ClearAll();
            expression = string.Empty;
        }
    }

    private void GetResult_Click(object sender, EventArgs e)
    {
        try
        {
            currentExpression = calculator.GetResult().ToString();
            TextScale(currentExpression);
            expression = string.Empty;
            RichTextBox1.Text = currentExpression;
            displayResult = true;
        }
        catch
        {
            RichTextBox1.Text = "NaN";
            calculator.ClearAll();
            expression = string.Empty;
        }
    }

    private void ClearCurrent_Click(object sender, EventArgs e)
    {
        currentExpression = expression + calculator.DelateCurrentNumber();
        TextScale(currentExpression);
        RichTextBox1.Text = currentExpression;
    }

    private void Clear_Click(object sender, EventArgs e)
    {
        calculator.ClearAll();
        currentExpression = "0";
        TextScale(currentExpression);
        RichTextBox1.Text = currentExpression;
        expression = string.Empty;
    }

    private void BackSpace_Click(object sender, EventArgs e)
    {
        currentExpression = expression + calculator.BackSpace();
        TextScale(currentExpression);
        RichTextBox1.Text = currentExpression;
    }

    private void DisplayDigit(int digit)
    {
        if (displayResult == false)
        {
            currentExpression = expression + calculator.AddDigit(digit);
            TextScale(currentExpression);
            RichTextBox1.Text = currentExpression;
        }
        else
        {
            displayResult = false;
            calculator.ClearAll();
            expression = string.Empty;
            var currentExpression = calculator.AddDigit(digit);
            TextScale(currentExpression);
            RichTextBox1.Text = currentExpression;
        }
    }

    private void MakeOperation(Calculator.Operations operation)
    {
        switch (operation)
        {
            case Calculator.Operations.Addition:
                expression = calculator.UseOperation(operation).ToString() + '+';
                break;
            case Calculator.Operations.Subtraction:
                expression = calculator.UseOperation(operation).ToString() + '-';
                break;
            case Calculator.Operations.Multiplication:
                expression = calculator.UseOperation(operation).ToString() + '*';
                break;
            case Calculator.Operations.Division:
                expression = calculator.UseOperation(operation).ToString() + '/';
                break;
        }

        currentExpression = expression + '0';
        TextScale(currentExpression);
        RichTextBox1.Text = currentExpression;
        displayResult = false;
    }

    private void TextScale(string expression)
    {
        RichTextBox1.Font = new System.Drawing.Font("Segoe UI",
            Math.Min(RichTextBox1.Width / (expression.Length * 3 / 2), RichTextBox1.Height / 3));
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.D0:
                DisplayDigit(0);
                return true;
            case Keys.D1:
                DisplayDigit(1);
                return true;
            case Keys.D2:
                DisplayDigit(2);
                return true;
            case Keys.D3:
                DisplayDigit(3);
                return true;
            case Keys.D4:
                DisplayDigit(4);
                return true;
            case Keys.D5:
                DisplayDigit(5);
                return true;
            case Keys.D6:
                DisplayDigit(6);
                return true;
            case Keys.D7:
                DisplayDigit(7);
                return true;
            case Keys.D8:
                DisplayDigit(8);
                return true;
            case Keys.D9:
                DisplayDigit(9);
                return true;
            case Keys.Add:
                MakeOperation(Calculator.Operations.Addition);
                return true;
            case Keys.Subtract:
                MakeOperation(Calculator.Operations.Subtraction);
                return true;
            case Keys.Multiply:
                MakeOperation(Calculator.Operations.Multiplication);
                return true;
            case Keys.Divide:
                MakeOperation(Calculator.Operations.Division);
                return true;
            case Keys.Enter:
                try
                {
                    expression = string.Empty;
                    RichTextBox1.Text = calculator.GetResult().ToString();
                    displayResult = true;
                }
                catch
                {
                    RichTextBox1.Text = "NaN";
                    calculator.ClearAll();
                    expression = string.Empty;
                }

                return true;
            case Keys.Oemcomma:
                RichTextBox1.Text = expression + calculator.AddPoint();
                return true;
            case Keys.Back:
                currentExpression = expression + calculator.BackSpace();
                TextScale(currentExpression);
                RichTextBox1.Text = currentExpression;
                return true;
            case Keys.Delete:
                currentExpression = expression + calculator.DelateCurrentNumber();
                TextScale(currentExpression);
                RichTextBox1.Text = currentExpression;
                return true;
            default:
                return false;
        }
    }

    private void RichTextBox1_Resize(object sender, EventArgs e)
    {
        TextScale(currentExpression);
    }
}
