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

string InverseBWT(string BWTString, int endIndex)
{   
    char[] characters = BWTString.Distinct().ToArray();
    int[] characterIndex = new int[characters.Length];
    int[] sortedIndexes = new int[BWTString.Length];
    char[] originalString = new char[BWTString.Length];
    Array.Sort(characters);
    for (int i = 1; i<characters.Length; i++)
    {
        characterIndex[i] = BWTString.Where(c => c == characters[i-1]).Count() + characterIndex[i-1];
    }
    for (int i = 0; i<BWTString.Length; i++)
    {
        sortedIndexes[i] = characterIndex[Array.IndexOf(characters, BWTString[i])];
        characterIndex[Array.IndexOf(characters, BWTString[i])]++;
    }
    originalString[^1] = BWTString[endIndex];
    for (int i = 1; i<BWTString.Length; i++)
    {
        originalString[^(i+1)] = BWTString[sortedIndexes[endIndex]];
        endIndex = sortedIndexes[endIndex];
    }
    return new string(originalString);
}

string? inputString = Console.ReadLine();
var result = BWT(inputString + "$");
Console.Write($"{result.Item1} ");
Console.WriteLine(result.Item2);
Console.WriteLine(InverseBWT(result.Item1, result.Item2));