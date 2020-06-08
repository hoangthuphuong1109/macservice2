using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice.Models;

namespace Macservice.Controllers
{
    public class BangchamcongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Bangchamcongs
        public ActionResult Index()
        {
            return View(db.Bangchamcongs.ToList());
        }

        // GET: Bangchamcongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            if (bangchamcong == null)
            {
                return HttpNotFound();
            }
            return View(bangchamcong);
        }

        // GET: Bangchamcongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bangchamcongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mabangcong,Thangchamcong,Nam")] Bangchamcong bangchamcong)
        {
            if (ModelState.IsValid)
            {
                db.Bangchamcongs.Add(bangchamcong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangchamcong);
        }

        // GET: Bangchamcongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            if (bangchamcong == null)
            {
                return HttpNotFound();
            }
            return View(bangchamcong);
        }

        // POST: Bangchamcongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mabangcong,Thangchamcong,Nam")] Bangchamcong bangchamcong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangchamcong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangchamcong);
        }

        // GET: Bangchamcongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            if (bangchamcong == null)
            {
                return HttpNotFound();
            }
            return View(bangchamcong);
        }

        // POST: Bangchamcongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bangchamcong bangchamcong = db.Bangchamcongs.Find(id);
            db.Bangchamcongs.Remove(bangchamcong);
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
