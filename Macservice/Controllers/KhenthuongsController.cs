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
    public class KhenthuongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Khenthuongs
        public ActionResult Index(string tukhoa)
        {
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("kt", "").Replace("0", "");
            }
            return View(db.Khenthuongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Tenkhenthuong.Contains(tukhoa) || m.Noidung.Contains(tukhoa) || m.Quyetdinh.Contains(tukhoa) || m.Makhenthuong.ToString().Contains(tukhoa)).ToList());
        }

        // GET: Khenthuongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            if (khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(khenthuong);
        }

        // GET: Khenthuongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khenthuongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Makhenthuong,Tenkhenthuong,Noidung,Quyetdinh")] Khenthuong khenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Khenthuongs.Add(khenthuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khenthuong);
        }

        // GET: Khenthuongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            if (khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(khenthuong);
        }

        // POST: Khenthuongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Makhenthuong,Tenkhenthuong,Noidung,Quyetdinh")] Khenthuong khenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khenthuong);
        }

        // GET: Khenthuongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            if (khenthuong == null)
            {
                return HttpNotFound();
            }
            return View(khenthuong);
        }

        // POST: Khenthuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khenthuong khenthuong = db.Khenthuongs.Find(id);
            db.Khenthuongs.Remove(khenthuong);
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
