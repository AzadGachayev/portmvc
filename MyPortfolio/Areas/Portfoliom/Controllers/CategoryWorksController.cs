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
    public class CategoryWorksController : Controller
    {
        private MyPortfolioDB db = new MyPortfolioDB();

        // GET: Portfoliom/CategoryWorks
        public ActionResult Index()
        {
            return View(db.CategoryWork.ToList());
        }

        // GET: Portfoliom/CategoryWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryWork categoryWork = db.CategoryWork.Find(id);
            if (categoryWork == null)
            {
                return HttpNotFound();
            }
            return View(categoryWork);
        }

        // GET: Portfoliom/CategoryWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfoliom/CategoryWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] CategoryWork categoryWork)
        {
            if (ModelState.IsValid)
            {
                db.CategoryWork.Add(categoryWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryWork);
        }

        // GET: Portfoliom/CategoryWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryWork categoryWork = db.CategoryWork.Find(id);
            if (categoryWork == null)
            {
                return HttpNotFound();
            }
            return View(categoryWork);
        }

        // POST: Portfoliom/CategoryWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] CategoryWork categoryWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryWork);
        }

        // GET: Portfoliom/CategoryWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryWork categoryWork = db.CategoryWork.Find(id);
            if (categoryWork == null)
            {
                return HttpNotFound();
            }
            return View(categoryWork);
        }

        // POST: Portfoliom/CategoryWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryWork categoryWork = db.CategoryWork.Find(id);
            db.CategoryWork.Remove(categoryWork);
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
