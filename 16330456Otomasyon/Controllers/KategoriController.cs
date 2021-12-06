using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _16330456Otomasyon.Models;

namespace _16330456Otomasyon.Controllers
{
    public class KategoriController : Controller
    {
        private kutuphaneEntities db = new kutuphaneEntities();

        // GET: Kategori
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                return View(db.Kategoris.ToList());
            }
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Kategori kategori = db.Kategoris.Find(id);
                if (kategori == null)
                {
                    return HttpNotFound();
                }
                return View(kategori);
            }
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                return View();
            }
        }

        // POST: Kategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kategori1")] Kategori kategori)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Kategoris.Add(kategori);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(kategori);
            }
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Kategori kategori = db.Kategoris.Find(id);
                if (kategori == null)
                {
                    return HttpNotFound();
                }
                return View(kategori);
            }
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kategori1")] Kategori kategori)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(kategori).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(kategori);
            }
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Kategori kategori = db.Kategoris.Find(id);
                if (kategori == null)
                {
                    return HttpNotFound();
                }
                return View(kategori);
            }
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                Kategori kategori = db.Kategoris.Find(id);
                db.Kategoris.Remove(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
