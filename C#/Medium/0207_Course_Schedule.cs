using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Medium
{
    public class Medium_207
    {
        public Medium_207()
        {

        }
        //Optimal:
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
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
                if (needCount[i] == 0)
                    q.Enqueue(i); //Completeable by itself, doesnt need courses

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                foreach (var item in requiredFor[curr])
                {
                    --needCount[item];
                    if (needCount[item] == 0) //Became completable
                        q.Enqueue(item);
                }
            }

            return needCount.All(kk => kk == 0);
        }
        //Shitty:
        private class Node
        {
            public int val;
            public List<Node> prerequisites;
            public Node(int val)
            {
                this.val = val;
                this.prerequisites = new List<Node>();
            }
        }
        public bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            foreach (var item in prerequisites)
            {
                Node left = null;
                if (nodes.ContainsKey(item[0]))
                    left = nodes[item[0]];
                else
                {
                    left = new Node(item[0]);
                    nodes.Add(item[0], left);
                }

                Node right = null;
                if (nodes.ContainsKey(item[1]))
                    right = nodes[item[1]];
                else
                {
                    right = new Node(item[1]);
                    nodes.Add(item[1], right);
                }

                if (prerequisitesContainNode(left, right))
                    return false;

                left.prerequisites.Add(right);
            }
            return true;
        }
        private bool prerequisitesContainNode(Node node, Node pre)
        {
            HashSet<Node> visited = new HashSet<Node>();

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(pre);
            while (q.Count != 0)
            {
                int count = q.Count;
                while (count != 0)
                {
                    --count;
                    var curr = q.Dequeue();
                    if (!visited.Add(curr))
                        continue;

                    if(curr.val == node.val)
                        return true;

                    foreach (var item in curr.prerequisites)
                        q.Enqueue(item);
                }
            }

            return false;
        }
    }
}
