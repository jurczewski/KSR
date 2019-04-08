using System.Collections.Generic;
using System.Linq;
using Zad1.Models;

namespace Zad1
{
    public static class ArticleUtils
    {
        public static List<Article> GetArticlesWithValidTags(List<Article> allArticles, string tagName, List<string> tags)
        {
            return allArticles.Where(n => n.Tags.ContainsKey(tagName) && n.Tags[tagName].Count == 1 && tags.Contains(n.Tags[tagName][0])).ToList();
        }

        public static ProcessedArticle processArticle(Article article, List<string> stopList, string categoryName)
        {
            Stemmer stemmer = new EnglishStemmer();
            List<string> words = new List<string>();
            List<string> stemmedWords = new List<string>();

            words = article.Words.Where(e => !stopList.Contains(e)).ToList();

            foreach (string s in words)
            {
                string stemmed = stemmer.GetSteamWord(s);
                stemmedWords.Add(stemmed);
            }

            string label = article.Tags[categoryName][0];
            return new ProcessedArticle(article, label, stemmedWords);
        }

        public static Dictionary<string, int> tf(List<string> words)
        {
            Dictionary<string, int> wordDictionary = new Dictionary<string, int>();
            foreach (string s in words)
            {
                if (!wordDictionary.ContainsKey(s))
                {
                    wordDictionary.Add(s, 1);
                }
                else
                {
                    wordDictionary[s] = wordDictionary[s] + 1;
                }
            }
            return wordDictionary;
        }

        public static Dictionary<string, double> idf(List<string> words)
        {
            Dictionary<string, int> tfWordDictionary = new Dictionary<string, int>();
            Dictionary<string, double> tfIdfWordDictionary = new Dictionary<string, double>();

            foreach (string s in words)
            {
                if (!tfWordDictionary.ContainsKey(s))
                {
                    tfWordDictionary.Add(s, 1);
                }
                else
                {
                    tfWordDictionary[s] = tfWordDictionary[s] + 1;
                }
            }

            foreach (var v in tfWordDictionary)
            {
                tfIdfWordDictionary.Add(v.Key, v.Value / words.Count);
            }
            return tfIdfWordDictionary;
        }

        public static List<string> getMostFrequentWords(Dictionary<string,int> dic, int count)
        {
            return dic.OrderByDescending(v => v.Value).Take(count).Select(k => k.Key).ToList();
        }

        public static List<string> getMostFrequentWords(Dictionary<string, double> dic, int count)
        {
            return dic.OrderByDescending(v => v.Value).Take(count).Select(k => k.Key).ToList();
        }
    }
}
