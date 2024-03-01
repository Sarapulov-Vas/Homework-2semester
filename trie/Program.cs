class Program
{
    static void Main()
    {
        Trie trie = new Trie();
        Test.StartTest();
        trie.Add("abc");
        Console.WriteLine(trie.Size);
    }
}