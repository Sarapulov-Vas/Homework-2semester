int[] sortingArray = new int[] {10, 23, 20, 19, 12, 27, 44, 15, 10, 5};

void printArray(int[] array)
{
    foreach(var element in array)
    {
        Console.Write($"{element} ");
    }
}

void bubleSort(int[] sortingArray)
{
    for (int i = 0; i<sortingArray.Length; ++i)
    {
        for (int j = 1; j<sortingArray.Length; ++j)
        {
            if (sortingArray[j-1] >= sortingArray[j])
            {
                (sortingArray[j-1], sortingArray[j]) = (sortingArray[j], sortingArray[j-1]);
            }
        }
    }
}

bubleSort(sortingArray);
printArray(sortingArray);
