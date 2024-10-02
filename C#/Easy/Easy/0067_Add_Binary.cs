using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_67
    {
        public Easy_67()
        {
            AddBinary("", "");
        }
        public string AddBinary(string a, string b)
        {
            if(a.Length < b.Length)
                a = a.PadLeft(b.Length, '0');
            else
                b = b.PadLeft(a.Length, '0');

            string solution = "";

            bool remained = false;
            for (int i = a.Length - 1; i >= 0; --i)
                if (a[i] == b[i])
                {
                    solution = (remained ? "1" : "0") + solution;
                    remained = a[i] == '1';
                    continue;
                }
                else
                    solution = (remained ? "0" : "1") + solution;

            if (remained)
                return "1" + solution;

            return solution;
        }
    }
}
