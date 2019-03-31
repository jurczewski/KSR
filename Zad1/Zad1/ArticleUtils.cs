using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Zad1.Models;
using System;

namespace Zad1
{
    public static class ArticleUtils
    {
        public static List<Article> GetArticlesWithValidTags(List<Article> allArticles, string tagName, List<string> tags)
        {
            return allArticles.Where(n => n.Tags.ContainsKey(tagName) && n.Tags[tagName].Count == 1 && tags.Contains(n.Tags[tagName][0])).ToList();
        }
    }
}
