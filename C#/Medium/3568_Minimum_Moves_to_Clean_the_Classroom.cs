namespace Medium
{
    public class _3568_Minimum_Moves_to_Clean_the_Classroom
    {
        public int MinMoves(string[] classroom, int energy)
        {
            int n = classroom.Length;
            int m = classroom[0].Length;

            Dictionary<(int x, int y), int> litterLabels = [];
            int runningCount = 0;

            (int x, int y) startpos = (0, 0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (classroom[i][j] == 'S')
                        startpos = (j, i);
                    else if (classroom[i][j] == 'L')
                        litterLabels[(i, j)] = runningCount++;
                }

            // no litter
            if (runningCount == 0)
                return 0;

            int litterMask = 0;
            for (int i = 0; i < runningCount; i++)
                litterMask |= 1 << i;

            Queue<(int x, int y, int steps, int energy, int litterMask)> q = [];
            q.Enqueue((startpos.x, startpos.y, 0, energy, litterMask));

            HashSet<(int x, int y, int energy, int littermask)> hs = [];

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                if (curr.x < 0
                    || curr.y < 0
                    || curr.y >= classroom.Length
                    || curr.x >= classroom[0].Length)
                    continue;

                if (curr.energy < 0)
                    continue;

                if (!hs.Add((curr.x, curr.y, curr.energy, curr.litterMask)))
                    continue;

                switch (classroom[curr.y][curr.x])
                {
                    case 'X':
                        continue;
                    case 'L':
                        curr.litterMask &= ~(1 << litterLabels[(curr.y, curr.x)]);

                        if (curr.litterMask == 0)
                            return curr.steps;

                        break;
                    case 'R':
                        curr.energy = energy;
                        break;
                    default:
                        break;
                }

                q.Enqueue((curr.x - 1, curr.y, curr.steps + 1, curr.energy - 1, curr.litterMask));
                q.Enqueue((curr.x + 1, curr.y, curr.steps + 1, curr.energy - 1, curr.litterMask));
                q.Enqueue((curr.x, curr.y - 1, curr.steps + 1, curr.energy - 1, curr.litterMask));
                q.Enqueue((curr.x, curr.y + 1, curr.steps + 1, curr.energy - 1, curr.litterMask));
            }

            return -1;
        }
    }
}
