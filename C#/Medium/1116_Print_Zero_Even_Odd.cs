using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace Medium
{
    public class _1116_Print_Zero_Even_Odd
    {
        public class ZeroEvenOdd
        {
            private readonly System.Threading.SemaphoreSlim zeroLock = new(1, 1);
            private readonly System.Threading.SemaphoreSlim oddLock = new(0, 1);
            private readonly System.Threading.SemaphoreSlim evenLock = new(0, 1);

            private int n;
            public ZeroEvenOdd(int n)
            {
                this.n = n;
            }

            // printNumber(x) outputs "x", where x is an integer.
            public void Zero(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i++)
                {
                    zeroLock.Wait();
                    printNumber(0);

                    if (i % 2 == 0)
                        evenLock.Release();
                    else
                        oddLock.Release();
                }
            }

            public void Even(Action<int> printNumber)
            {
                for (int i = 2; i <= n; i += 2)
                {
                    evenLock.Wait();
                    printNumber(i);
                    zeroLock.Release();
                }
            }

            public void Odd(Action<int> printNumber)
            {
                for (int i = 1; i <= n; i += 2)
                {
                    oddLock.Wait();
                    printNumber(i);
                    zeroLock.Release();
                }
            }
        }
    }
}
