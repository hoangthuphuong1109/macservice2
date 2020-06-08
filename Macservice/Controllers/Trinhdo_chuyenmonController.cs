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
    public class Trinhdo_chuyenmonController : Controller
    {
        private Model1 db = new Model1();

        // GET: Trinhdo_chuyenmon
        public ActionResult Index(string tukhoa)
        {
            ViewBag.Tukhoa = tukhoa;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("tdcm", "").Replace("0", "");
            }
            return View(db.Trinhdo_chuyenmon.Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Tentrinhdochuyenmon.Contains(tukhoa) || m.Matrinhdochuyenmon.ToString().Contains(tukhoa)).ToList());
        }

        // GET: Trinhdo_chuyenmon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            if (trinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(trinhdo_chuyenmon);
        }

        // GET: Trinhdo_chuyenmon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trinhdo_chuyenmon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matrinhdochuyenmon,Tentrinhdochuyenmon")] Trinhdo_chuyenmon trinhdo_chuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Trinhdo_chuyenmon.Add(trinhdo_chuyenmon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trinhdo_chuyenmon);
        }

        // GET: Trinhdo_chuyenmon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            if (trinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(trinhdo_chuyenmon);
        }

        // POST: Trinhdo_chuyenmon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matrinhdochuyenmon,Tentrinhdochuyenmon")] Trinhdo_chuyenmon trinhdo_chuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trinhdo_chuyenmon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trinhdo_chuyenmon);
        }

        // GET: Trinhdo_chuyenmon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            if (trinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(trinhdo_chuyenmon);
        }

        // POST: Trinhdo_chuyenmon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trinhdo_chuyenmon trinhdo_chuyenmon = db.Trinhdo_chuyenmon.Find(id);
            db.Trinhdo_chuyenmon.Remove(trinhdo_chuyenmon);
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
