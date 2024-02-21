Tuple<string, int> BWT(string inputString){
    string[] suffixArray = new string[inputString.Length];
    var resultString= new char[inputString.Length];
    int endIndex = 0;
    suffixArray[0] = inputString;
    for (int i = 1; i<inputString.Length; i++)
    {   
        suffixArray[i] = suffixArray[i-1].Remove(0, 1) + suffixArray[i-1][0];
    }
    Array.Sort(suffixArray);
    for (int i = 0; i<inputString.Length; i++)
    {
        resultString[i] = suffixArray[i][^1];
        if (suffixArray[i] == inputString)
        {
            endIndex = i;
        }
    }
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
        characterIndex[i] = BWTString.Where(sign => sign == characters[i-1]).Count() + characterIndex[i-1];
    }

    for (int i = 0; i<BWTString.Length; i++)
    {
        sortedIndexes[i] = characterIndex[Array.IndexOf(characters, BWTString[i])];
        characterIndex[Array.IndexOf(characters, BWTString[i])]++;
    }
    originalString[^1] = BWTString[endIndex];
    for (int i = 1; i<BWTString.Length; i++)
    {   
        endIndex = sortedIndexes[endIndex];
        originalString[^(i+1)] = BWTString[endIndex];
    }
    return new string(originalString);
}

string? inputString = Console.ReadLine();
if (inputString != null)
{
    var result = BWT(inputString);
    Console.Write($"{result.Item1} ");
    Console.WriteLine(result.Item2);
    Console.WriteLine(InverseBWT(result.Item1, result.Item2));
}else{
    Console.WriteLine();
}