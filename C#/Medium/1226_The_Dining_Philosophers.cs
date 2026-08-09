using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class _1226_The_Dining_Philosophers
    {
        class DiningPhilosophers
        {
            private readonly object tableLock = new();
            public DiningPhilosophers()
            {

            }

            // call the run() method of any runnable to execute its code
            public void WantsToEat(int philosopher,
                                   Action pickLeftFork,
                                   Action pickRightFork,
                                   Action eat,
                                   Action putLeftFork,
                                   Action putRightFork)
            {
                lock (tableLock)
                {
                    pickLeftFork();
                    pickRightFork();
                    eat();
                    putLeftFork();
                    putRightFork();
                }
            }
        }

        public class DiningPhilosophersOddLeftEvenRight
        {
            private readonly object[] _forks = new object[5];

            public DiningPhilosophersOddLeftEvenRight()
            {
                for (int i = 0; i < 5; i++)
                {
                    _forks[i] = new object();
                }
            }

            public void WantsToEat(int philosopher,
                                   Action pickLeftFork,
                                   Action pickRightFork,
                                   Action eat,
                                   Action putLeftFork,
                                   Action putRightFork)
            {
                int leftFork = philosopher;
                int rightFork = (philosopher + 1) % 5;

                int firstFork;
                int secondFork;

                if (philosopher % 2 == 0)
                {
                    // Odd philosophers pick right then left
                    firstFork = rightFork;
                    secondFork = leftFork;
                }
                else
                {
                    firstFork = leftFork;
                    secondFork = rightFork;
                }

                lock (_forks[firstFork])
                {
                    lock (_forks[secondFork])
                    {
                        pickLeftFork();
                        pickRightFork();
                        eat();
                        putLeftFork();
                        putRightFork();
                    }
                }
            }
        }
    }
}
