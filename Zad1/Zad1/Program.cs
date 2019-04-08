using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Zad1.Metrics;
using Zad1.Models;

namespace Zad1
{
    public class Program
    {
        private static double Run(List<string> validTerms, string CategoryName, double trainingToTestDataRatio, int stopListWordNumber, IMetric metric, int k, bool whichAlgorithm)
        {
            List<Article> allArticles = new DocumentReader().ObtainVectorSpaceModels().ToList();
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

            //Console.WriteLine($"For k = {k}, category: {CategoryName}, metric: {metric.GetType().Name} , correct are: {((float)correctNumber / (float)processedTestArticles.Count()) * 100}");
            //File.AppendAllText(@"C:\Users\Bartosz\Desktop", $"{k} & {((float)correctNumber / (float)processedTestArticles.Count()) * 100}");
            int[][] confusionMatrix = Results.createConfusionMatrix(validTerms, processedTestArticles);

            //Results.printConfusionMatrix(confusionMatrix, validTerms);
            //Console.WriteLine();
            return ((float)correctNumber / (float)processedTestArticles.Count()) * 100;
        }

        private static readonly string CategoryNamePlaces = "places";
        private static readonly string CategoryNameTopics = "topics";
        private static readonly string CategoryNameMedium = "title";

        static void Main(string[] args)
        {
            List<string> validPlaces = new List<string>
            {
                "usa",
                "france",
                "uk",
                "canada",
                "japan",
                "west-germany"
            };

            List<string> validTopics = new List<string>
            {
                "gold",
                "cocoa",
                "sugar",
                "coffe",
                "grain"
            };

            List<string> validMedium = new List<string>
            {
                "biology",
                "love"
            };

            double trainingToTestDataRatio = 0.6;
            int stopListWordNumber = 100;
            bool IdfOn = true;

            int[] ks = { 2, 3, 5, 7, 10, 15, 20 };
            
            IMetric metric = new EuclideanMetric();
            for (var i = 0; i < ks.Count(); i++)
            {
                Console.WriteLine(i);
                double p = Run(validPlaces, CategoryNamePlaces, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
                double t = Run(validTopics, CategoryNameTopics, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
                double b = Run(validPlaces, CategoryNameMedium, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
                File.AppendAllText(@"C:\Users\Bartosz\Desktop\IDF_Euclidean.txt", $"{i} & {p} & {t} & {b}\n");
            }
            //metric = new ChebyshevMetric();
            //for (var i = 0; i < ks.Count(); i++)
            //{
            //    double p = Run(validPlaces, CategoryNamePlaces, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
            //    double t = Run(validTopics, CategoryNameTopics, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
            //    //double b = Run(validPlaces, CategoryNamePlaces, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
            //    File.AppendAllText(@"C:\Users\Bartosz\Desktop\IDF_Chebyshev.txt", $"{i} & {p} & {t}\n");
            //}
            //metric = new ManhattanMetric();
            //for (var i = 0; i < ks.Count(); i++)
            //{
            //    double p = Run(validPlaces, CategoryNamePlaces, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
            //    double t = Run(validTopics, CategoryNameTopics, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
            //    //double b = Run(validPlaces, CategoryNamePlaces, trainingToTestDataRatio, stopListWordNumber, metric, ks[i], IdfOn);
            //    File.AppendAllText(@"C:\Users\Bartosz\Desktop\IDF_Manhattan.txt", $"{i} & {p} & {t}\n");
            //}

            Console.ReadKey();
        }

        
    }
}
