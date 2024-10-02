using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_841
    {
        public Medium_841()
        {

        }
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            bool[] visited = new bool[rooms.Count];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count != 0)
            {
                var i = queue.Dequeue();

                if (visited[i])
                    continue;

                visited[i] = true;
                foreach (var item in rooms[i])
                    queue.Enqueue(item);
            }

            return visited.All(kk => kk);
        }
    }
}
