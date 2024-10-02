namespace RomanToInteger_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("LVIII"));
            Console.WriteLine(RomanToInt("MCMXCIV"));

            Console.WriteLine(RomanToInt2("III"));
            Console.WriteLine(RomanToInt2("LVIII"));
            Console.WriteLine(RomanToInt2("MCMXCIV"));
        }
        public static int RomanToInt2(string s) //lassabb
        {
            int sum = 0;

            Dictionary<char,int> values = new Dictionary<char, int>();
            values.Add('I', 1);
            values.Add('V', 5);
            values.Add('X', 10);
            values.Add('L', 50);
            values.Add('C', 100);
            values.Add('D', 500);
            values.Add('M', 1000);

            List<int> list = s.Select(kk => values[kk]).ToList();
            int i = 0;
            while (i < list.Count-1)
            {
                if (list[i + 1] / list[i] == 5 || list[i + 1] / list[i] == 10)
                    sum -= list[i];
                else
                    sum += list[i];

                ++i;
            }
            sum += list[i];

            return sum;
        }
        public static int RomanToInt(string s)
        {
            int sum = 0;

            int i = 0;
            while (i != s.Length)
            {
                if (i < s.Length-1)
                    switch ((s[i].ToString() + s[i+1]))
                    {
                        case "IV":
                            sum += 4;
                            i += 2;
                            continue;
                        case "IX":
                            sum += 9;
                            i += 2;
                            continue;
                        case "XL":
                            sum += 40;
                            i += 2;
                            continue;
                        case "XC":
                            sum += 90;
                            i += 2;
                            continue;
                        case "CD":
                            sum += 400;
                            i += 2;
                            continue;
                        case "CM":
                            sum += 900;
                            i += 2;
                            continue;
                        default:
                            break;
                    }

                switch (s[i])
                {
                    case 'I':
                        sum += 1;
                        break;
                    case 'V':
                        sum += 5;
                        break;
                    case 'X':
                        sum += 10;
                        break;
                    case 'L':
                        sum += 50;
                        break;
                    case 'C':
                        sum += 100;
                        break;
                    case 'D':
                        sum += 500;
                        break;
                    case 'M':
                        sum += 1000;
                        break;
                    default:
                        break;
                }

                ++i;
            }

            return sum;
        }
    }
}