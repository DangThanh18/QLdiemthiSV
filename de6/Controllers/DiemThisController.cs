using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using de6.Models;
using PagedList;

namespace de6.Controllers
{
    public class DiemThisController : Controller
    {
        private Entities db = new Entities();

        // GET: DiemThis
        public ActionResult Index(int? page)
        {
            if(page == null)
            {
                page = 1;
            }
            var diemThis = db.DiemThis.Include(d => d.SinhVien).OrderBy(u => u.MaSV);

            int pagasize = 2;
            int pagenumber = (page ?? 1);
            return View(diemThis.ToPagedList(pagenumber, pagasize));
        }

        // GET: DiemThis/Details/5
        public ActionResult Details(int? id, string key)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemThi diemThi = db.DiemThis.FirstOrDefault(u => u.MaSV == id && u.TenMT == key);
            if (diemThi == null)
            {
                return HttpNotFound();
            }
            return View(diemThi);
        }

        // GET: DiemThis/Create
        public ActionResult Create()
        {
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV");
            return View();
        }

        // POST: DiemThis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,TenMT,SoTC,NgayThi,Diem")] DiemThi diemThi)
        {
            if (ModelState.IsValid)
            {
                db.DiemThis.Add(diemThi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diemThi.MaSV);
            return View(diemThi);
        }

        // GET: DiemThis/Edit/5
        public ActionResult Edit(int? id, string key)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemThi diemThi = db.DiemThis.FirstOrDefault(u => u.MaSV == id && u.TenMT == key);
            if (diemThi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diemThi.MaSV);
            return View(diemThi);
        }

        // POST: DiemThis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,TenMT,SoTC,NgayThi,Diem")] DiemThi diemThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diemThi.MaSV);
            return View(diemThi);
        }

        // GET: DiemThis/Delete/5
        public ActionResult Delete(int? id, string key)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemThi diemThi = db.DiemThis.FirstOrDefault(u => u.MaSV == id && u.TenMT == key);
            if (diemThi == null)
            {
                return HttpNotFound();
            }
            return View(diemThi);
        }

        // POST: DiemThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id, string key)
        {
            DiemThi diemThi = db.DiemThis.FirstOrDefault(u => u.MaSV == id && u.TenMT == key);
            db.DiemThis.Remove(diemThi);
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

        public ActionResult TKtheoTenMT(string search)
        {
            var diemThis = db.DiemThis.Include(d => d.SinhVien).Where(u => u.TenMT.Contains(search));
            return View(diemThis.ToList());
        }

        public ActionResult DiemthiWordMax()
        {
            var diemThis = db.DiemThis.Include(d => d.SinhVien).Where(u => u.TenMT == "Word").OrderByDescending(u => u.Diem).Take(1);
            return View(diemThis.ToList());
        }
    }
}
