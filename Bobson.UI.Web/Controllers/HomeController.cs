using Bobson.UI.Web.Models;
using PdfSharp;
using PdfSharp.Pdf;
using Rotativa;
using System.IO;
using System.Web.Mvc;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Bobson.UI.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}