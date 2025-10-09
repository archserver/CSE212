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
            // Check to the left
            if (Left is null)
                return false;
            else
              foundIt = Left.Contains(value);
        }
        else if (value > Data)
        {
            // Check the right
            if (Right is null)
                return false;
            else
                foundIt = Right.Contains(value);
        }
        // if = return trye
        if (value == Data || foundIt)
        {
            return true;
        }
        // otherwise return the value of foundit
        return foundIt;
    }

    public int GetHeight()
    {
        // start with 1 checking left and right independantly
        int lheight = 1, rheight = 1;

        if (Left is not null)
            lheight += Left.GetHeight();

        if (Right is not null)
            rheight += Right.GetHeight();
        // return the highest using Max
        return Math.Max(lheight, rheight);
    }
}