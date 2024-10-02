using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_135
    {
        public Hard_135()
        {
            Console.WriteLine(Candy2(new int[] { 1, 0, 2 }));
            Console.WriteLine(Candy2(new int[] { 1, 2, 2 }));
            Console.WriteLine(Candy2(new int[] { 1, 2, 87, 87, 87, 2, 1 }));
        }
        public int Candy(int[] ratings)
        {
            List<int> inorder = ratings.Distinct().ToList();
            inorder.Sort();

            int[] solution = new int[ratings.Length];
            for (int i = 0; i < ratings.Length; i++)
                solution[i] = 0;


            for (int i = 0; i < inorder.Count; i++)
            {
                List<(int index, int value)> toBeInserted = new List<(int index, int value)>();
                for (int j = 0; j < ratings.Length; j++)
                {
                    if (ratings[j] != inorder[i])
                        continue;

                    int max = 0;
                    if (j != 0)
                        max = solution[j - 1];

                    if (j != ratings.Length - 1 && max < solution[j + 1])
                        max = solution[j + 1];

                    toBeInserted.Add((j, max + 1));
                }

                foreach (var item in toBeInserted)
                    solution[item.index] = item.value;
            }

            return solution.Sum();
        }

        //Clever solution: 2 array, one goes from left and aplies the requirements, and one from the right to the left, we get each max and thats the solution
        public int Candy2(int[] ratings)
        {
            int[] leftToRight = new int[ratings.Length];

            leftToRight[0] = 1;
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    leftToRight[i] = leftToRight[i - 1] + 1;
                else
                    leftToRight[i] = 1;
            }

            int sum = Math.Max(1, leftToRight[leftToRight.Length - 1]);
            int actValue = 1;
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    ++actValue;
                else
                    actValue = 1;

                sum += Math.Max(leftToRight[i], actValue);
            }
            return sum;
        }
    }
}
