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
    public class ChitietbangcongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chitietbangcongs
        public ActionResult Index()
        {
            var chitietbangcongs = db.Chitietbangcongs.Include(c => c.Bangchamcong).Include(c => c.Phongban).Include(c => c.Thongtinnhansu);
            return View(chitietbangcongs.ToList());
        }

        // GET: Chitietbangcongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            return View(chitietbangcong);
        }

        // GET: Chitietbangcongs/Create
        public ActionResult Create()
        {
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Mabangcong");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Chitietbangcongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietbangcong,Manv,Mabangcong,Sogiolam,Sogiolamthemngayhtuong,Sogiolamthemngaynghi,Sogiolamthemngayle,Songaynghiphep,Maphongban")] Chitietbangcong chitietbangcong)
        {
            if (ModelState.IsValid)
            {
                db.Chitietbangcongs.Add(chitietbangcong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Mabangcong", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // GET: Chitietbangcongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Mabangcong", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // POST: Chitietbangcongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietbangcong,Manv,Mabangcong,Sogiolam,Sogiolamthemngayhtuong,Sogiolamthemngaynghi,Sogiolamthemngayle,Songaynghiphep,Maphongban")] Chitietbangcong chitietbangcong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietbangcong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mabangcong = new SelectList(db.Bangchamcongs, "Mabangcong", "Mabangcong", chitietbangcong.Mabangcong);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", chitietbangcong.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbangcong.Manv);
            return View(chitietbangcong);
        }

        // GET: Chitietbangcongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            if (chitietbangcong == null)
            {
                return HttpNotFound();
            }
            return View(chitietbangcong);
        }

        // POST: Chitietbangcongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietbangcong chitietbangcong = db.Chitietbangcongs.Find(id);
            db.Chitietbangcongs.Remove(chitietbangcong);
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
