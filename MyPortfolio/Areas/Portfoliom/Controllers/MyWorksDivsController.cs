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
    public class MyWorksDivsController : Controller
    {
        private MyPortfolioDB db = new MyPortfolioDB();

        // GET: Portfoliom/MyWorksDivs
        public ActionResult Index()
        {
            var myWorksDiv = db.MyWorksDiv.Include(m => m.CategoryWork);
            return View(myWorksDiv.ToList());
        }

        // GET: Portfoliom/MyWorksDivs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyWorksDiv myWorksDiv = db.MyWorksDiv.Find(id);
            if (myWorksDiv == null)
            {
                return HttpNotFound();
            }
            return View(myWorksDiv);
        }

        // GET: Portfoliom/MyWorksDivs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CategoryWork, "ID", "Name");
            return View();
        }

        // POST: Portfoliom/MyWorksDivs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Photo,Title,CategoryID")] MyWorksDiv myWorksDiv)
        {
            if (ModelState.IsValid)
            {
                db.MyWorksDiv.Add(myWorksDiv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryWork, "ID", "Name", myWorksDiv.CategoryID);
            return View(myWorksDiv);
        }

        // GET: Portfoliom/MyWorksDivs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyWorksDiv myWorksDiv = db.MyWorksDiv.Find(id);
            if (myWorksDiv == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CategoryWork, "ID", "Name", myWorksDiv.CategoryID);
            return View(myWorksDiv);
        }

        // POST: Portfoliom/MyWorksDivs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Photo,Title,CategoryID")] MyWorksDiv myWorksDiv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myWorksDiv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CategoryWork, "ID", "Name", myWorksDiv.CategoryID);
            return View(myWorksDiv);
        }

        // GET: Portfoliom/MyWorksDivs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyWorksDiv myWorksDiv = db.MyWorksDiv.Find(id);
            if (myWorksDiv == null)
            {
                return HttpNotFound();
            }
            return View(myWorksDiv);
        }

        // POST: Portfoliom/MyWorksDivs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyWorksDiv myWorksDiv = db.MyWorksDiv.Find(id);
            db.MyWorksDiv.Remove(myWorksDiv);
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
