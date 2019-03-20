using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class Article : IComparable<Article>
    {
        public string Heading { get; set; }
        public string Content { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Author { get; set; }

        public int CompareTo(Article obj)
        {
            return PublishedOn.CompareTo(obj.PublishedOn);
        }
    }

    public static class NewsArticleManager
    {
        private static List<Article> _allArticles = new List<Article>();

        static NewsArticleManager()
        {
            _allArticles.Add(
                new Article
                {
                    Heading= "Pakistan claims 2 IAF jets shot down, pilots held; also releases video",
                    Content= "Pakistan has said its air force shot down two Indian fighter jets on Wednesday morning and claims to have captured two Indian Air Force pilots. Pakistan’s military spokesman Major General Asif Ghafoor said one of the pilots is in hospital.",
                    Author="Phaniraj",
                    PublishedOn = DateTime.Now
                });
            _allArticles.Add(
                new Article
                {
                    Heading = "Pakistan claims 2 IAF jets shot down, pilots held; also releases video",
                    Content = "Pakistan has said its air force shot down two Indian fighter jets on Wednesday morning and claims to have captured two Indian Air Force pilots. Pakistan’s military spokesman Major General Asif Ghafoor said one of the pilots is in hospital.",
                    Author = "Phaniraj",
                    PublishedOn = DateTime.Now
                });
            _allArticles.Add(
                new Article
                {
                    Heading = "Pakistan claims 2 IAF jets shot down, pilots held; also releases video",
                    Content = "Pakistan has said its air force shot down two Indian fighter jets on Wednesday morning and claims to have captured two Indian Air Force pilots. Pakistan’s military spokesman Major General Asif Ghafoor said one of the pilots is in hospital.",
                    Author = "Phaniraj",
                    PublishedOn = DateTime.Now
                });
        }
        public static List<Article> GetLatest()
        {
            _allArticles.Sort();
            return _allArticles;
        }

        public static void AddNewArticle(Article article)
        {
            _allArticles.Add(article);
        }

        public static Article Details(string heading)
        {
            return _allArticles.Find(a => a.Heading.Contains(heading));
        }
    }
}