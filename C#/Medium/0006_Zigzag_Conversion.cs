using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_6
    {
        public Medium_6()
        {
            Console.WriteLine(Convert("PAYPALISHIRING",3) + " -> " +  (Convert("PAYPALISHIRING", 3) == "PAHNAPLSIIGYIR"));
            Console.WriteLine(Convert("PAYPALISHIRING",4) + " -> " + (Convert("PAYPALISHIRING", 4) == "PINALSIGYAHRPI"));
            Console.WriteLine(Convert("A",1) + " -> " + (Convert("A", 1) == "A"));
            Console.WriteLine(Convert("ABCDEFG",2) + " -> " + (Convert("ABCDEFG", 2) == "ACEGBDF"));
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 0 || s.Length == 0)
                return "";
            if(numRows == 1 || s.Length <= numRows)
                return s;

            StringBuilder[] rows = new StringBuilder[numRows];
            for (int ll = 0; ll < numRows; ll++)
                rows[ll] = new StringBuilder();

            int i = 0;
            while (i < s.Length)
            {
                int j = numRows;

                for (int k = 0; k < j && i + k < s.Length; k++)
                    rows[k].Append(s[i + k]);

                for (int k = 1; k < j - 1 && i + j - 1 + k < s.Length; k++)
                    rows[j - 1 - k].Append(s[i + j - 1 + k]);

                i += 2 * numRows - 2;
            }

            StringBuilder result = new StringBuilder();
            for (int ll = 0; ll < numRows; ll++)
                result.Append(rows[ll].ToString());

            GC.Collect();

            return result.ToString();
        }
    }
}
