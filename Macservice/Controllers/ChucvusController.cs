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
    public class ChucvusController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chucvus
        public ActionResult Index(string tukhoa)
        {
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("cv", "").Replace("0", "");
            }

            return View(db.Chucvus.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Tenchucvu.Contains(tukhoa) || m.Machucvu.ToString().Contains(tukhoa)).ToList());
        }

        // GET: Chucvus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu chucvu = db.Chucvus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // GET: Chucvus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chucvus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machucvu,Tenchucvu")] Chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.Chucvus.Add(chucvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucvu);
        }

        // GET: Chucvus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu chucvu = db.Chucvus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // POST: Chucvus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machucvu,Tenchucvu")] Chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucvu);
        }

        // GET: Chucvus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chucvu chucvu = db.Chucvus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // POST: Chucvus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chucvu chucvu = db.Chucvus.Find(id);
            db.Chucvus.Remove(chucvu);
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
