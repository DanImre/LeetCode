using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_458
    {
        public Hard_458()
        {

        }
        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            if (buckets == 1)
                return 0;
            int trialCount = minutesToTest / minutesToDie;
            //if there are <buckets> of buckets and <trialCount> trials and <p> pigs, then
            //there is a solution with <p> pigs only if
            // <buckets> <= (<trialCount> + 1)^<p> //(<trialCount> + 1) cuz a pig can drink form 0 buckets as well

            //<buckets> <= (<trialCount> + 1)^<p>
            //log_buckets(buckets) <= log_buckets[(trialCount + 1)^p]
            //log_buckets(buckets) <= p * log_buckets[(trialCount + 1)]
            //log_buckets(buckets) <= log_buckets(buckets^p) * log_buckets[(trialCount + 1)]
            //buckets <= buckets^p * (trialCount + 1)
            return (int)Math.Log(buckets - 1, trialCount + 1) + 1;
        }
    }
}
