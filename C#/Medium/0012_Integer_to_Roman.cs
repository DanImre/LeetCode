using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_12
    {
        public Medium_12()
        {
            Console.WriteLine(IntToRoman(1994));
        }
        public string IntToRoman(int num)
        {
            Dictionary<int, string> numberToRN = new Dictionary<int, string>();
            numberToRN.Add(1, "I");
            numberToRN.Add(2, "II");
            numberToRN.Add(3, "III");
            numberToRN.Add(4, "IV");
            numberToRN.Add(5, "V");
            numberToRN.Add(9, "IX");
            numberToRN.Add(10, "X");
            numberToRN.Add(40, "XL");
            numberToRN.Add(50, "L");
            numberToRN.Add(90, "XC");
            numberToRN.Add(100, "C");
            numberToRN.Add(400, "CD");
            numberToRN.Add(500, "D");
            numberToRN.Add(900, "CM");
            numberToRN.Add(1000, "M");

            Stack<string> solution = new Stack<string>();

            for (int i = 10; i <= num * 10; i *= 10)
            {
                int temp = num % i;
                while (temp > 0)
                {
                    if (numberToRN.ContainsKey(temp))
                    {
                        solution.Push(numberToRN[temp]);
                        break;
                    }

                    temp -= i / 10;
                    solution.Push(numberToRN[i / 10]);
                }
                num -= num % i;
            }


            string returnValue = "";
            while (solution.Count != 0)
                returnValue += solution.Pop();

            return returnValue;
        }

        //Best solution if you are using stringbuilder, otherwise not so good, basicly the same but doesnt have to reverse the string
        public string IntToRoman2(int num)
        {
            var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            string solution = "";
            // Loop through each symbol stopping if num becomes 0
            for (int i = 0; i < values.Length && num > 0; i++)
                while (values[i] <= num)
                {
                    num -= values[i];
                    solution += symbols[i];
                }

            return solution;
        }
    }
}
