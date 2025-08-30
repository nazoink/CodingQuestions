using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissingNumberFinder
{
    public static void RunCode()
    {
        var userInputListBasic = GetUserInput();

        var userInputListSix = new List<int> { 2, 5, 1, 4, 9, 3, 7, 10, 8 };
        var userInputListSeven = new List<int> { 2, 5, 1, 4, 9, 3, 6, 10, 8 };
        var userInputListThree = new List<int> { 2, 5, 1, 4, 9, 6, 7, 10, 8 };
        var userInputListNone = new List<int> { 2, 5, 1, 4, 9, 3, 7, 10, 8, 6 };


        var missingBasic = FindMissingNumberV1(userInputListBasic, 10);

        var missingSix = FindMissingNumber(userInputListSix, Math.Max(userInputListSix.Max(), userInputListSix.Count));
        var missingSeven = FindMissingNumber(userInputListSeven, Math.Max(userInputListSeven.Max(), userInputListSeven.Count));
        var missingThree = FindMissingNumber(userInputListThree, Math.Max(userInputListThree.Max(), userInputListThree.Count));
        var missingNone = FindMissingNumber(userInputListNone, Math.Max(userInputListNone.Max(), userInputListNone.Count));


        WriteOutput("The missing number is: " + missingBasic);

        WriteOutput("The missing number is: " + missingSix);
        WriteOutput("The missing number is: " + missingSeven);
        WriteOutput("The missing number is: " + missingThree);
        WriteOutput("The missing number is: " + missingNone);
    }

    private static List<int> GetUserInput()
    {
        // Example list with one missing number (should be numbers 1-10, but 6 is missing)
        var numbersList = new List<int> { 2, 5, 1, 4, 9, 3, 7, 10, 8 };
        return numbersList;
    }

    /// <summary>
    /// Finds the missing number from a list containing numbers 1 through n with one missing.
    /// </summary>
    /// <param name="numbers">Unsorted list of integers.</param>
    /// <param name="n">The total count that should be present (1 to n).</param>
    /// <returns>The missing integer.</returns>
    public static int FindMissingNumberV1(List<int> numbers, int n)
    {
        // Calculate expected sum using the arithmetic sum formula
        int expectedSum = n * (n + 1) / 2;

        // Sum the elements in the given list
        int actualSum = numbers.Sum();

        // The missing number is the difference between expected and actual sums
        return expectedSum - actualSum;
    }

    /// <summary>
    /// Finds the missing number from a list that is supposed to contain numbers 1 through expectedMax.
    /// If no number is missing (i.e. the list is complete), the method returns null.
    /// </summary>
    /// <param name="numbers">The unsorted list of integers.</param>
    /// <param name="expectedMax">The expected maximum number (i.e. the upper bound of the range).</param>
    /// <returns>
    /// The missing number if one number is missing; otherwise, null to indicate that there is no missing number.
    /// </returns>
    public static int? FindMissingNumber(List<int> numbers, int expectedMax)
    {
        // Use long to safely handle large ranges
        long expectedSum = (long)expectedMax * (expectedMax + 1) / 2;
        long actualSum = numbers.Sum(x => (long)x);

        // Calculate the difference
        int missing = (int)(expectedSum - actualSum);

        // If the difference is 0, no number is missing.
        return missing == 0 ? (int?)null : missing;
    }

    private static void WriteOutput(string output)
    {
        Console.WriteLine(output);
    }
}

