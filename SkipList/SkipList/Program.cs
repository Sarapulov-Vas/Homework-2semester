namespace SkipList;
internal class Program
{
    public static void Main(string[] args)
    {
        //var a = new SkipList<int>(new List<int>() {10, 2, 30, 4, 50, 6, 17, 88, 90, 10});
        var a = new SkipList<int>();
        a.Add(10);
        a.Add(2);
        a.Add(30);
        a.Add(5);
        a.Add(25);
        a.Add(62);
    }
}