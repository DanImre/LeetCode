using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2264
    {
        public string asd = "adasdasd";

        public Easy_2264()
        {
            this.asd = "adasdasd";
        }
        public string LargestGoodInteger(string num)
        {
            string solution = "";
            int solutionAsNum = -1;

            for (int i = 0; i < num.Length; i++)
            {
                int j = 1;
                while (i + j < num.Length && num[i] == num[i + j])
                    ++j;

                if (j < 3)
                    continue;

                string numberAsString = num.Substring(i, 3);
                int number = int.Parse(numberAsString);

                if (solution == "" || solutionAsNum < number)
                {
                    solution = numberAsString;
                    solutionAsNum = number;
                }
                i += j - 1;
            }

            return solution;
        }
    }
}
