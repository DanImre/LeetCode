using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2433
    {
        public Medium_2433()
        {

        }

        public int[] FindArray(int[] pref)
        {
            int[] solution = new int[pref.Length];
            solution[0] = pref[0];

            //x ^ a = b
            //solution[i] ^ pref[i - 1] = pref[i]
            //solution[i] = pref[i - 1] ^ pref[i] //Seems like it with tests

            for (int i = 1; i < pref.Length; i++)
                solution[i] = pref[i - 1] ^ pref[i];

            return solution;
        }
    }
}
