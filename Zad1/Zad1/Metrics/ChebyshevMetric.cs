using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad1.Metrics
{
    public class ChebyshevMetric : IMetric
    {
        public double GetDistance(List<double> first, List<double> second)
        {
            List<double> data = new List<double>();
            for (int i = 0; i < first.Count; i++)
            {
                data.Add(Math.Abs(first[i] - second[i]));
            }
            return data.Max<double>();
        }
    }
}
