interface IStack
{   
    void Push(int value);
    int Pop();
    int Length { get; set; }
}
class ListStack : IStack
{
    public int Length { get; set; }
    public List<int> stack = new List<int>();
    void IStack.Push(int value)
    {   
        stack.Add(value);
        Length = stack.Count;
    }
    int IStack.Pop()
    {
        int value = stack[^1];
        stack.RemoveAt(stack.Count - 1);
        Length = stack.Count;
        return value;
    }
}

class ArrayStack : IStack
{
    public int Length { get; set; }
    public int[] stack = new int[0];
    void IStack.Push(int value)
    {   
        Length = stack.Length + 1;
        Array.Resize(ref stack, Length);
        stack[^1] = value;
    }
    int IStack.Pop()
    {
        int value = stack[^1];
        Array.Resize(ref stack, Length - 1);
        Length = stack.Length;
        return value;
    }
}

class MainClass
{
    static void Main()
    {
        IStack stack = new ListStack();
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        stack.Push(5);
        Console.WriteLine(stack.Length);
        while (stack.Length != 0){
            Console.WriteLine($"{stack.Pop()} {stack.Length}");
        }
        Console.WriteLine();
        IStack ArrStack = new ArrayStack();
        stack.Push(2);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);
        Console.WriteLine(stack.Length);
        while (stack.Length != 0){
            Console.WriteLine($"{stack.Pop()} {stack.Length}");
        }
    }
}