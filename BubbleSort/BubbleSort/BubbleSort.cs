namespace BubbleSort;

/// <summary>
/// A class that implements bubbleclm sorting.
/// </summary>
public class BubbleSort
{
    /// <summary>
    /// A method implementing bubble sorting.
    /// </summary>
    /// <typeparam name="T">Type of list items.</typeparam>
    /// <param name="list">List of sorted elements.</param>
    /// <param name="comparer">Object comparing elements.</param>
    /// <returns>Sorted list.</returns>
    public static List<T> Sort<T>(IEnumerable<T> list, IComparer<T> comparer)
    {
        if (list == null || comparer == null)
        {
            throw new ArgumentNullException("Arguments cannot be null.");
        }

        var listToSort = list.ToList();
        for (int i = 0; i < list.Count(); ++i)
        {
            for (int j = 1; j < list.Count(); ++j)
            {
                if (comparer.Compare(listToSort[j - 1], listToSort[j]) > 0)
                {
                    (listToSort[j - 1], listToSort[j]) = (listToSort[j], listToSort[j - 1]);
                }
            }
        }

        return listToSort;
    }
}
