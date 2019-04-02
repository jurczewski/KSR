using System.Collections.Generic;

namespace Zad1.Models
{
    public class ProcessedArticle : Article
    {
        public string label { get; set; } //place
        public List<string> StemmedWords { get; set; }

        public ProcessedArticle(Article article, string _label, List<string> _StemmedWords) 
            : base(article.Title, article.Tags, article.Words)
        {
            label = _label;
            StemmedWords = _StemmedWords;
        }
    }
}
