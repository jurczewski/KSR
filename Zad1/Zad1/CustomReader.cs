﻿using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Zad1.Models;

namespace Zad1
{
    public class CustomReader : IReader
    {
        public IEnumerable<Article> ObtainVectorSpaceModels()
        {
            for (int i = 0; i < 1; i++)
            {
                var rawXml = File.ReadAllText($"../../Data/ours.sgm");
                var doc = new HtmlDocument();
                doc.LoadHtml(rawXml);
                var regex = new Regex("[^a-zA-Z]");

                foreach (var article in doc.DocumentNode.Descendants("REUTERS"))
                {
                    var body = article.Descendants("BODY").FirstOrDefault();
                    var tags = new Dictionary<string, List<string>>();
                    foreach (var tagNode in article.ChildNodes.Where(node => node.ChildNodes.Any(htmlNode => htmlNode.Name == "d")))
                    {
                        tags[tagNode.Name] = tagNode.Descendants("D").Select(node => node.InnerText).ToList();
                    }

                    if (body != null && tags.Count > 0)
                    {
                        yield return new Article
                        {
                            Words = regex.Replace(body.InnerText, " ").ToLower().Split(' ').Where(s => s.Length > 2)
                                .ToList(),
                            Tags = tags,
                            Title = article.Descendants("NAME").First().InnerText
                        };
                    }
                }
            }
        }
    }
}
