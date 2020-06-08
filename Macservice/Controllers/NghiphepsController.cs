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
    public class NghiphepsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Nghipheps
        public ActionResult Index()
        {
            var nghipheps = db.Nghipheps.Include(n => n.Thongtinnhansu);
            return View(nghipheps.ToList());
        }

        // GET: Nghipheps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghiphep nghiphep = db.Nghipheps.Find(id);
            if (nghiphep == null)
            {
                return HttpNotFound();
            }
            return View(nghiphep);
        }

        // GET: Nghipheps/Create
        public ActionResult Create()
        {
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Nghipheps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manghiphep,Manv,Ngaynghi,Thoigiannghi,Lydo,Nghicoluong,Nghỉkhongluong")] Nghiphep nghiphep)
        {
            if (ModelState.IsValid)
            {
                db.Nghipheps.Add(nghiphep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", nghiphep.Manv);
            return View(nghiphep);
        }

        // GET: Nghipheps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghiphep nghiphep = db.Nghipheps.Find(id);
            if (nghiphep == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", nghiphep.Manv);
            return View(nghiphep);
        }

        // POST: Nghipheps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manghiphep,Manv,Ngaynghi,Thoigiannghi,Lydo,Nghicoluong,Nghỉkhongluong")] Nghiphep nghiphep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nghiphep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", nghiphep.Manv);
            return View(nghiphep);
        }

        // GET: Nghipheps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghiphep nghiphep = db.Nghipheps.Find(id);
            if (nghiphep == null)
            {
                return HttpNotFound();
            }
            return View(nghiphep);
        }

        // POST: Nghipheps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nghiphep nghiphep = db.Nghipheps.Find(id);
            db.Nghipheps.Remove(nghiphep);
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
