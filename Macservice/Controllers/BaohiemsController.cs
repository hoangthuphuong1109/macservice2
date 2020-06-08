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
    public class BaohiemsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Baohiems
        public ActionResult Index(string tukhoa)
        {
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("bh", "").Replace("0", "");
            }

            return View(db.Baohiems.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Tenbaohiem.Contains(tukhoa) || m.Mabaohiem.ToString().Contains(tukhoa)).ToList());
        }

        // GET: Baohiems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baohiem baohiem = db.Baohiems.Find(id);
            if (baohiem == null)
            {
                return HttpNotFound();
            }
            return View(baohiem);
        }

        // GET: Baohiems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baohiems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mabaohiem,Tenbaohiem")] Baohiem baohiem)
        {
            if (ModelState.IsValid)
            {
                db.Baohiems.Add(baohiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baohiem);
        }

        // GET: Baohiems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baohiem baohiem = db.Baohiems.Find(id);
            if (baohiem == null)
            {
                return HttpNotFound();
            }
            return View(baohiem);
        }

        // POST: Baohiems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mabaohiem,Tenbaohiem")] Baohiem baohiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baohiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baohiem);
        }

        // GET: Baohiems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baohiem baohiem = db.Baohiems.Find(id);
            if (baohiem == null)
            {
                return HttpNotFound();
            }
            return View(baohiem);
        }

        // POST: Baohiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Baohiem baohiem = db.Baohiems.Find(id);
            db.Baohiems.Remove(baohiem);
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
