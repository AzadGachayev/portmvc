using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.Portfoliom.Controllers
{
    public class Section1DivController : Controller
    {
        private MyPortfolioDB db = new MyPortfolioDB();

        // GET: Portfoliom/Section1Div
        public ActionResult Index()
        {
            return View(db.Section1Div.ToList());
        }

        // GET: Portfoliom/Section1Div/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section1Div section1Div = db.Section1Div.Find(id);
            if (section1Div == null)
            {
                return HttpNotFound();
            }
            return View(section1Div);
        }

        // GET: Portfoliom/Section1Div/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfoliom/Section1Div/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Photo,Header,Title,Subtitle")] Section1Div section1Div)
        {
            if (ModelState.IsValid)
            {
                db.Section1Div.Add(section1Div);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(section1Div);
        }

        // GET: Portfoliom/Section1Div/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section1Div section1Div = db.Section1Div.Find(id);
            if (section1Div == null)
            {
                return HttpNotFound();
            }
            return View(section1Div);
        }

        // POST: Portfoliom/Section1Div/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Photo,Header,Title,Subtitle")] Section1Div section1Div)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section1Div).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(section1Div);
        }

        // GET: Portfoliom/Section1Div/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section1Div section1Div = db.Section1Div.Find(id);
            if (section1Div == null)
            {
                return HttpNotFound();
            }
            return View(section1Div);
        }

        // POST: Portfoliom/Section1Div/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section1Div section1Div = db.Section1Div.Find(id);
            db.Section1Div.Remove(section1Div);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
