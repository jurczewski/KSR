using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1.Metrics
{
    public interface IMetric
    {
        double GetDistance(List<double> first, List<double> second);
    }
}
