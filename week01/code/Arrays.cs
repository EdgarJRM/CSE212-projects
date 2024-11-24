public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns
    public static void Run(){
        // MultiplesOf Exercise
        double number = 8; // Base Number
        int length = 6;    // Number of multiples to generate
        double[] multiples = MultiplesOf(number, length); // Call the function to get the multiples
        Console.WriteLine("Múltiplos de " + number + ": " + string.Join(", ", multiples)); // Print the array of multiples


        // RotateListRight Exercise
        List<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // Initial example list
        int amount = 5; // Number of rotations
        RotateListRight(data, amount); // Call the function to rotate the list
        Console.WriteLine("Lista rotada: " + string.Join(", ", data)); // Print the resulting list
    }

    public static double[] MultiplesOf(double number, int length){

        // Step 1: Create an array of size 'length' to store the multiples
        // Step 2: Fill the array with the multiples of the number and Calculate the multiple
        // Step 3: Return the array with the multiples

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
        // TStep-by-step plan:
        //    1. Determine the starting index of the new list:
        //    2. Split the list
        //    2. We will join the two segments, placing the end at the beginning.
        //    3. Return the new rotated list


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
