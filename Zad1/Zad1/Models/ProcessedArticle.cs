using System.Collections.Generic;

namespace Zad1.Models
{
    public class ProcessedArticle : Article
    {
        public string label { get; set; } //place
        public List<string> StemmedWords { get; set; }
        public List<Dictionary<string, double>> characteristicMatrix = new List<Dictionary<string, double>>();  //miasta, waluta, krainy geograficzne, 

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
    }
}
