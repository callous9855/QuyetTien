using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuyetTien1.Models;

namespace QuyetTien1.Controllers
{
    public class BangSanPhamsController : Controller
    {
        private CS4PEEntities db = new CS4PEEntities();

        // GET: BangSanPhams
        public ActionResult Index()
        {
            var bangSanPhams = db.BangSanPhams.Include(b => b.LoaiSanPham);
            return View(bangSanPhams.ToList());
        }

        // GET: BangSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangSanPham bangSanPham = db.BangSanPhams.Find(id);
            if (bangSanPham == null)
            {
                return HttpNotFound();
            }
            return View(bangSanPham);
        }

        // GET: BangSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.Loai_id = new SelectList(db.LoaiSanPhams, "id", "TenLoai");
            return View();
        }

        // POST: BangSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MaSP,TenSP,Loai_id,GiaBan,GiaGoc,GiaGop,SoLuongTon")] BangSanPham bangSanPham)
        {
            if (ModelState.IsValid)
            {
                db.BangSanPhams.Add(bangSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Loai_id = new SelectList(db.LoaiSanPhams, "id", "TenLoai", bangSanPham.Loai_id);
            return View(bangSanPham);
        }

        // GET: BangSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangSanPham bangSanPham = db.BangSanPhams.Find(id);
            if (bangSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Loai_id = new SelectList(db.LoaiSanPhams, "id", "TenLoai", bangSanPham.Loai_id);
            return View(bangSanPham);
        }

        // POST: BangSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MaSP,TenSP,Loai_id,GiaBan,GiaGoc,GiaGop,SoLuongTon")] BangSanPham bangSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Loai_id = new SelectList(db.LoaiSanPhams, "id", "TenLoai", bangSanPham.Loai_id);
            return View(bangSanPham);
        }

        // GET: BangSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangSanPham bangSanPham = db.BangSanPhams.Find(id);
            if (bangSanPham == null)
            {
                return HttpNotFound();
            }
            return View(bangSanPham);
        }

        // POST: BangSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangSanPham bangSanPham = db.BangSanPhams.Find(id);
            db.BangSanPhams.Remove(bangSanPham);
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
