using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Easy
{
    public class _836_Rectangle_Overlap
    {
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            bool xOverlaps = rec1[0] < rec2[0] && rec2[0] < rec1[2]
                || rec1[0] < rec2[2] && rec2[2] < rec1[2]
                || rec2[0] <= rec1[0] && rec1[2] <= rec2[2];

            bool yOverlaps = rec1[1] < rec2[1] && rec2[1] < rec1[3]
                || rec1[1] < rec2[3] && rec2[3] < rec1[3]
                || rec2[1] <= rec1[1] && rec1[3] <= rec2[3];

            return xOverlaps && yOverlaps;
        }
    }
}
