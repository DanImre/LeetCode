using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1700
    {
        public Easy_1700()
        {

        }
        public int CountStudents(int[] students, int[] sandwiches)
        {
            int sandwichIndex = 0;
            Queue<int> q = new Queue<int>(students);

            bool someoneAte = true;
            while (someoneAte)
            {
                someoneAte = false;
                int count = q.Count;
                while (count -- > 0)
                {
                    var curr = q.Dequeue();
                    if (curr == sandwiches[sandwichIndex])
                    {
                        sandwichIndex++;
                        someoneAte = true;
                    }
                    else
                        q.Enqueue(curr);
                        
                }
            }

            return q.Count;
        }
    }
}
