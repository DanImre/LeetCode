using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Threading;

namespace Medium
{
    public class _1117_Building_H2O
    {
        public class H2O
        {
            private readonly object _lock = new();

            private int hCount = 0;
            public H2O()
            {

            }

            public void Hydrogen(Action releaseHydrogen)
            {
                lock (_lock)
                {
                    // To recheck the state (if 6 hydogens come in at once then an oxigen, only print 2 and wait for the other method to zero out the counter
                    while (hCount == 2)
                    {
                        Monitor.Wait(_lock);
                    }

                    ++hCount;

                    // releaseHydrogen() outputs "H". Do not change or remove this line.
                    releaseHydrogen();
                    Monitor.PulseAll(_lock);
                }
            }

            public void Oxygen(Action releaseOxygen)
            {
                lock (_lock)
                {
                    // To recheck the state, this gets released every time a hydrogen comes in
                    while (hCount < 2)
                    {
                        Monitor.Wait(_lock);
                    }

                    // releaseOxygen() outputs "O". Do not change or remove this line.
                    releaseOxygen();
                    hCount = 0;
                    Monitor.PulseAll(_lock);
                }
            }
        }

        // This was rejected by leetcode, probably because of the many threads (somehow it left 2 Hydrogens unprinted)
        public class H2O_WithSems
        {
            private readonly SemaphoreSlim _hSem = new SemaphoreSlim(2, 2);
            private readonly SemaphoreSlim _oSem = new SemaphoreSlim(1, 1);
            private readonly Barrier _barrier = new Barrier(3);

            public H2O_WithSems()
            {

            }

            public void Hydrogen(Action releaseHydrogen)
            {
                _hSem.Wait();

                // releaseHydrogen() outputs "H". Do not change or remove this line.
                releaseHydrogen();

                _barrier.SignalAndWait();
                _hSem.Release();
            }

            public void Oxygen(Action releaseOxygen)
            {
                _oSem.Wait();

                releaseOxygen();

                _barrier.SignalAndWait();
                _oSem.Release();
            }
        }


        public class H2O_PureSlims
        {
            private readonly SemaphoreSlim _hSem = new SemaphoreSlim(2, 2);
            private readonly SemaphoreSlim _oSem = new SemaphoreSlim(1, 1);
            private readonly SemaphoreSlim _hSync = new SemaphoreSlim(0, 2);

            public H2O_PureSlims()
            {

            }

            public void Hydrogen(Action releaseHydrogen)
            {
                _hSem.Wait();

                // releaseHydrogen() outputs "H". Do not change or remove this line.
                releaseHydrogen();

                _hSync.Release();
            }

            public void Oxygen(Action releaseOxygen)
            {
                _oSem.Wait();

                _hSync.Wait();
                _hSync.Wait();

                // releaseOxygen() outputs "O". Do not change or remove this line.
                releaseOxygen();

                _hSem.Release(2);
                _oSem.Release();
            }
        }
    }
}
