namespace SkipList;
internal class Program
{
    public static void Main(string[] args)
    {
        var a = new SkipList<int>(new List<int> {11, 22, 55, 33});
        a.Add(10);
        a.Add(30);
        a.Add(5);
        a.Add(25);
        a.Add(15);
        a.Clear();
        a.Add(62);
        a.Add(20);
        a.Add(100);
        a.Add(40);
        var b = new int[a.Count];
        a.CopyTo(b, 0);
    }
}