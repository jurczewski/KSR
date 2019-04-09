using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zad1.Models;

namespace Zad1
{
    public class Results
    {
        public int[][] confusionMatrix;
        public List<string> labels;
        public List<ProcessedArticle> testArticles;

        public int[][] createConfusionMatrix(List<string> _labels, List<ProcessedArticle> _testArticles)
        { 
            labels = _labels;
            testArticles = _testArticles;
            int numberOfClasses = labels.Count;
            confusionMatrix = new int[numberOfClasses][];
            for (int i = 0; i < numberOfClasses; i++)
            {
                confusionMatrix[i] = new int[numberOfClasses];
            }

            foreach (var article in testArticles)
            {
                int row = labels.IndexOf(article.label);
                int column = labels.IndexOf(article.guessedLabel);
                confusionMatrix[row][column]++;
            }

            return confusionMatrix;
        }
        public string[][] createPrintableConfusionMatrix()
        { 
            List<string> _labels = new List<string>();
            foreach(var s in labels)
            {
                if (s.Length > 10)
                {
                    _labels.Add(s.Substring(0, 8));
                }
                else _labels.Add(s);
            }
            int length = _labels.Count + 1;
            string[][] printableMatrix = new string[length][];
            for (int i = 0; i < length; i++)
            {
                printableMatrix[i] = new string[length];
            }
            for (int i = 0; i < printableMatrix[0].Length; i++)
            {
                for (int j = 0; j < printableMatrix[0].Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        printableMatrix[i][j] = "actual\\pred";
                        continue;
                    }
                    if (i == 0)
                    {
                        if (j > 0) printableMatrix[i][j] = _labels[j - 1];
                    }
                    else if (j == 0)
                    {
                        if (i > 0) printableMatrix[i][j] = _labels[i - 1];
                    }
                    else
                    {
                        printableMatrix[i][j] = confusionMatrix[i - 1][j - 1].ToString();
                    }
                }
            }
            return printableMatrix;
        }
        public void printConfusionMatrix()
        {
            string[][] printableMatrix = createPrintableConfusionMatrix();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < printableMatrix[0].Length; i++)
            {
                sb.Append("{");
                sb.Append(i);
                sb.Append(",11}");
            }
            for (int i = 0; i < printableMatrix[0].Length; i++)
            {

                Console.WriteLine(sb.ToString(), printableMatrix[i].ToArray());
            }
        }

        private int TruePositives()
        {
            int length = confusionMatrix[0].Length;
            int ttp = 0;

            for (int i = 0; i < length; i++)
            {
                ttp += confusionMatrix[i][i];
            }
            return ttp;
        }

        private int FalsePositives(int label, int[][] confusionMatrix)
        {
            int length = confusionMatrix[0].Length;
            int falsePositives = 0;
            for (int i = 0; i < length; i++)
            {
                if (i != label)
                {
                    falsePositives += confusionMatrix[i][label];
                }
            }
            return falsePositives;
        }

        private int FalseNegatives(int label, int[][] confusionMatrix)
        {
            int length = confusionMatrix[0].Length;
            int falseNegatives = 0;
            for (int i = 0; i < length; i++)
            {
                if (i != label)
                {
                    falseNegatives += confusionMatrix[label][i];
                }
            }
            return falseNegatives;
        }

        private int TrueNegatives(int label, int[][] confusionMatrix)
        {
            int length = confusionMatrix[0].Length;
            int trueNegatives = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != label && j != label)
                    {
                        trueNegatives += confusionMatrix[j][i];
                    }
                }
            }
            return trueNegatives;
        }

        private double CalculatePrecision(int[][] confusionMatrix)
        {
            int l = confusionMatrix[0].Length;
            int ttp = TruePositives();
            List<double> classPrecision = new List<double>();

            for (int i = 0; i < l; i++)
            {
                classPrecision.Add(ttp / (1.0 * ttp + FalsePositives(i, confusionMatrix)));
            }

            return classPrecision.Average();
        }

        private double CalculateRecall(int[][] confusionMatrix)
        {
            int l = confusionMatrix[0].Length;
            int ttp = TruePositives();
            List<double> classRecall = new List<double>();

            for (int i = 0; i < l; i++)
            {
                classRecall.Add(ttp / (1.0 * ttp + FalseNegatives(i, confusionMatrix)));
            }

            return classRecall.Average();
        }

        private double CalculateSpecificity(int[][] confusionMatrix)
        {
            int l = confusionMatrix[0].Length;
            int ttn = Enumerable.Range(0, l).Select(c => TrueNegatives(c, confusionMatrix)).Sum();
            List<double> classSpecificity = new List<double>();

            for (int i = 0; i < l; i++)
            {
                classSpecificity.Add(ttn / (1.0 * ttn + FalsePositives(i, confusionMatrix)));
            }

            return classSpecificity.Average();
        }

        private double CalculateAverageAccuracy(int[][] confusionMatrix)
        {
            int l = confusionMatrix[0].Length;
            int ttp = TruePositives();
            int total = 0;
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    total += confusionMatrix[i][j];
                }
            }


            return (1.0 * ttp) / total;
        }

    }
}
