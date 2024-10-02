using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1337
    {
        public Easy_1337()
        {

        }
        //Bitmasking - faster
        public int[] KWeakestRows(int[][] mat, int k)
        {
            PriorityQueue<int, int> prq = new PriorityQueue<int, int>();

            for (int i = 0; i < mat.Length; i++)
            {
                int j = 0;
                while (j < mat[i].Length && mat[i][j] == 1)
                    ++j;

                prq.Enqueue(i, (j << 7) + i);
            }

            int[] solution = new int[k];
            for (int i = 0; i < k; i++)
                solution[i] = prq.Dequeue();

            return solution;
        }
        //Works:
        public int[] KWeakestRowsWorks(int[][] mat, int k)
        {
            int[] solution = new int[k];
            HashSet<int> accountedFor = new HashSet<int>();

            int index = 0;
            for (int lll = 0; lll < k; lll++)
            {
                if (index >= mat[0].Length)
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

            if (solution.Length == 0)
                for (int j = 0; j < k; j++)
                    solution[j] = j;

            return solution;
        }
    }
}
