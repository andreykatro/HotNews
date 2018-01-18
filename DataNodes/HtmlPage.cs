using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DataNodes
{
    public class HtmlPage
    {
        public IEnumerable<string> Parser(string url = "http://www.pravda.com.ua/"
                                            , string xPath = "//div[@class='news tab_item']"
                                            ,string codepageName = "windows-1251")
        {
            string htmlContent = "";

            using (WebClient client = new WebClient())
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (Stream data = client.OpenRead(new Uri(url)))
                using (StreamReader reader = new StreamReader(data, Encoding.GetEncoding(codepageName)))
                {
                    htmlContent = reader.ReadToEnd();
                }
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(htmlContent);

            var x = doc.DocumentNode.SelectNodes(xPath);
            foreach (var item in x)
            {
                yield return item.InnerHtml;
            }
        }
    }
}
