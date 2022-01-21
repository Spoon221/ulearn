using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static double FavorableOptionWalking;
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            FavorableOptionWalking = double.MaxValue;
            var bestOrder = MakeTrivialPermutation(checkpoints, new int[checkpoints.Length],
                new int[checkpoints.Length], 1, 0);
            return bestOrder;
        }

        private static int[] MakeTrivialPermutation(Point[] checkpoints, int[] positions,
            int[] bestOrder,int position, double way)
        {
            if (position == checkpoints.Length)
            {
                if (way < FavorableOptionWalking)
                    FavorableOptionWalking = way;
                return (int[])positions.Clone();
            }
            for (var i = 1; i < positions.Length; i++)
            {
                var index = Array.IndexOf(positions, i, 0, position);
                if (index > 0)
                    continue;
                positions[position] = i;
                var distance = PointExtensions.DistanceTo(checkpoints[positions[position - 1]],
                    checkpoints[positions[position]]);
                way += distance;
                if (way > FavorableOptionWalking)
                    continue;
                bestOrder = MakeTrivialPermutation(checkpoints, positions,
                    bestOrder, position + 1, way);
                way -= distance;
            }
            return bestOrder;
        }
    }
}