using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_857
    {
        public Hard_857()
        {

        }
        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {
            double totalCost = double.MaxValue;
            double currentTotalQuality = 0;
            List<(double wq, int q)> wageToQualityRatio = new List<(double wq, int q)>();

            for (int i = 0; i < wage.Length; i++)
                wageToQualityRatio.Add(((double)wage[i] / quality[i], quality[i]));

            wageToQualityRatio.Sort((a,b) => a.wq.CompareTo(b.wq));

            PriorityQueue<int, int> highestQualityWorkers = new PriorityQueue<int, int>();

            for (int i = 0; i < wage.Length; i++)
            {
                highestQualityWorkers.Enqueue(wageToQualityRatio[i].q, -wageToQualityRatio[i].q);
                currentTotalQuality += wageToQualityRatio[i].q;

                if (highestQualityWorkers.Count > k)
                    currentTotalQuality -= highestQualityWorkers.Dequeue();

                if (highestQualityWorkers.Count == k)
                    totalCost = Math.Min(totalCost, currentTotalQuality * wageToQualityRatio[i].wq);
            }
            return totalCost;
        }
    }
}
