using System.Security.Principal;

namespace _1337_The_K_Weakest_Rows_in_a_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in KWeakestRows(new int[][] { new int[] { 1, 1, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 0 }, new int[] { 1, 0, 0, 0, 0 }, new int[] { 1, 1, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1 } },3))
                Console.Write(item + ", ");
        }

        public static int[] KWeakestRows(int[][] mat, int k)
        {
            int[] solution = new int[k];
            HashSet<int> accountedFor = new HashSet<int>();

            int index = 0;
            for (int lll = 0; lll < k; lll++)
            {
                if(index >= mat[0].Length)
                    --index;

                bool added = false;
                for (int i = 0; i < mat.Length; i++)
                {
                    if (accountedFor.Contains(i))
                        continue;

                    if (mat[i][index] == 0)
                    {
                        added = true;
                        solution[lll] = i;
                        accountedFor.Add(i);
                        break;
                    }
                }

                if (added)
                    continue;
                

                if (index == mat[0].Length - 1)
                {
                    for (int j = 0; j < k; j++)
                    {
                        if (accountedFor.Contains(j))
                            continue;

                        solution[lll] = j;
                        accountedFor.Add(j);
                        break;
                    }
                    --index;
                    continue;
                }

                ++index;
                --lll;
            }

            if(solution.Length == 0)
                for (int j = 0; j < k; j++)
                    solution[j] = j;

            return solution;
        }
    }
}