using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zad1.Metrics;
using Zad1.Models;

namespace Zad1
{
    public class Program
    {
        private static double Run(List<string> validTerms, string CategoryName, double trainingToTestDataRatio, int stopListWordNumber, IMetric metric, int k, bool whichAlgorithm, IReader reader)
        {
            List<Article> allArticles = reader.ObtainVectorSpaceModels().ToList();
            if (reader.GetType().Name == "CustomReader") allArticles = allArticles.OrderBy(a => Guid.NewGuid()).ToList();
            List<Article> validArticles = ArticleUtils.GetArticlesWithValidTags(allArticles, CategoryName, validTerms);
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
            foreach (var w in allWords.OrderByDescending(v => v.Value).Take(stopListWordNumber))
            {
                stopList.Add(w.Key);
                //Console.Write(w.Key + " ");
            }


            List<ProcessedArticle> processedTrainingArticles = new List<ProcessedArticle>();

            foreach (Article a in trainingArticles)
            {
                processedTrainingArticles.Add(ArticleUtils.processArticle(a, stopList, CategoryName));
            }

            List<string> keyWords = new List<string>();
            foreach (var p in validTerms)
            {
                List<ProcessedArticle> articles = processedTrainingArticles.Where(a => a.label == p).ToList();
                List<string> words = new List<string>();
                foreach (var a in articles)
                {
                    words.AddRange(a.StemmedWords);
                }
                if (whichAlgorithm)
                {
                    keyWords.AddRange(ArticleUtils.getMostFrequentWords(ArticleUtils.idf(words), 20));
                }
                else
                {
                    keyWords.AddRange(ArticleUtils.getMostFrequentWords(ArticleUtils.tf(words), 20));
                }
            }

            processedTrainingArticles.ForEach(a => a.createFeatureVector(keyWords));


            List<ProcessedArticle> processedTestArticles = new List<ProcessedArticle>();
            foreach (Article a in testArticles)
            {
                processedTestArticles.Add(ArticleUtils.processArticle(a, stopList, CategoryName));
            }

            processedTestArticles.ForEach(a => a.createFeatureVector(keyWords));

            int correctNumber = 0;
            foreach (var a in processedTestArticles)
            {
                string guessed = Knn.guesLabel(metric, k, processedTrainingArticles, a);
                a.guessedLabel = guessed;
                //string log = $"Guessed: { guessed} should be: { a.label}";
                if (guessed == a.label)
                {
                    correctNumber++;
                }
            }

            //Console.WriteLine($"For k = {k}, category: {CategoryName}, metric: {metric.GetType().Name} ,  correct are: {((float)correctNumber / (float)processedTestArticles.Count()) * 100}");
            //Results result = new Results();
            //result.createConfusionMatrix(validTerms, processedTestArticles);
            //result.printConfusionMatrix();
            //Console.WriteLine();

            return ((float)correctNumber / processedTestArticles.Count()) * 100;
        }

        private static readonly string CategoryNamePlaces = "places";
        private static readonly string CategoryNameTopics = "topics";
        private static readonly string CategoryNameMedium = "name";

        private static readonly List<string> validPlaces = new List<string>
            {
                "usa",
                "france",
                "uk",
                "canada",
                "japan",
                "west-germany"
            };

        private static readonly List<string> validTopics = new List<string>
            {
                "gold",
                "cocoa",
                "sugar",
                "coffe",
                "grain"
            };

        private static readonly List<string> validNames = new List<string>
            {
                "movie",
                "book"
            };

        static void Main(string[] args)
        {
            double trainingToTestDataRatio = 0.6;
            int stopListWordNumber = 100;
            bool IdfOn = true;

            IMetric metric = new EuclideanMetric();
            Console.WriteLine(metric.GetType().Name);
            RunFor3Sets(0.2, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.6, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.8, stopListWordNumber, metric, IdfOn);

            metric = new ChebyshevMetric();
            Console.WriteLine(metric.GetType().Name);
            RunFor3Sets(0.2, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.6, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.8, stopListWordNumber, metric, IdfOn);

            metric = new ManhattanMetric();
            Console.WriteLine(metric.GetType().Name);
            RunFor3Sets(0.2, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.6, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.8, stopListWordNumber, metric, IdfOn);

            IdfOn = false;

            metric = new EuclideanMetric();
            Console.WriteLine(metric.GetType().Name);
            RunFor3Sets(0.2, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.6, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.8, stopListWordNumber, metric, IdfOn);

            metric = new ChebyshevMetric();
            Console.WriteLine(metric.GetType().Name);
            RunFor3Sets(0.2, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.6, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.8, stopListWordNumber, metric, IdfOn);

            metric = new ManhattanMetric();
            Console.WriteLine(metric.GetType().Name);
            RunFor3Sets(0.2, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.6, stopListWordNumber, metric, IdfOn);
            RunFor3Sets(0.8, stopListWordNumber, metric, IdfOn);

            Console.ReadKey();
        }

        private static void RunFor3Sets(double trainingToTestDataRatio, int stopListWordNumber, IMetric metric, bool IdfOn)
        {
            int[] ks = { 2, 3, 5, 7, 10, 15, 20 };

            string algo = "";
            if (IdfOn) algo = "IDF";
            else algo = "TF";

            for (var i = 0; i < ks.Count(); i++)
            {
                Console.WriteLine(ks[i]);
                double p = Math.Round(Run(validPlaces, CategoryNamePlaces, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn, new DocumentReader()), 1);
                double t = Math.Round(Run(validTopics, CategoryNameTopics, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn, new DocumentReader()),1);
                double m = Math.Round(Run(validNames, CategoryNameMedium, trainingToTestDataRatio, 20, metric, ks[i], IdfOn, new CustomReader()),1);
                File.AppendAllText($@"C:\Users\Bartosz\Desktop\{algo}_{metric.GetType().Name}.txt", $"{ks[i]} & {p} & {t} & {m} \\\\ \n");
            }
        }
    }
}
