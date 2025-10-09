using System.ComponentModel;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Eliminaet the possibility of duplicates by checking both > and < otherwise skip
        

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if(value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        bool foundIt = false;
        
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                return false;
            else
              foundIt = Left.Contains(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                return false;
            else
                foundIt = Right.Contains(value);
        }

        if (value == Data || foundIt)
        {
            return true;
        }

        return foundIt;
    }

    public int GetHeight()
    {
        int lheight = 1, rheight = 1;
        if (Left is not null)
            lheight += Left.GetHeight();

        if (Right is not null)
            rheight += Right.GetHeight();

        return Math.Max(lheight, rheight);
    }
}