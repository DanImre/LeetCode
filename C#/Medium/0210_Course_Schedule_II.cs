using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_210
    {
        public Medium_210()
        {

        }
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] order = new int[numCourses];
            int orderIndex = 0;

            Dictionary<int, List<int>> requiredFor = new Dictionary<int, List<int>>();

            int[] needCount = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
                requiredFor.Add(i, new List<int>());

            foreach (var item in prerequisites)
            {
                requiredFor[item[1]].Add(item[0]);
                ++needCount[item[0]]; //Needs + 1 course to compelte
            }

            Queue<int> q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
                if (needCount[i] == 0) //Completeable by itself, doesnt need courses
                {
                    q.Enqueue(i);
                    order[orderIndex] = i;
                    ++orderIndex;
                }

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                foreach (var item in requiredFor[curr])
                {
                    --needCount[item];
                    if (needCount[item] == 0) //Became completable
                    {
                        q.Enqueue(item);
                        order[orderIndex] = item;
                        ++orderIndex;
                    }
                }
            }

            if (needCount.Any(kk => kk != 0))
                return new int[0];

            return order;
        }
    }
}
