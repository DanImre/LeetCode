using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2391
    {
        public Medium_2391()
        {

        }
        public int GarbageCollection(string[] garbage, int[] travel)
        {
            int liM = -1;
            int liP = -1;
            int liG = -1;
            for (int i = garbage.Length - 1; i >= 0 && (liM == -1 || liP == -1 || liG == -1); i--)
            {
                if (liM == -1 && garbage[i].Contains('M'))
                    liM = i;
                if (liP == -1 && garbage[i].Contains('P'))
                    liP = i;
                if (liG == -1 && garbage[i].Contains('G'))
                    liG = i;
            }

            int time = 0;
            for (int i = 0; i < garbage.Length; i++)
            {
                time += garbage[i].Length;
                if(i < liM)
                    time += travel[i];
                if (i < liP)
                    time += travel[i];
                if (i < liG)
                    time += travel[i];
            }

            return time;
        }
    }
}
