using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Controllers
{
    public class BobsonController : Controller
    {
        public ActionResult Index()
        {
           return Redirect("/Remessa/Index");
        }
    }
}