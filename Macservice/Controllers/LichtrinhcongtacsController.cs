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
    public class LichtrinhcongtacsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Lichtrinhcongtacs
        public ActionResult Index()
        {
            var lichtrinhcongtacs = db.Lichtrinhcongtacs.Include(l => l.Chucvu).Include(l => l.Phongban).Include(l => l.Thongtinnhansu).Include(l => l.Trinhdo_chuyenmon);
            return View(lichtrinhcongtacs.ToList());
        }

        // GET: Lichtrinhcongtacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lichtrinhcongtac lichtrinhcongtac = db.Lichtrinhcongtacs.Find(id);
            if (lichtrinhcongtac == null)
            {
                return HttpNotFound();
            }
            return View(lichtrinhcongtac);
        }

        // GET: Lichtrinhcongtacs/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon");
            return View();
        }

        // POST: Lichtrinhcongtacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Malichtrinhcongtac,Manv,Maphongban,Machucvu,Matrinhdochuyenmon,Tungay,Denngay,Noicongtac,Noidungcongtac,Trocap")] Lichtrinhcongtac lichtrinhcongtac)
        {
            if (ModelState.IsValid)
            {
                db.Lichtrinhcongtacs.Add(lichtrinhcongtac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", lichtrinhcongtac.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", lichtrinhcongtac.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", lichtrinhcongtac.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", lichtrinhcongtac.Matrinhdochuyenmon);
            return View(lichtrinhcongtac);
        }

        // GET: Lichtrinhcongtacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lichtrinhcongtac lichtrinhcongtac = db.Lichtrinhcongtacs.Find(id);
            if (lichtrinhcongtac == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", lichtrinhcongtac.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", lichtrinhcongtac.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", lichtrinhcongtac.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", lichtrinhcongtac.Matrinhdochuyenmon);
            return View(lichtrinhcongtac);
        }

        // POST: Lichtrinhcongtacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Malichtrinhcongtac,Manv,Maphongban,Machucvu,Matrinhdochuyenmon,Tungay,Denngay,Noicongtac,Noidungcongtac,Trocap")] Lichtrinhcongtac lichtrinhcongtac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichtrinhcongtac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", lichtrinhcongtac.Machucvu);
            ViewBag.Maphongban = new SelectList(db.Phongbans, "Maphongban", "Tenphongban", lichtrinhcongtac.Maphongban);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", lichtrinhcongtac.Manv);
            ViewBag.Matrinhdochuyenmon = new SelectList(db.Trinhdo_chuyenmon, "Matrinhdochuyenmon", "Tentrinhdochuyenmon", lichtrinhcongtac.Matrinhdochuyenmon);
            return View(lichtrinhcongtac);
        }

        // GET: Lichtrinhcongtacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lichtrinhcongtac lichtrinhcongtac = db.Lichtrinhcongtacs.Find(id);
            if (lichtrinhcongtac == null)
            {
                return HttpNotFound();
            }
            return View(lichtrinhcongtac);
        }

        // POST: Lichtrinhcongtacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lichtrinhcongtac lichtrinhcongtac = db.Lichtrinhcongtacs.Find(id);
            db.Lichtrinhcongtacs.Remove(lichtrinhcongtac);
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
