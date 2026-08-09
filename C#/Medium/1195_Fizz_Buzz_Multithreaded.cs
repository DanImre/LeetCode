using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Medium
{
    public class _1195_Fizz_Buzz_Multithreaded
    {
        public class FizzBuzz
        {
            private readonly Barrier _barrier = new(4);
            private int n;

            public FizzBuzz(int n)
            {
                this.n = n;
            }

            // printFizz() outputs "fizz".
            public void Fizz(Action printFizz)
            {
                for (int i = 1; i <= n; i++)
                {
                    _barrier.SignalAndWait();
                    if (i % 3 != 0
                        || i % 5 == 0)
                        continue;

                    printFizz();
                }
            }

            // printBuzzz() outputs "buzz".
            public void Buzz(Action printBuzz)
            {
                for (int i = 1; i <= n; i++)
                {
                    _barrier.SignalAndWait();
                    if (i % 3 == 0
                        || i % 5 != 0)
                        continue;

                    printBuzz();
                }
            }

            // printFizzBuzz() outputs "fizzbuzz".
            public void Fizzbuzz(Action printFizzBuzz)
            {
                for (int i = 1; i <= n; i++)
                {
                    _barrier.SignalAndWait();
                    if (i % 3 != 0
                        || i % 5 != 0)
                        continue;

                    printFizzBuzz();
                }
            }

            // printNumber(x) outputs "x", where x is an integer.
            public void Number(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i++)
                {
                    _barrier.SignalAndWait();
                    if (i % 3 == 0
                        || i % 5 == 0)
                        continue;

                    printNumber(i);
                }
            }
        }
    }
}
