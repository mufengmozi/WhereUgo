using Crawler.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class TravelNodesSearch
    {
        private static Logger logger = new Logger(typeof(TravelNotesList));
        public static List<TravelNotesList> Crawler(string url)
        {
            List<TravelNotesList> categoryList = new List<TravelNotesList>();
            try
            {
                string html = HttpHelper.DownloadCategory(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fristPath = "/html/body/div[2]/div[4]/div/div[4]/div/ul/li";
                HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
                int k = 1;
                foreach (HtmlNode node in nodeList)
                {
                    //categoryList.AddRange(First(node.InnerHtml, k++.ToString("00") + "f", "root"));
                }
            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
            }
            return categoryList;
        }
    }
}
