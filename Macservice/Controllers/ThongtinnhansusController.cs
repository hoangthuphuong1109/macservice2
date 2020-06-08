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
    public class ThongtinnhansusController : Controller
    {
        private Model1 db = new Model1();
        // GET: Thongtinnhansus
        public ActionResult Index()
        {
            var thongtinnhansus = db.Thongtinnhansus.Include(t => t.Chucvu).Include(t => t.Phongban).Include(t => t.Trinhdo_chuyenmon);
            return View(thongtinnhansus.ToList());
        }

        // GET: Thongtinnhansus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            if (thongtinnhansu == null)
            {
                return HttpNotFound();
            }
            return View(thongtinnhansu);
        }

        // GET: Thongtinnhansus/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon");
            return View();
        }

        // POST: Thongtinnhansus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manv,Hoten,Ngaysinh,SDT,Gioitinh,Email,Dantoc,Noisinh,Hokhauthuongtru,Noiohientai,CMND,Noicap,Ngaycap,Maphongban,Machucvu,Matrinhdochuyenmon")] Thongtinnhansu thongtinnhansu)
        {
            if (ModelState.IsValid)
            {
                db.Thongtinnhansus.Add(thongtinnhansu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", thongtinnhansu.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", thongtinnhansu.Maphongban);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", thongtinnhansu.Matrinhdochuyenmon);
            return View(thongtinnhansu);
        }

        // GET: Thongtinnhansus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            if (thongtinnhansu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", thongtinnhansu.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", thongtinnhansu.Maphongban);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", thongtinnhansu.Matrinhdochuyenmon);
            return View(thongtinnhansu);
        }

        // POST: Thongtinnhansus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manv,Hoten,Ngaysinh,SDT,Gioitinh,Email,Dantoc,Noisinh,Hokhauthuongtru,Noiohientai,CMND,Noicap,Ngaycap,Maphongban,Machucvu,Matrinhdochuyenmon")] Thongtinnhansu thongtinnhansu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtinnhansu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", thongtinnhansu.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", thongtinnhansu.Maphongban);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", thongtinnhansu.Matrinhdochuyenmon);
            return View(thongtinnhansu);
        }

        // GET: Thongtinnhansus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            if (thongtinnhansu == null)
            {
                return HttpNotFound();
            }
            return View(thongtinnhansu);
        }

        // POST: Thongtinnhansus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thongtinnhansu thongtinnhansu = db.Thongtinnhansus.Find(id);
            db.Thongtinnhansus.Remove(thongtinnhansu);
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
