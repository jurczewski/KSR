using System.Collections.Generic;
using System.Linq;
using Zad1.Metrics;
using Zad1.Models;

namespace Zad1
{
    public static class Knn
    {
        public static string guesLabel(IMetric metric, int k, List<ProcessedArticle> trainingArticles, ProcessedArticle articleToLabel)
        {
            List<ProcessedArticle> knn = trainingArticles.OrderBy(a => metric.GetDistance(a.getFeatureVector(),articleToLabel.getFeatureVector())).ToList();
            return knn.Take(k).GroupBy(a => a.label).OrderBy(g => g.Count()).Last().Key;
        }


    }
}
