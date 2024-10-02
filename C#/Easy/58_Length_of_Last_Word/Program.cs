namespace _58_Length_of_Last_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //No need for testing
        }

        public static int LengthOfLastWord(string s)
        {
            int i = s.Length - 1;
            while (s[i] == ' ')
                --i;

            int j = i-1;
            while (j >= 0 && s[j] != ' ')
                --j;

            return i - j;
        }
    }
}