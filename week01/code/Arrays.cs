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
        // To find the multiples of a number, I should save in an array the number multiplied by each index from 1 to length.
        double[] result = new double[length];
        for (int i = 0; i < length; i++) //Run once for each multiplier
        {
            result[i] = number * (i + 1); // Multiply the number by (i + 1) to get multiples starting from 1
        }
        return result;
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
        // Check if the list is empty or has one element, in which case no rotation is needed.
        // Calculate the effective rotation using modulo.
        // Use GetRange to extract the two parts of the list.
        // Concatenate the parts and update the original list.

         // Check if the list is empty or has one element, in which case no rotation is needed.
        if (data.Count <= 1)
        {
            return;
        }

        // Calculate the effective rotation using modulo.
        int effectiveRotation = amount % data.Count;

        // If the effective rotation is 0, no change is needed.
        if (effectiveRotation == 0)
        {
            return;
        }

        // Use GetRange to extract the two parts of the list.
        List<int> lastPart = data.GetRange(data.Count - effectiveRotation, effectiveRotation);
        List<int> firstPart = data.GetRange(0, data.Count - effectiveRotation);

        // Concatenate the parts and update the original list.
        data.Clear(); // Clear the original list
        data.AddRange(lastPart); // Add the last part first
        data.AddRange(firstPart); // Then add the first part
    }
}
