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
    public class KullaniciController : Controller
    {
        private kutuphaneEntities db = new kutuphaneEntities();

        // GET: Kullanici
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                return View(db.Kullanicis.ToList());
            }
        }

        // GET: Kullanici/Details/5
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
                Kullanici kullanici = db.Kullanicis.Find(id);
                if (kullanici == null)
                {
                    return HttpNotFound();
                }
                return View(kullanici);
            }
        }

        // GET: Kullanici/Create
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

        // POST: Kullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KullaniciAdi,Sifre")] Kullanici kullanici)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Kullanicis.Add(kullanici);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(kullanici);
            }
        }

        // GET: Kullanici/Edit/5
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
                Kullanici kullanici = db.Kullanicis.Find(id);
                if (kullanici == null)
                {
                    return HttpNotFound();
                }
                return View(kullanici);
            }
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KullaniciAdi,Sifre")] Kullanici kullanici)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(kullanici).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(kullanici);
            }
        }

        // GET: Kullanici/Delete/5
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
                Kullanici kullanici = db.Kullanicis.Find(id);
                if (kullanici == null)
                {
                    return HttpNotFound();
                }
                return View(kullanici);
            }
        }

        // POST: Kullanici/Delete/5
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
                Kullanici kullanici = db.Kullanicis.Find(id);
                db.Kullanicis.Remove(kullanici);
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
