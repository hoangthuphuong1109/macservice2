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
    public class LoaihopdongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Loaihopdongs
        public ActionResult Index(string tukhoa)
        {
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("lhd", "").Replace("0", "");
            }

            return View(db.Loaihopdongs.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Tenloaihopdong.Contains(tukhoa) || m.Maloaihopdong.ToString().Contains(tukhoa)).ToList());
        }

        // GET: Loaihopdongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // GET: Loaihopdongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loaihopdongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloaihopdong,Tenloaihopdong")] Loaihopdong loaihopdong)
        {
            if (ModelState.IsValid)
            {
                db.Loaihopdongs.Add(loaihopdong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaihopdong);
        }

        // GET: Loaihopdongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // POST: Loaihopdongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloaihopdong,Tenloaihopdong")] Loaihopdong loaihopdong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaihopdong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaihopdong);
        }

        // GET: Loaihopdongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // POST: Loaihopdongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loaihopdong loaihopdong = db.Loaihopdongs.Find(id);
            db.Loaihopdongs.Remove(loaihopdong);
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
