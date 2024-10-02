using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_77
    {
        public Medium_77()
        {

        }

        public List<IList<int>> solution;
        public IList<IList<int>> Combine(int n, int k)
        {
            solution = new List<IList<int>>();
            CombineWithStartIndex(1, n, k, new Stack<int>());

            return solution;
        }
        public void CombineWithStartIndex(int start, int n, int k, Stack<int> list)
        {
            if (list.Count == k)
            {
                //solution.Add(new List<int>(list));
                solution.Add(list.ToList()); //Seems to be faster
                return;
            }

            for (int i = start; i <= n; i++)
            {
                list.Push(i);
                CombineWithStartIndex(i + 1, n, k, list);
                list.Pop();
            }
        }
    }
}
