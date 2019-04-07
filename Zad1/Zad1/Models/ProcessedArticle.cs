using System.Collections.Generic;
using System.Linq;

namespace Zad1.Models
{
    public class ProcessedArticle : Article
    {
        public string label { get; set; } //place
        public List<string> StemmedWords { get; set; }
        public Dictionary<string, double> featureVector = new Dictionary<string, double>();

        public ProcessedArticle(Article article, string _label, List<string> _StemmedWords) 
        //    : base(article.Title, article.Tags, article.Words)
        {
            Title = article.Title;
            Words = article.Words;
            Tags = article.Tags;

            label = _label;
            StemmedWords = _StemmedWords;
        }

        public List<double> getCharactaristicMatrix()
        {
            return new List<double>();
        }

        public void createFeatureVector(List<string> keywords)
        {
            foreach (var kw in keywords)
            {
                featureVector[kw] = StemmedWords.Count(t => t == kw);
            }
        }

        public List<double> getFeatureVector()
        {
            return featureVector.Select(f => f.Value).ToList();
        }
    }
}
