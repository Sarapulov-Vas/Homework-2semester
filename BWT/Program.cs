(string, int) BWT(string inputString){
    int[] suffixArray = new int[inputString.Length];
    var resultString = new char[inputString.Length];
    int endIndex;
    for (int i = 0; i < inputString.Length; i++)
    {   
        suffixArray[i] = i;
    }
    Array.Sort(suffixArray, (x, y) => string.CompareOrdinal(inputString[x..] + inputString[..x], inputString[y..] + inputString[..y]));
    endIndex = Array.IndexOf(suffixArray, 0);
    for (int i = 0; i < inputString.Length; i++)
    {   
        if (suffixArray[i] == 0)
        {
            resultString[i] = inputString[^1];
        }
        else
        {
            resultString[i] = inputString[suffixArray[i] - 1];
        }
    }
    return (new string(resultString), endIndex);
}

string InverseBWT(string BWTString, int endIndex)
{   
    if (BWTString.Length == 0)
    {
        return "";
    }
    char[] characters = BWTString.Distinct().ToArray();
    int[] characterIndex = new int[characters.Length];
    int[] sortedIndexes = new int[BWTString.Length];
    char[] originalString = new char[BWTString.Length];
    Array.Sort(characters);
    for (int i = 1; i < characters.Length; i++)
    {   
        characterIndex[i] = BWTString.Where(sign => sign == characters[i-1]).Count() + characterIndex[i-1];
    }
    for (int i = 0; i < BWTString.Length; i++)
    {
        sortedIndexes[i] = characterIndex[Array.IndexOf(characters, BWTString[i])];
        characterIndex[Array.IndexOf(characters, BWTString[i])]++;
    }
    originalString[^1] = BWTString[endIndex];
    for (int i = 1; i < BWTString.Length; i++)
    {   
        endIndex = sortedIndexes[endIndex];
        originalString[^(i+1)] = BWTString[endIndex];
    }
    return new string(originalString);
}

bool test1()
{
    string str = "KARKARKAR";
    var result = BWT(str);
    if (string.Equals(result.Item1, "KKKRRRAAA") && result.Item2 == 3 && string.Equals(InverseBWT(result.Item1, result.Item2), str))
    {
        return true;
    }
    return false;
}

bool test2()
{
    string str = "ABCabc.ABC/abcABCABC.abc";
    var result = BWT(str);
    if (string.Equals(result.Item1, "cCCC.ccAAAABBBBC/.aaabbb") && result.Item2 == 6 && string.Equals(InverseBWT(result.Item1, result.Item2), str))
    {
        return true;
    }
    return false;
}

bool test3()
{
    string str = "";
    var result = BWT(str);
    if (string.Equals(result.Item1, "") && string.Equals(InverseBWT(result.Item1, result.Item2), str))
    {
        return true;
    }
    return false;
}

bool test()
{
    bool[] tests = {test1(), test2(), test3()};
    bool result = true;
    for (int i = 0; i < 3; i++)
    {
        if (tests[i] == true){
            Console.WriteLine($"Test {i + 1} passed");
        }
        else
        {
            Console.WriteLine($"Test {i + 1} failed");
            result = false;       
        }
    }
    return result;
}

if (test() == false)
{
    Environment.Exit(-1);
}

string? inputString = Console.ReadLine();
if (inputString != null)
{
    var result = BWT(inputString);
    Console.Write($"\n{result.Item1} ");
    Console.WriteLine($"{result.Item2}\n");
    Console.WriteLine(InverseBWT(result.Item1, result.Item2));
}else{
    Console.WriteLine("Wrong input!");
}