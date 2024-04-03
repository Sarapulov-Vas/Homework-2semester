using System.Linq.Expressions;

namespace Functions;

/// <summary>
/// Class that implements map, Filter, Fold functions.
/// </summary>
public static class Functions
{
    /// <summary>
    /// Method that applies the function to the elements of the list.
    /// </summary>
    /// <typeparam name="T">The type of items in the original list.</typeparam>
    /// <typeparam name="TF">The type of list items, after the function has been applied.</typeparam>
    /// <param name="originalList">Original list.</param>
    /// <param name="function">A function applied to the elements of a list.</param>
    /// <returns>A list after applying a function to its elements.</returns>
    public static List<TF> Map<T, TF>(List<T> originalList, Func<T, TF> function)
    {
        var result = new List<TF>();
        foreach (var element in originalList)
        {
            result.Add(function(element));
        }

        return result;
    }

    /// <summary>
    /// Method filtering list elements by a given function.
    /// </summary>
    /// <typeparam name="T">Type of list items.</typeparam>
    /// <param name="originalList">Original listing.</param>
    /// <param name="function">Element validation Function.</param>
    /// <returns>A list with matching items.</returns>
    public static List<T> Filter<T>(List<T> originalList, Func<T, bool> function)
    {
        var result = new List<T>();
        foreach (var element in originalList)
        {
            if (function(element))
            {
                result.Add(element);
            }
        }

        return result;
    }

    /// <summary>
    /// Method counting accumulation by list, initial value and specified function.
    /// </summary>
    /// <typeparam name="T">Type of list items.</typeparam>
    /// <typeparam name="TF">The type of value to be accumulated.</typeparam>
    /// <param name="originalList">Original list.</param>
    /// <param name="acc">Initial value.</param>
    /// <param name="function">Function for calculating the accumulated value.</param>
    /// <returns>Final accumulated Value.</returns>
    public static TF Fold<T, TF>(List<T> originalList, TF acc, Func<TF, T, TF> function)
    {
        foreach (var element in originalList)
        {
            acc = function(acc, element);
        }

        return acc;
    }
}
