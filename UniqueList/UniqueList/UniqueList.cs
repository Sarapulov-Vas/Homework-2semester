namespace UniqueList;

/// <summary>
/// Class of a list containing unique elements.
/// </summary>
public class UniqueList : List
{
    /// <inheritdoc/>
    public override void Add(int value)
    {
        if (this.Contain(value))
        {
            throw new InsertException("A list of unique values cannot contain identical values.");
        }

        base.Add(value);
    }

    /// <inheritdoc/>
    public override void ChangeElement(int index, int newValue)
    {
        if (this.Contain(newValue))
        {
            throw new ListValueChangeException("A list of unique values cannot contain identical values.");
        }

        base.ChangeElement(index, newValue);
    }

    private bool Contain(int value)
    {
        if (this.head == null)
        {
            return false;
        }

        Node current = this.head;
        for (int i = 0; i < this.Count; ++i)
        {
            if (current.Value == value)
            {
                return true;
            }
        }

        return false;
    }
}