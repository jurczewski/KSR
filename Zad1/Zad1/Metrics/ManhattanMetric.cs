using System;
using System.Collections.Generic;

namespace Zad1.Metrics
{
    public class ManhattanMetric : IMetric
    {
        public double GetDistance(List<double> first, List<double> second)
        {
            double distance = 0;

            for (int i = 0; i < first.Count; i++)
            {
                distance += Math.Abs(first[i] - second[i]);
            }

            return distance;
        }
    }
}
