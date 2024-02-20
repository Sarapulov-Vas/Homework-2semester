Tuple<string, int> BWT(string inputString){
    string[] suffixArray = new string[inputString.Length];
    var resultString= new char[inputString.Length];
    int endIndex;
    suffixArray[0] = inputString;
    for (int i = 1; i<inputString.Length; i++)
    {   
        suffixArray[i] = suffixArray[i-1].Remove(0, 1) + suffixArray[i-1][0];
    }
    Array.Sort(suffixArray);
    for (int i = 0; i<inputString.Length; i++)
    {
        resultString[i] = suffixArray[i][^1];
    }
    endIndex = Array.IndexOf(resultString, inputString[^1]);
    return Tuple.Create(new string(resultString), endIndex);
}


string? str = Console.ReadLine();
var resultString = BWT(str + "$");
Console.WriteLine(resultString.Item1);
Console.WriteLine(resultString.Item2);