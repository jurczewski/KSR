using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zad1.Models;

namespace Zad1
{
    public static class Results
    {
        
        public static int[][] createConfusionMatrix(List<string> labels, List<ProcessedArticle> testArticles)
        {
            int numberOfClasses = labels.Count;
            int[][] confusionMatrix = new int[numberOfClasses][];
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
        public static string[][] createPrintableConfusionMatrix(int[][] confusionMatrix, List<string> _labels)
        { 
            List<string> labels = new List<string>();
            foreach(var s in _labels)
            {
                if (s.Length > 10)
                {
                    labels.Add(s.Substring(0, 8));
                }
                else labels.Add(s);
            }
            int length = labels.Count + 1;
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
                        if (j > 0) printableMatrix[i][j] = labels[j - 1];
                    }
                    else if (j == 0)
                    {
                        if (i > 0) printableMatrix[i][j] = labels[i - 1];
                    }
                    else
                    {
                        printableMatrix[i][j] = confusionMatrix[i - 1][j - 1].ToString();
                    }
                }
            }
            return printableMatrix;
        }
        public static void printConfusionMatrix(int[][] confusionMatrix, List<string> validTerms)
        {
            string[][] printableMatrix = Results.createPrintableConfusionMatrix(confusionMatrix, validTerms);

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
    }
}
