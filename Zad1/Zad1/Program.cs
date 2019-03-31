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

            List<Article> allArticles = new DocumentReader().ObtainVectorSpaceModels().ToList();
            List<Article> validArticles = ArticleUtils.GetArticlesWithValidTags(allArticles, "places", validPlaces);

            Dictionary<string, int> wordsWithoutStemming = new Dictionary<string, int>();

            foreach(var doc in validArticles)
            {
                foreach(var t in doc.Tags)
                {
                    Console.Write(t.Key);
                    foreach(var v in t.Value)
                    {
                        Console.Write(" " + v);
                    }
                    Console.WriteLine();

                }
                foreach (string s in doc.Words)
                {
                    if (!wordsWithoutStemming.ContainsKey(s))
                    {
                        wordsWithoutStemming.Add(s, 1);
                    } else
                    {
                        wordsWithoutStemming[s] = wordsWithoutStemming[s]+1;
                    }
                }
            }

            Console.WriteLine("Number of words(no stemming): " + wordsWithoutStemming.Count);

            Stemmer stemmer = new EnglishStemmer();
            Dictionary<string, int> stemmedWords = new Dictionary<string, int>();

            foreach (var doc in allArticles)
            {

                foreach (string s in doc.Words)
                {
                    string original = s;
                    string stemmed = stemmer.GetSteamWord(original);

                    //if (!original.Equals(stemmed))
                    //{
                    //    Console.WriteLine("Stemmed " + original + " to " + stemmed);
                    //}

                    if (!stemmedWords.ContainsKey(stemmed))
                    {
                        stemmedWords.Add(stemmed, 1);
                    }
                    else
                    {
                        stemmedWords[stemmed] = stemmedWords[stemmed] + 1;
                    }
                }
            }

            Console.WriteLine("Number of words(with stemming): " + stemmedWords.Count);

            var x = 10;
            Console.WriteLine("Term Frequency("+ x + " most frequent)");

            foreach (var s in stemmedWords.OrderByDescending(v => v.Value).Take(x))
            {
                double tf = (double)s.Value / (double)stemmedWords.Count;
                Console.WriteLine(s.Key + " " + tf + " ");
            }

            Console.ReadKey();
        }
    }
}
