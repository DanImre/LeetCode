using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_17
    {
        public Medium_17()
        {
            Console.WriteLine(string.Join(", ", LetterCombinations("2"))); ;
        }

        public IList<string> LetterCombinations(string digits)
        {
            if(digits == "")
                return new List<string>();

            return letterCombinationsWithIndex(digits, 0);
        }

        public Dictionary<char, List<string>> dic = new Dictionary<char, List<string>>()
        {
            { '2', new List<string>() { "a", "b", "c"} },
            { '3', new List<string>() { "d", "e", "f"} },
            { '4', new List<string>() { "g", "h", "i"} },
            { '5', new List<string>() { "j", "k", "l"} },
            { '6', new List<string>() { "m", "n", "o"} },
            { '7', new List<string>() { "p", "q", "r", "s"} },
            { '8', new List<string>() { "t", "u", "v"} },
            { '9', new List<string>() { "w", "x", "y", "z"} }
        };

        public List<string> letterCombinationsWithIndex(string digits, int index)
        {
            if (index == digits.Length - 1)
                return dic[digits[index]];

            var solution = new List<string>();

            var nextSolution = letterCombinationsWithIndex(digits, index + 1);

            foreach (var item in dic[digits[index]])
                foreach (var i in nextSolution)
                    solution.Add(item + i);

            return solution;
        }
    }
}
