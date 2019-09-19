using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Areas.Portfoliom.Controllers
{
    public class AdminAccountController : Controller
    {
        // GET: Portfoliom/AdminAccount
        private PortfolioDB db = new PortfolioDB();

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Settings Adm)
        {
            Settings selectAdmin = db.Settings.FirstOrDefault(slAdmin => slAdmin.Email == Adm.Email);

            if (ModelState.IsValid)
            {
                if ( selectAdmin != null)
                {
                    if(selectAdmin.Password == Adm.Password)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ViewBag.Error = "Şifrə düzgün deyil";

                    }
                }
                else
                {
                    ViewBag.Error = "Email düzgün deyil!";
                }
                
            }
            return View(selectAdmin);
        }
    }
}