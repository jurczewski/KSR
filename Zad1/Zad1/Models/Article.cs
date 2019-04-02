using System.Collections.Generic;

namespace Zad1.Models
{
    public class Article
    {
        public string Title { get; set; }
        public Dictionary<string, List<string>> Tags { get; set; }
        public List<string> Words { get; set; }

        public Article(string _Title, Dictionary<string, List<string>> _Tags, List<string> _Words)
        {
            Title = _Title;
            Tags = _Tags;
            Words = _Words;
        }
    }
}
