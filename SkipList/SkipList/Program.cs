using System.ComponentModel;

namespace SkipList;
internal class Program
{
    public static void Main(string[] args)
    {
        var a = new SkipList<int>(new List<int> {11, 22, 55, 33});
        a.Add(10);
        a.Add(30);
        a.Add(5);
        a.Clear();
        a.Add(25);
        a.Add(15);
        a.Add(62);
        a.Add(20);
        a.Add(100);
        a.Add(40);
        // a.Remove(15);
        // a.Remove(100);
        // a.Remove(40);
        var b = new int[a.Count];
        a.CopyTo(b, 0);
        foreach (var element in a)
        {
            Console.WriteLine(element);
        }
    }
}