using System.Numerics;

namespace SparseVector;

/// <summary>
/// Class that implement sparse vector.
/// </summary>
public class SparseVector
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SparseVector"/> class.
    /// </summary>
    /// <param name="vector">Vector.</param>
    public SparseVector((int number, int value)[] vector)
    {
        Vector = new ();
        foreach (var element in vector)
        {
            this.Vector.Add((element.number, element.value));
        }

        Size = vector[^1].number + 1;
    }

    /// <summary>
    /// Gets vector.
    /// </summary>
    public List<(int number, int value)> Vector { get; private set; }

    /// <summary>
    /// Gets size.
    /// </summary>
    public int Size { get; private set; }

    public int[] GetOriginalVector()
    {
        var result = new List<int>();
        int index = 0;
        for (int i = 0; i < Size; i++)
        {
            if (Vector[index].number == i)
            {
                result.Add(Vector[index].value);
                index++;
            }
            else
            {
                result.Add(0);
            }
        }
        return result.ToArray();
    }

    /// <summary>
    /// A method that implements checking a vector for null.
    /// </summary>
    /// <param name="vector">Vector.</param>
    /// <returns>Is it zero-vctor.</returns>
    public static bool CheckingVectorNull(SparseVector vector)
    {
        return vector.Size == 0;
    }

    /// <summary>
    /// Method realising addition of vectors.
    /// </summary>
    /// <param name="firstVector">First vector.</param>
    /// <param name="secondVector">Second vector.</param>
    /// <returns>Result of addition vectors.</returns>
    public static SparseVector Addition(SparseVector firstVector, SparseVector secondVector)
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
    /// <param name="scalar">Scalar.</param>
    /// <returns>Result of multiplication vectors.</returns>
    public static SparseVector Multiplication(SparseVector firstVector, int scalar)
    {
        if (CheckingVectorNull(firstVector))
        {
            throw new ArgumentException("Null vectors.");
        }

        var resultVector = new List<(int number, int value)>();
        foreach (var element in firstVector.Vector)
        {
            resultVector.Add((element.number, element.value * scalar));
        }

        return new SparseVector(resultVector.ToArray());
    }

    private static SparseVector MakeOperation(SparseVector firstVector, SparseVector secondVector, Func<int, int, int> func)
    {
        if (firstVector.Size != secondVector.Size)
        {
            throw new ArgumentException("Different lengh of vectos.");
        }

        if (CheckingVectorNull(firstVector) || CheckingVectorNull(secondVector))
        {
            throw new ArgumentException("Null vectors.");
        }

        var resultVector = new List<(int number, int value)>();
        int index1 = 0;
        int index2 = 0;
        for (int i = 0; i < firstVector.Size; ++i)
        {
            if (firstVector.Vector[index1].number == i && firstVector.Vector[index2].number == i)
            {
                if (func(firstVector.Vector[index1].value, secondVector.Vector[index2].value) != 0)
                {
                    resultVector.Add((i, func(firstVector.Vector[index1].value, secondVector.Vector[index2].value)));
                }

                index1++;
                index2++;
                continue;
            }

            if (firstVector.Vector[index1].number == i)
            {
                resultVector.Add((i, func(firstVector.Vector[index1].value, 0)));
                index1++;
                continue;
            }

            if (secondVector.Vector[index2].number == i)
            {
                resultVector.Add((i, func(0, secondVector.Vector[index2].value)));
                index2++;
                continue;
            }
        }

        return new SparseVector(resultVector.ToArray());
    }
}
