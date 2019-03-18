using System;
using System.Collections.Generic;
using System.Linq;
using Zad1.Models;

namespace Zad1
{
    public class Program
    {        
        List<string> _validPlaces = new List<string>
        {
            "west-germany",
            "usa",
            "france",
            "uk",
            "canada",
            "japan"
        };
        static void Main(string[] args)
        {
            //List<Article> _readDocuments = new DocumentReader().ObtainVectorSpaceModels().ToList();
            //foreach (var article in _readDocuments)
            //{
            //    foreach ( var tags in article.Tags)
            //    {
            //        foreach( var s in tags.Value)
            //        {
            //            Console.Write(s+ " ");

            //        }
            //    }
            //    Console.WriteLine();

            //}

            List<Article> _readDocuments = new DocumentReader().ObtainVectorSpaceModels().ToList();
            Dictionary<string, int> wordsWithoutStemming = new Dictionary<string, int>();

            foreach(var doc in _readDocuments)
            {

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

            foreach (var doc in _readDocuments)
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

            //foreach (var word in _readDocuments[0].Words)
            //{
            //    Console.WriteLine(word);
            //}

            //foreach (var tag in _readDocuments[0].Tags)
            //{
            //    Console.WriteLine(tag.Key + ", Number of Values: " + tag.Value.Count);
            //}

            Console.ReadKey();
        }
    }
}
