using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            const string rssfeedUrl = "https://zeroto365.wordpress.com/feed/atom/";
            
            ViewBag.postList = Get(rssfeedUrl);

            return View();
        }

        public static List<SyndicationItem> Get(string rssFeedUrl)
        {
            var reader = XmlReader.Create(rssFeedUrl);
            var feed = SyndicationFeed.Load(reader);
            reader.Close();

            List<SyndicationItem> postList = new List<SyndicationItem>();

            //Creating a new contentList to hold all the content of each post
            List<String> contentList = new List<String>();

            foreach (SyndicationItem post in feed.Items)
            {
                postList.Add(post);
            }

            return postList;
        }
    }
}