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
        PortfolioDB DB = new PortfolioDB();
        public ActionResult Index()
        {
            ViewBag.Section1 = DB.Section1Div.Find(1);
            ViewBag.workCat = DB.CategoryWork.ToList();
            ViewBag.workList = DB.MyWorksDiv.ToList();
            ViewBag.service = DB.ServicesDiv.ToList();
            ViewBag.about = DB.AboutItems.ToList();
            ViewBag.aboutDv = DB.AboutDiv.Find(1);
            ViewBag.testimonial = DB.Testimony.ToList();
            ViewBag.blog = DB.Blogs.ToList();
            return View();
        }
       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}