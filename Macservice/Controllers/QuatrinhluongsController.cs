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
    public class QuatrinhluongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Quatrinhluongs
        public ActionResult Index()
        {
            var quatrinhluongs = db.Quatrinhluongs.Include(q => q.Chucvu).Include(q => q.Phongban).Include(q => q.Thongtinnhansu);
            return View(quatrinhluongs.ToList());
        }

        // GET: Quatrinhluongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            if (quatrinhluong == null)
            {
                return HttpNotFound();
            }
            return View(quatrinhluong);
        }

        // GET: Quatrinhluongs/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Quatrinhluongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maquatrinhluong,Manv,Maphongban,Machucvu,Thoigian,Luongcoban,Trocapchucvu,Phucapkhac,Noidung,Luongdoanhso")] Quatrinhluong quatrinhluong)
        {
            if (ModelState.IsValid)
            {
                db.Quatrinhluongs.Add(quatrinhluong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", quatrinhluong.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", quatrinhluong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", quatrinhluong.Manv);
            return View(quatrinhluong);
        }

        // GET: Quatrinhluongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            if (quatrinhluong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", quatrinhluong.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", quatrinhluong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", quatrinhluong.Manv);
            return View(quatrinhluong);
        }

        // POST: Quatrinhluongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maquatrinhluong,Manv,Maphongban,Machucvu,Thoigian,Luongcoban,Trocapchucvu,Phucapkhac,Noidung,Luongdoanhso")] Quatrinhluong quatrinhluong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quatrinhluong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", quatrinhluong.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", quatrinhluong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", quatrinhluong.Manv);
            return View(quatrinhluong);
        }

        // GET: Quatrinhluongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            if (quatrinhluong == null)
            {
                return HttpNotFound();
            }
            return View(quatrinhluong);
        }

        // POST: Quatrinhluongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quatrinhluong quatrinhluong = db.Quatrinhluongs.Find(id);
            db.Quatrinhluongs.Remove(quatrinhluong);
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
