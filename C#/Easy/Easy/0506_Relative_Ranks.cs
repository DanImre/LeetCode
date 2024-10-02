using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Easy
{
    public class Easy_506
    {
        public Easy_506()
        {
            
        }
        public string[] FindRelativeRanks(int[] score)
        {
            string[] solution = new string[score.Length];
            PriorityQueue<int, int> prq = new PriorityQueue<int, int>();
            for (int i = 0; i < score.Length; i++)
                prq.Enqueue(i, -score[i]);

            int count = 1;
            while (prq.Count > 0)
            {
                if (count == 1)
                    solution[prq.Dequeue()] = "Gold Medal";
                else if (count == 2)
                    solution[prq.Dequeue()] = "Silver Medal";
                else if (count == 3)
                    solution[prq.Dequeue()] = "Bronze Medal";
                else
                    solution[prq.Dequeue()] = count.ToString();

                ++count;
            }

            return solution;
        }
    }
}
