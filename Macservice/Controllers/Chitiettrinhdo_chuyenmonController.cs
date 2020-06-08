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
    public class Chitiettrinhdo_chuyenmonController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chitiettrinhdo_chuyenmon
        public ActionResult Index()
        {
            var chitiettrinhdo_chuyenmon = db.Chitiettrinhdo_chuyenmon.Include(c => c.Thongtinnhansu).Include(c => c.Trinhdo_chuyenmon);
            return View(chitiettrinhdo_chuyenmon.ToList());
        }

        // GET: Chitiettrinhdo_chuyenmon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiettrinhdo_chuyenmon chitiettrinhdo_chuyenmon = db.Chitiettrinhdo_chuyenmon.Find(id);
            if (chitiettrinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(chitiettrinhdo_chuyenmon);
        }

        // GET: Chitiettrinhdo_chuyenmon/Create
        public ActionResult Create()
        {
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon");
            return View();
        }

        // POST: Chitiettrinhdo_chuyenmon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitiettrinhdo_chuyenmon,Manv,Matrinhdochuyenmon,Tungay,Denngay")] Chitiettrinhdo_chuyenmon chitiettrinhdo_chuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Chitiettrinhdo_chuyenmon.Add(chitiettrinhdo_chuyenmon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitiettrinhdo_chuyenmon.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", chitiettrinhdo_chuyenmon.Matrinhdochuyenmon);
            return View(chitiettrinhdo_chuyenmon);
        }

        // GET: Chitiettrinhdo_chuyenmon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiettrinhdo_chuyenmon chitiettrinhdo_chuyenmon = db.Chitiettrinhdo_chuyenmon.Find(id);
            if (chitiettrinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitiettrinhdo_chuyenmon.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", chitiettrinhdo_chuyenmon.Matrinhdochuyenmon);
            return View(chitiettrinhdo_chuyenmon);
        }

        // POST: Chitiettrinhdo_chuyenmon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitiettrinhdo_chuyenmon,Manv,Matrinhdochuyenmon,Tungay,Denngay")] Chitiettrinhdo_chuyenmon chitiettrinhdo_chuyenmon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiettrinhdo_chuyenmon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitiettrinhdo_chuyenmon.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", chitiettrinhdo_chuyenmon.Matrinhdochuyenmon);
            return View(chitiettrinhdo_chuyenmon);
        }

        // GET: Chitiettrinhdo_chuyenmon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitiettrinhdo_chuyenmon chitiettrinhdo_chuyenmon = db.Chitiettrinhdo_chuyenmon.Find(id);
            if (chitiettrinhdo_chuyenmon == null)
            {
                return HttpNotFound();
            }
            return View(chitiettrinhdo_chuyenmon);
        }

        // POST: Chitiettrinhdo_chuyenmon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitiettrinhdo_chuyenmon chitiettrinhdo_chuyenmon = db.Chitiettrinhdo_chuyenmon.Find(id);
            db.Chitiettrinhdo_chuyenmon.Remove(chitiettrinhdo_chuyenmon);
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
