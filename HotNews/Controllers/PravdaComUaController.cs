using Microsoft.AspNetCore.Mvc;
using DataNodes;
using System.Net;
using System.Web;

namespace HotNews.Controllers
{
    [Route("api/[controller]")]
    public class PravdaComUaController : Controller
    {
        // GET api/PravdaComUa
        [HttpGet]
        public ContentResult Get()
        {
            HtmlPage html = new HtmlPage();
            var value = html.Parser();
            string htmlCode = "";
            foreach (var item in html.Parser())
            {
                htmlCode += HttpUtility.HtmlDecode(item);
            }

            return new ContentResult
            {
                ContentType = "text/html;charset=windows-1251",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<!DOCTYPE html> <html><body>" + htmlCode + "</body></html>"
            };
        }
    }
}
