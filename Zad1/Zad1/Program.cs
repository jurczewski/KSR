using System;
using System.Collections.Generic;
using System.Linq;
using Zad1.Models;

namespace Zad1
{
    public class Program
    {        

        static void Main(string[] args)
        {
            List<string> validPlaces = new List<string>
            {
                "west-germany",
                "usa",
                "france",
                "uk",
                "canada",
                "japan"
            };

            List<string> usaCities = new List<string> {"new york", "los angeles", "chicago", "houston", "phoenix", "philadelphia"};

            List<Article> allArticles = new DocumentReader().ObtainVectorSpaceModels().ToList();
            List<Article> validArticles = ArticleUtils.GetArticlesWithValidTags(allArticles, "places", validPlaces);

            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (Article article in validArticles)
            {
                foreach (string w in article.Words)
                {
                    if (!words.ContainsKey(w))
                    {
                        words.Add(w, 1);
                    }
                    else
                    {
                        words[w] = words[w] + 1;
                    }
                }
            }

            List<string> stopList = new List<string>();
            foreach(var w in words.OrderByDescending(v => v.Value).Take(100))
            {
                stopList.Add(w.Key);
                Console.Write(w.Key + " ");
            }

            List<ProcessedArticle> processedArticles = new List<ProcessedArticle>();

            foreach(Article a in validArticles)
            {
                processedArticles.Add(ArticleUtils.processArticle(a, stopList));
            }

            Console.ReadKey();
        }
    }
}
