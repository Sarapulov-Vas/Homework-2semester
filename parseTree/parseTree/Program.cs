var a = new MultiplicationOperator(new NumberOperand(1), new NumberOperand(2));
var b = new DivisionOperator(new NumberOperand(3), new NumberOperand(4));
var c = new SubtractionOperator(new NumberOperand(5), b);
var root = new AdditionOperator(a, c);

root.Print();