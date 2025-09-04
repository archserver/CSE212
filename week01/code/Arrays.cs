using System.Runtime.Serialization.Formatters;
using System.Text;


public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Define the return double array
        var results = new double[length];

        // start with 1 as the multiplyer can not start with 0 for a count of the number so while the multiplyer is <= then add 1  
        for (int i = 1; i <= length; i++)
        {
            // have to place in first position of the array so multiplyer - 1 takes on the value of the supplied number * multiplyer
            results[i - 1] = number * i;
        }

        return results; // return the array of double floats
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // DFefine the returtn value integer list
        var results = new List<int>();

        // check to see if the number of swaps = the size of the swap if it does just return the list as is
        if (amount == data.Count)
            return;
        else
        {
            // take the last # determined by amount and add it to the beginning of the new list
            results.AddRange(data.GetRange(data.Count - amount, amount));

            // take the begining remander of the indexes starting at the first and add them to the return value 
            results.AddRange(data.GetRange(0, data.Count - amount));
            // replace data list with the results list
            data.Clear();
            data.AddRange(results.GetRange(0, results.Count));
        }
        return;
    }
}
