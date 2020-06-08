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
    public class KyluatsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Kyluats
        public ActionResult Index(string tukhoa)
        {
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("kl", "").Replace("0", "");
            }
            return View(db.Kyluats.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Tenkyluat.Contains(tukhoa) || m.Noidung.Contains(tukhoa) || m.Quyetdinh.Contains(tukhoa) || m.Makyluat.ToString().Contains(tukhoa)).ToList());
        }

        // GET: Kyluats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kyluat kyluat = db.Kyluats.Find(id);
            if (kyluat == null)
            {
                return HttpNotFound();
            }
            return View(kyluat);
        }

        // GET: Kyluats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kyluats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Makyluat,Tenkyluat,Noidung,Quyetdinh")] Kyluat kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Kyluats.Add(kyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kyluat);
        }

        // GET: Kyluats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kyluat kyluat = db.Kyluats.Find(id);
            if (kyluat == null)
            {
                return HttpNotFound();
            }
            return View(kyluat);
        }

        // POST: Kyluats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Makyluat,Tenkyluat,Noidung,Quyetdinh")] Kyluat kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kyluat);
        }

        // GET: Kyluats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kyluat kyluat = db.Kyluats.Find(id);
            if (kyluat == null)
            {
                return HttpNotFound();
            }
            return View(kyluat);
        }

        // POST: Kyluats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kyluat kyluat = db.Kyluats.Find(id);
            db.Kyluats.Remove(kyluat);
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
