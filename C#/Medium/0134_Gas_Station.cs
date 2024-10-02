using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_134
    {
        public Medium_134()
        {
            Console.WriteLine(CanCompleteCircuit2( //3
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 3, 4, 5, 1, 2 }));

            Console.WriteLine(CanCompleteCircuit2( //-1
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 3 }));

            Console.WriteLine(CanCompleteCircuit2( //4
                new int[] { 5, 1, 2, 3, 4 },
                new int[] { 4, 4, 1, 5, 1 }));

            Console.WriteLine(CanCompleteCircuit2(//3
                new int[] { 5, 8, 2, 8 },
                new int[] { 6, 5, 6, 6 }));
        }
        //Timelimit exceeded
        public  int CanCompleteCircuit(int[] gas, int[] cost)
        {
            for (int lll = 0; lll < gas.Length; lll++)
            {
                int i = lll;
                int gastank = gas[i] - cost[i];
                ++i;
                i %= gas.Length;
                while (i != lll && gastank >= 0)
                {
                    gastank += gas[i] - cost[i];
                    ++i;
                    i %= gas.Length;
                }

                if (i == lll && gastank >= 0)
                    return lll;
            }

            return -1;
        }

        //almost
        public  int CanCompleteCircuit2(int[] gas, int[] cost)
        {
            int sum = 0;
            int[] combinedValue = new int[gas.Length];
            for (int i = 0; i < gas.Length; i++)
            {
                int combined = gas[i] - cost[i];
                sum += combined;
                combinedValue[i] = combined;
            }
            if (sum < 0)
                return -1;

            int actSum = 0;
            int bestPlaceToStart = -1;
            int firstPosAfterNegative = -1;
            for (int i = 1; i < gas.Length; i++)
                if (combinedValue[i - 1] < 0 && combinedValue[i] > 0)
                {
                    firstPosAfterNegative = i;
                    bestPlaceToStart = i;
                    break;
                }

            if (firstPosAfterNegative == -1) //All path are good
                return 0;

            Console.WriteLine("--- " + firstPosAfterNegative);

            int j = 0;
            sum = 0;
            int actStartPos = firstPosAfterNegative;
            while (j < gas.Length)
            {
                int tempValue = combinedValue[(firstPosAfterNegative + j) % gas.Length];

                if (actSum < 0)

                    if (tempValue < 0)
                    {
                        while (tempValue < 0 && j < gas.Length)
                        {
                            ++j;
                            tempValue = combinedValue[(firstPosAfterNegative + j) % gas.Length];
                        }

                        if (j == gas.Length)
                            break;


                        actSum = tempValue;
                        actStartPos = (firstPosAfterNegative + j) % gas.Length;
                    }
                    else
                        actSum += tempValue;

                if (actSum > sum)
                {
                    sum = actSum;
                    bestPlaceToStart = actStartPos;
                }


                ++j;
            }
            if (actSum > sum)
            {
                sum = actSum;
                bestPlaceToStart = actStartPos;
            }
            //return bestPlaceToStart;

            //This was ny idea:
            sum = 0;
            int maxIndex = -1;
            int maxSum = int.MinValue;

            for (int i = gas.Length - 1; i >= 0; i--)
            {
                sum += gas[i] - cost[i];

                if (sum > maxSum)
                {
                    maxIndex = i;
                    maxSum = sum;
                }
            }

            return sum < 0 ? -1 : maxIndex;
        }

        public  int CanCompleteCircuit3(int[] gas, int[] cost)
        {
            int currGain = 0;
            int totalGain = 0;
            int solution = 0;

            for (int i = 0; i < gas.Length; ++i)
            {
                int gain = gas[i] - cost[i];
                totalGain += gain;
                currGain += gain;

                // If we meet a "valley", start over from the next station
                // with 0 initial gas.
                if (currGain < 0)
                {
                    solution = i + 1;
                    currGain = 0;
                }
            }

            return totalGain >= 0 ? solution : -1;
        }
    }
}
