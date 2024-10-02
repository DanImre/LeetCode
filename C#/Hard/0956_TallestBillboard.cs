using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_956
    {
        public Hard_956()
        {
            Console.WriteLine(TallestBillboard(new int[] { 1, 2, 3, 6 }));
            Console.WriteLine(TallestBillboard(new int[] { 1, 2, 3, 4, 5, 6 }));
            Console.WriteLine(TallestBillboard(new int[] { 1, 2 }));
            Console.WriteLine(TallestBillboard(new int[] { 100, 100 }));
            Console.WriteLine(TallestBillboard(new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 50, 50, 50, 150, 150, 150, 100, 100, 100, 123 }));
        }

        public static int TallestBillboard(int[] rods)
        {
            int solution = 0;

            Dictionary<int, int> leftSide = new Dictionary<int, int>(); //Gets the subset's heights (From example (3 -> 6)
            Dictionary<int, int> rightSide = new Dictionary<int, int>(); //There was a set [13,16] => it will contain a (3 -> 13)
            recursive(rods, leftSide, 0, 0, 0, rods.Length / 2);
            recursive(rods, rightSide, 0, 0, rods.Length / 2, rods.Length);
            foreach (var item in rightSide.Keys)
                if (leftSide.ContainsKey(item))
                    solution = Math.Max(solution, rightSide[item] + leftSide[item] + item);

            return solution;
        }

        public static void recursive(int[] rods, Dictionary<int, int> diffs, int sumL, int sumR, int i, int last)
        {
            //Example:
            //SumL = 6
            //SumR = 9
            //diff = 3
            //If difference 3 hasnt been created yet, add it

            //Chose or not chose the enxt number

            int diff = Math.Abs(sumL - sumR);
            if (!diffs.TryAdd(diff, Math.Min(sumL, sumR))) //If the difference isnt already in, add it
                diffs[diff] = Math.Max(diffs[diff], Math.Min(sumL, sumR));

            if (i != last) //BruteForce 3 solutions:
            {
                recursive(rods, diffs, sumL + rods[i], sumR, i + 1, last); //Add it to the left
                recursive(rods, diffs, sumL, sumR + rods[i], i + 1, last); //Add it to the right
                recursive(rods, diffs, sumL, sumR, i + 1, last); //Dont add it
            }
        }
    }
}
