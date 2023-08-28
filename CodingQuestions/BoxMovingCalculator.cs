using System;
using System.Collections.Generic;
using System.Linq;

public class BoxMovingCalculator
{
    /*
    Question2
    You have N boxes in your room which you want to carry to a different place.
    There are too many to carry in one trip, so you want to split them into several piles
    using the following algorithm: if the current pile has at most M boxes, you can carry it as is, otherwise you split it into P parts as equally as possible
    (i.e. so that the sizes of the parts differ at most by 1) and apply the same algorithm to each of the parts.
    If you're trying to split less than P boxes into P piles, discard resulting zero-sized piles (see example 2).

    Calculate the number of piles you'll get in the end.
    The only line of input contains three space-separated integers: N, M and P. 1 <= N <= 100, 1 <= M <= 5, 2 <= P <= 5.

    Example 1
    input
    11 2 2

    output
    7
    The sequence of pile splits you do is:
    11 -> 6 + 5
    6 -> 3 + 3
    5 -> 3 + 2
    3 -> 2 + 1 (applied to three piles of 3 boxes each)
    You end up with 4 piles of 2 boxes and 3 piles of 1 boxes, a total of 7 piles.

    Example 2
    input
    3 2 5

    output
    3

    You have to split a pile of 3 boxes into 5 parts, so you get 3 piles of 1 box and 2 empty piles which you discard.
    */
    public static void RunCode()
    {
        //Retrieve inputs from user
        var args = GetUserInput();

        //Calculate number of Piles
        var output = CalculateNumberOfPiles(args);

        //Writes output to screen
        WriteOutput(output.ToString());
    }

    // Get user input for three integer numbers, n, m, and p.
    // The integers should be validated to ensure they are within the following ranges:
    // N, M and P. 1 <= N <= 100, 1 <= M <= 5, 2 <= P <= 5.
    public static List<int> GetUserInput()
    {
        List<int> userInputs = new List<int>();

        Console.WriteLine("Enter three digits N, M and P separated by spaces: ");

        string[] inputs;
        int n;
        int m;
        int p;

        while (true)
        {
            try
            {
                inputs = Console.ReadLine().Split(' ');

                n = int.Parse(inputs[0]);
                m = int.Parse(inputs[1]);
                p = int.Parse(inputs[2]);

                if (!(n is >= 1 and <= 100) || !(m is >= 1 and <= 5) || !(p is >= 2 and <= 5))
                {
                    Console.WriteLine("Please enter valid integer values within 1<=N<=100, 1<=M<=5, 2<=P<=5 ranges.");
                    continue;
                }

                userInputs.Add(n);
                userInputs.Add(m);
                userInputs.Add(p);

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter valid integer values.");
            }
        }

        return userInputs;
    }

    // You have N boxes in your room which you want to carry to a different place.
    // There are too many to carry in one trip, you want to split them into several piles
    // You have been given a list of three integers, n, m, and p provided in the userInputs variable.
    // n, represents the number of boxes you have
    // m, represents the maximum number of boxes you can carry in one trip
    // p, represents the number of parts you can split a pile into
    // if the current pile has at most M boxes, you can carry it as is,
    // otherwise you split it into P parts as equally as possible,
    // so that the sizes of the parts differ at most by 1
    // apply the same algorithm to each of the parts
    // If you're trying to split less than n boxes into p piles, discard resulting zero-sized piles
    public static int CalculateNumberOfPiles(List<int> userInputs)
    {
        //Set the user inputs to variables
        int numBoxes = userInputs[0];
        int maxSizePerPile = userInputs[1];
        int splitIntoParts = userInputs[2];

        int numPiles = 0;

        //Check to see if the number of boxes is less than the max number that can be in pile
        if (numBoxes <= maxSizePerPile)
        {
            numPiles = 1;
        }
        else
        {
            //Setup initial value calculations
            int leftoverBoxes = numBoxes % maxSizePerPile;
            int fullPiles = (numBoxes - leftoverBoxes) / maxSizePerPile;
            int fullPileGroups = (fullPiles - (fullPiles % splitIntoParts)) / splitIntoParts;
            int remainingPiles = fullPiles % splitIntoParts;

            //If leftover boxes is 0 then calculate out number of piles
            if (leftoverBoxes == 0)
            {
                numPiles = (fullPileGroups * 2) + (remainingPiles > 0 ? 1 : 0) + remainingPiles;
            }
            //If leftover boxes and number of parts to split remainder equals 0 calculate out the number of piles
            else if (leftoverBoxes % splitIntoParts == 0)
            {
                int groupsOfLeftovers = leftoverBoxes / splitIntoParts;

                numPiles = (fullPileGroups * 2) + (remainingPiles > 0 ? 1 : 0) + groupsOfLeftovers + remainingPiles;
            }
            else // Calculate out number of piles
            {
                int groupsOfLeftovers = (leftoverBoxes - (leftoverBoxes % splitIntoParts)) / splitIntoParts;
                int remainingLeftoverPiles = leftoverBoxes % splitIntoParts;

                numPiles = (fullPileGroups * 2) + (remainingPiles > 0 ? 1 : 0) + groupsOfLeftovers + (remainingLeftoverPiles > 0 ? 1 : 0) + remainingPiles;
            }
        }

        return numPiles;
    }

    private static void WriteOutput(string output)
    {
        Console.WriteLine(output);

        //To stop the console from closing
        Console.ReadLine();
    }
}
