using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestions
{
    public class CountCharOccurrence
    {
        public static void RunCode()
        {

        }

        private static string GetUserInput()
        {
            return "";
        }

        public static Dictionary<char, int> CountOccurrences(string str)
        {
            Dictionary<char, int> characterCount = new Dictionary<char, int>();

            foreach (var character in str)
            {
                if (character != ' ')
                {
                    if (!characterCount.ContainsKey(character))
                    {
                        characterCount.Add(character, 1);
                    }
                    else
                    {
                        characterCount[character]++;
                    }
                }

            }
            return characterCount;
        }

        private static void WriteOutput(string output) 
        {
        }
    }
}
