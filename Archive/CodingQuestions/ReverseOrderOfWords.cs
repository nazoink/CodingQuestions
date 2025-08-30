using System;
using System.Collections.Generic;
using System.Linq;

public class ReverseOrderOfWords
{
    /*
    You are given an integer N, followed by N lines of input (1 <= N <= 100). 
    Each line of input contains one or several words separated with single spaces. 
    Each word is a sequence of letters of English alphabet containing between 1 and 10 characters,inclusive.
    The total number of words in the input is between 1 and 100, inclusive.

    Your task is to reverse the order of words in each line of input, while preserving the words themselves.
    The lines of your output should not have any trailing or leading spaces.

    Example

    input
    3
    Hello World
    Bye World
    Useless World

    output
    World Hello
    World Bye
    World Useless
    */
    public static void RunCode()
    {
        //Retrieve inputs from user
        var inputs = GetUserInput();

        //Reverses word order
        var outputs = ReverseWordOrder(inputs); ;

        //Writes outputs to screen
        WriteOutputs(outputs);
    }

    private static List<string> GetUserInput()
    {
        //1st input is a integer value
        //n input is string values to n times
        //n is between 1 and 100
        //each word is letters of 1 to 10 characters
        //each input has spaces between words
        //each input can be 1 to 100 words
        var arg1 = Console.ReadLine().Trim();
        int n;
        var inputs = new List<string>();
        //Verify input is convertable to integer
        if (int.TryParse(arg1, out n))
        {
            if (n != 0)
            {
                //Should logic be added to not allow n to be larger than 100?
                for (int i = 0; i < n && n <= 100; i++)
                {
                    var input = Console.ReadLine().Trim();
                    //Should each word be truncated to no more than 10 char after entered or ask for reentry?
                    //Should each input be truncated to no more than 100 words after entry or ask for reentry?
                    //If left blank, should that input be skipped (add an empty string/null to list) or ask for reentry?
                    inputs.Add(input);
                }
            }
            else
            {
                //What todo if not convertable?
                //Should it throw exception, add a 0 or ask for new values?
            }
        }

        return inputs;
    }

    public static List<string> ReverseWordOrder(List<string> inputs)
    {
        //Must reverse order of words for output
        var output = new List<string>();

        //Reverse order of words
        inputs.ForEach(input => {
            //Array.Reverse(input.Split(' '));
            var strings = input.Split(' ').Reverse().ToList();
            string rstr = "";
            strings.ForEach(str => rstr += str + ' ');
            output.Add(rstr.Trim());
        });


        return output;
    }


    private static void WriteOutputs(List<string> outputs)
    {
        //No trailing or leading spaces ( ie. .Trim() on output string)
        outputs.ForEach(x => Console.WriteLine(x.Trim()));
        Console.ReadLine();
    }
}
