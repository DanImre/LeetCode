using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public class _1114_Print_in_Order
    {
        public class Foo
        {
            private readonly SemaphoreSlim _sem1 = new(0, 1);
            private readonly SemaphoreSlim _sem2 = new(0, 1);
            public Foo()
            {

            }

            public void First(Action printFirst)
            {
                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();

                _sem1.Release();
            }

            public void Second(Action printSecond)
            {
                _sem1.Wait();

                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();

                _sem2.Release();
            }

            public void Third(Action printThird)
            {
                _sem2.Wait();

                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }
    }
}
