using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class CalculateNumberPiles
{
    /*Initial code but starting over*/
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
        var args = ReadInput();

        //Calculate number of Piles
        var output = CalculatePiles(args); ;

        //Writes output to screen
        WriteOutput(output);
        //Run1();
    }

    private static List<int> ReadInput()
    {
        //The only line of input contains three space-separated integers: N, M and P. 1 <= N <= 100, 1 <= M <= 5, 2 <= P <= 5.
        //N = total number of piles
        //M = max number of boxes per pile
        //P = number of parts

        //string input = Console.ReadLine();

        //string[] inputs = input.Split(' ');

        //int numBoxes = int.Parse(inputs[0]);
        //int maxSizePerPile = int.Parse(inputs[1]);
        //int splitIntoPiles = int.Parse(inputs[2]);

        var args = new List<int>(); //Could use List<KeyValuePair<string, int>>()
        //convert each value to integers and add to args list
        //Should this check for and ask for rentry if not proper integers?
        var inputText = Console.ReadLine().Trim().Split(' ').ToList();
        inputText.ForEach(input => {
            int n;
            if (int.TryParse(input, out n))
            {
                args.Add(n);
            }
            else
            {
                //What todo if not convertable?
                args.Add(0); //Should it throw exception, add a 0, or ask for new values? note: cannot divide by 0
            }
        });

        return args;
    }

    private static string CalculatePiles(List<int> inputs)
    {
        //There are too many to carry in one trip, so you want to split them into several piles
        //using the following algorithm: if the current pile has at most M boxes, you can carry it as is, otherwise you split it into P parts as equally as possible
        //(i.e. so that the sizes of the parts differ at most by 1) and apply the same algorithm to each of the parts.
        //If you're trying to split less than P boxes into P piles, discard resulting zero-sized piles (see example 2).
        //
        //Calculate the number of piles you'll get in the end.
        //The only line of input contains three space-separated integers: N, M and P. 1 <= N <= 100, 1 <= M <= 5, 2 <= P <= 5.
        //Example 1
        //input
        //11 2 2

        //output
        //7
        //The sequence of pile splits you do is:
        //11-> 6 + 5
        //6-> 3 + 3
        //5-> 3 + 2
        //3-> 2 + 1(applied to three piles of 3 boxes each)
        //You end up with 4 piles of 2 boxes and 3 piles of 1 boxes, a total of 7 piles.

        //Example 2
        //input
        //3 2 5

        //output
        //3
        //You have to split a pile of 3 boxes into 5 parts, so you get 3 piles of 1 box and 2 empty piles which you discard.

        // N, M and P.
        //N = total number of piles
        //M = max number of boxes per pile
        //P = number of parts
        int n = 11;//inputs.IndexOf(0);
        int m = 2;//inputs.IndexOf(1);
        int p = 2;//inputs.IndexOf(2);

        //if N less or equal to M no extra piles needed, return 0
        var a = n < m;

        //else split based on P
        var output = Algorithm(n, m, p);

        return output;
    }

    private static string Algorithm(int numBoxes, int maxSizePerPile, int splitIntoPiles)
    {
        //output
        //7
        //The sequence of pile splits you do is:
        //11-> 6 + 5
        //6-> 3 + 3
        //5-> 3 + 2
        //3-> 2 + 1(applied to three piles of 3 boxes each)
        //You end up with 4 piles of 2 boxes and 3 piles of 1 boxes, a total of 7 piles.

        // N, M and P. 
        //N = total number of piles
        //M = max number of boxes per pile
        //P = number of parts
        //var a = n % m;
        //var b = n / p;
        //var c = n % p;
        int numPiles = 1;
        int numSplits = (int)Math.Ceiling((decimal)numBoxes / maxSizePerPile);//6

        if (numSplits > splitIntoPiles && numBoxes % (numSplits / splitIntoPiles) != 0)
        {
            numPiles = numSplits + (int)Math.Ceiling(numBoxes % (numSplits / splitIntoPiles) / (decimal)splitIntoPiles) - 1;
        }
        else
        {
            numPiles = numSplits;
        }
        numBoxes = numBoxes - numSplits;

        return numPiles.ToString();
    }

    private static void WriteOutput(string output)
    {
        //Example 1
        //input
        //11 2 2

        //output
        //7
        //The sequence of pile splits you do is:
        //11-> 6 + 5
        //6-> 3 + 3
        //5-> 3 + 2
        //3-> 2 + 1(applied to three piles of 3 boxes each)

        //You end up with 4 piles of 2 boxes and 3 piles of 1 boxes, a total of 7 piles.
        Console.WriteLine(output);

        //Example 2
        //input
        //3 2 5

        //output
        //3
        //You have to split a pile of 3 boxes into 5 parts, so you get 3 piles of 1 box and 2 empty piles which you discard.
        //Console.WriteLine(output
 
        //To stop the console from closing
        Console.ReadLine();
    }


    public static void Run1()
    {
        string input = Console.ReadLine();

        string[] inputs = input.Split(' ');

        int numBoxes = int.Parse(inputs[0]);
        int maxSizePerPile = int.Parse(inputs[1]);
        int splitIntoPiles = int.Parse(inputs[2]);

        int numPiles = 1;

        if (numBoxes > maxSizePerPile)
        {
            for (int i = 0; i < numBoxes; i++)
            {
                int numSplits = (int)Math.Ceiling((decimal)numBoxes / maxSizePerPile);//6

                if (numSplits > splitIntoPiles && numBoxes % (numSplits / splitIntoPiles) != 0)
                {
                    numPiles = numSplits + (int)Math.Ceiling(numBoxes % (numSplits / splitIntoPiles) / (decimal)splitIntoPiles) - 1;
                }
                else
                {
                    numPiles = numSplits;
                }
                numBoxes = numBoxes - numSplits;
            }
            

        }

        Console.WriteLine(numPiles);
        //To stop the console from closing
        Console.ReadLine();
    }
}
