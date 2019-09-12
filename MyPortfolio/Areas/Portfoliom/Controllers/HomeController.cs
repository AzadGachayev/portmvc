using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Areas.Portfoliom.Controllers
{
    public class HomeController : Controller
    {
        // GET: Portfoliom/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}