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
    public class ServicesDivsController : Controller
    {
        private PortfolioDB db = new PortfolioDB();

        // GET: Portfoliom/ServicesDivs
        public ActionResult Index()
        {
            return View(db.ServicesDiv.ToList());
        }

        // GET: Portfoliom/ServicesDivs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesDiv servicesDiv = db.ServicesDiv.Find(id);
            if (servicesDiv == null)
            {
                return HttpNotFound();
            }
            return View(servicesDiv);
        }

        // GET: Portfoliom/ServicesDivs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfoliom/ServicesDivs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Icons,Header,Description")] ServicesDiv servicesDiv)
        {
            if (ModelState.IsValid)
            {
                db.ServicesDiv.Add(servicesDiv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicesDiv);
        }

        // GET: Portfoliom/ServicesDivs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesDiv servicesDiv = db.ServicesDiv.Find(id);
            if (servicesDiv == null)
            {
                return HttpNotFound();
            }
            return View(servicesDiv);
        }

        // POST: Portfoliom/ServicesDivs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Icons,Header,Description")] ServicesDiv servicesDiv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicesDiv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicesDiv);
        }

        // GET: Portfoliom/ServicesDivs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesDiv servicesDiv = db.ServicesDiv.Find(id);
            if (servicesDiv == null)
            {
                return HttpNotFound();
            }
            return View(servicesDiv);
        }

        // POST: Portfoliom/ServicesDivs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicesDiv servicesDiv = db.ServicesDiv.Find(id);
            db.ServicesDiv.Remove(servicesDiv);
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
