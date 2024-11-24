public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns

    public static double[] MultiplesOf(double number, int length){
        double[] results = new double[length];
        for (int i = 1; i <= length; ++i) {
            results [i - 1] = i * number;
        }
        return results;
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

        // Plan to solve the problem:
        // Calculate the rotation point, split the list into two parts by storing the last amount elements in a new list and storing the first ones in another list. 
        // Then, join the last ones with the first ones


        // Step 1: Identify how many items to take from the end of the list
        int count = data.Count; // Total number of items in the list
        amount = amount % count; // In case amount is greater than count (although that shouldn't be the case here)

        // Step 2: Split the list
        // ake the last 'amount' items
        List<int> lastPart = data.GetRange(count - amount, amount);

        // Take the remaining items
        List<int> firstPart = data.GetRange(0, count - amount);

        // Paso 3: Modify the original list
        data.Clear();          // Clear the original list
        data.AddRange(lastPart); // Add the last items to the beginning
        data.AddRange(firstPart); // dd the remaining items to the end


    }
}
