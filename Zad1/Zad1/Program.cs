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
            List<Article> _readDocuments = new DocumentReader().ObtainVectorSpaceModels().ToList();
            //foreach(var article in _readDocuments)
            //{
            //    Console.WriteLine("Title: " + article.Title);
            //}

            Console.WriteLine("******\n" + _readDocuments[0].Title);

            foreach (var word in _readDocuments[0].Words)
            {
                Console.WriteLine(word);
            }

            foreach (var tag in _readDocuments[0].Tags)
            {
                Console.WriteLine(tag.Key + ", Number of Values: " + tag.Value.Count);
            }

            Console.ReadKey();
        }
    }
}
