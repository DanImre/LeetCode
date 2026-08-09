using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class _1115_Print_FooBar_Alternately
    {
        public class FooBar
        {
            private readonly System.Threading.SemaphoreSlim _sem1 = new(1, 1);
            private readonly System.Threading.SemaphoreSlim _sem2 = new(0, 1);
            private int n;

            public FooBar(int n)
            {
                this.n = n;
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    _sem1.Wait();
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    _sem2.Release();
                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {
                    _sem2.Wait();
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                    _sem1.Release();
                }
            }
        }
    }
}
