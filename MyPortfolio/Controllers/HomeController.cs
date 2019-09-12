using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        MyPortfolioDB DB = new MyPortfolioDB();
        public ActionResult Index()
        {
            ViewBag.Section1 = DB.Section1Div.Find(1);
            ViewBag.workCat = DB.CategoryWork.ToList();
            ViewBag.workList = DB.MyWorksDiv.ToList();
            ViewBag.service = DB.ServicesDiv.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}