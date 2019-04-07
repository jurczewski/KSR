using System;
using System.Collections.Generic;
using System.Linq;
using Zad1.Metrics;
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

            //List<string> usaCities = new List<string> {"new york", "los angeles", "chicago", "houston", "phoenix", "philadelphia"};
            double trainingToTestDataRatio = 0.6;
            int stopListWordNumber = 100;
            List<Article> allArticles = new DocumentReader().ObtainVectorSpaceModels().ToList();
            List<Article> validArticles = ArticleUtils.GetArticlesWithValidTags(allArticles, "places", validPlaces);
            int trainingArticleNumber = Convert.ToInt32(trainingToTestDataRatio * validArticles.Count);
            List<Article> trainingArticles = validArticles.Take(trainingArticleNumber).ToList();
            List<Article> testArticles = validArticles.Skip(trainingArticleNumber).ToList();


            Dictionary<string, int> allWords = new Dictionary<string, int>();
            foreach (Article article in trainingArticles)
            {
                foreach (string w in article.Words)
                {
                    if (!allWords.ContainsKey(w))
                    {
                        allWords.Add(w, 1);
                    }
                    else
                    {
                        allWords[w] = allWords[w] + 1;
                    }
                }
            }

            List<string> stopList = new List<string>();
            foreach(var w in allWords.OrderByDescending(v => v.Value).Take(stopListWordNumber))
            {
                stopList.Add(w.Key);
                //Console.Write(w.Key + " ");
            }


            List<ProcessedArticle> processedTrainingArticles = new List<ProcessedArticle>();

            foreach(Article a in trainingArticles)
            {
                processedTrainingArticles.Add(ArticleUtils.processArticle(a, stopList));
            }

            List<string> keyWords = new List<string>();
            foreach(var p in validPlaces)
            {
                List<ProcessedArticle> articles = processedTrainingArticles.Where(a => a.label == p).ToList();
                List<string> words = new List<string>();
                foreach(var a in articles)
                {
                    words.AddRange(a.StemmedWords);
                }
                keyWords.AddRange(ArticleUtils.getMostFrequentWords(ArticleUtils.tf(words), 20));
            }

            processedTrainingArticles.ForEach(a => a.createFeatureVector(keyWords));


            List<ProcessedArticle> processedTestArticles = new List<ProcessedArticle>();
            foreach (Article a in testArticles)
            {
                processedTestArticles.Add(ArticleUtils.processArticle(a, stopList));
            }

            processedTestArticles.ForEach(a => a.createFeatureVector(keyWords));
            
            foreach(var a in processedTestArticles)
            {
                string guessed = Knn.guesLabel(new EuclideanMetric(), 3, processedTrainingArticles, a);

                string log = "Guessed: " + guessed + " should be: " + a.label;
                Console.WriteLine(log);
            }


            Console.ReadKey();
        }
    }
}
