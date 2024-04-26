using System.Numerics;

namespace SparseVector;

/// <summary>
/// Class that implement sparse vector.
/// </summary>
public class SparseVector
{
    private readonly List<(int number, int value)> vector;

    /// <summary>
    /// Initializes a new instance of the <see cref="SparseVector"/> class.
    /// </summary>
    /// <param name="vector">A vector consists of index-value pairs.</param>
    public SparseVector((int number, int value)[] vector)
    {
        this.vector = new ();
        foreach (var element in vector)
        {
            this.vector.Add((element.number, element.value));
        }

        Size = vector[^1].number + 1;
    }

    /// <summary>
    /// Indexer that implements access to elements of the vector.
    /// </summary>
    /// <param name="index">The index of the element of the vector.</param>
    /// <returns>The value of a vector coordinate.</returns>
    /// <exception cref="IndexOutOfRangeException">Exception in case the index exceeds the size of the vector.</exception>
    public int this[int index]
    {
        get
        {
            if (index >= Size)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            foreach (var element in vector)
            {
                if (element.number == index)
                {
                    return element.value;
                }
            }

            return 0;
        }

        set
        {
            for (int i = 0; i < vector.Count; ++i)
            {
                if (vector[i].number == index)
                {
                    vector[i] = (index, value);
                    return;
                }
            }

            vector.Add((index, value));
            Size = index + 1;
        }
    }

    /// <summary>
    /// Gets size.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Method that return origin vector.
    /// </summary>
    /// <returns>Veector.</returns>
    public int[] GetOriginalVector()
    {
        var result = new int[Size];
        int index = 0;
        for (int i = 0; i < Size; i++)
        {
            if (vector[index].number == i)
            {
                result[i] = vector[index].value;
                index++;
            }
            else
            {
                result[i] = 0;
            }
        }

        return result;
    }

    /// <summary>
    /// A method that implements checking a vector for null.
    /// </summary>
    /// <returns>Is it zero-vector.</returns>
    public bool IsEmpty => Size == 0;

    /// <summary>
    /// Method realising addition of vectors.
    /// </summary>
    /// <param name="firstVector">First vector.</param>
    /// <param name="secondVector">Second vector.</param>
    /// <returns>Result of addition vectors.</returns>
    public static SparseVector Add(SparseVector firstVector, SparseVector secondVector)
    {
        return MakeOperation(firstVector, secondVector, (x, y) => x + y);
    }

    /// <summary>
    /// Method realising subtraction of vectors.
    /// </summary>
    /// <param name="firstVector">First vector.</param>
    /// <param name="secondVector">Second vector.</param>
    /// <returns>Result of subtraction vectors.</returns>
    public static SparseVector Subtraction(SparseVector firstVector, SparseVector secondVector)
    {
        return MakeOperation(firstVector, secondVector, (x, y) => x - y);
    }

    /// <summary>
    /// Method realising vector multiplication.
    /// </summary>
    /// <param name="firstVector">First vector.</param>
    /// <param name="secondVector">Second vector.</param>
    /// <returns>Result of multiplication vectors.</returns>
    public static int Multiplication(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.IsEmpty || firstVector.IsEmpty)
        {
            throw new ArgumentException("Null vectors.");
        }

        int result = 0;
        int index1 = 0;
        int index2 = 0;
        for (int i = 0; i < firstVector.Size; ++i)
        {
            if (firstVector.vector[index1].number == i && secondVector.vector[index2].number == i)
            {
                result += firstVector.vector[index1].value * secondVector.vector[index2].value;
                index1++;
                index2++;
                continue;
            }

            if (firstVector.vector[index1].number == i)
            {
                index1++;
                continue;
            }

            if (secondVector.vector[index2].number == i)
            {
                index2++;
            }
        }

        return result;
    }

    private static SparseVector MakeOperation(SparseVector firstVector, SparseVector secondVector, Func<int, int, int> func)
    {
        if (firstVector.Size != secondVector.Size)
        {
            throw new ArgumentException("Different lengh of vectos.");
        }

        if (firstVector.IsEmpty || firstVector.IsEmpty)
        {
            throw new ArgumentException("Null vectors.");
        }

        var resultVector = new List<(int number, int value)>();
        int index1 = 0;
        int index2 = 0;
        for (int i = 0; i < firstVector.Size; ++i)
        {
            if (firstVector.vector[index1].number == i && secondVector.vector[index2].number == i)
            {
                if (func(firstVector.vector[index1].value, secondVector.vector[index2].value) != 0)
                {
                    resultVector.Add((i, func(firstVector.vector[index1].value, secondVector.vector[index2].value)));
                }

                index1++;
                index2++;
                continue;
            }

            if (firstVector.vector[index1].number == i)
            {
                resultVector.Add((i, func(firstVector.vector[index1].value, 0)));
                index1++;
                continue;
            }

            if (secondVector.vector[index2].number == i)
            {
                resultVector.Add((i, func(0, secondVector.vector[index2].value)));
                index2++;
                continue;
            }
        }

        return new SparseVector(resultVector.ToArray());
    }
}
