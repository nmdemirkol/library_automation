using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _16330456Otomasyon.Models;
using System.IO;

namespace _16330456Otomasyon.Controllers
{
    public class KitapController : Controller
    {
        private kutuphaneEntities db = new kutuphaneEntities();

        // GET: Kitap
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                var kitaps = db.Kitaps.Include(k => k.Kategori).Include(k => k.Kullanici);
                return View(kitaps.ToList());
            }
        }

        // GET: Kitap/Details/5
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
                Kitap kitap = db.Kitaps.Find(id);
                if (kitap == null)
                {
                    return HttpNotFound();
                }
                return View(kitap);
            }
        }

        // GET: Kitap/Create
        public ActionResult Create()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "Kategori1");
                ViewBag.EkleyenKullaniciId = new SelectList(db.Kullanicis, "Id", "KullaniciAdi");
                return View();
            }
        }

        // POST: Kitap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KitapAdi,KitapYazar,KitapISBN,KategoriId,Aciklama,YayinTarihi,EklenmeTarihi,KitapAdert,EkleyenKullaniciId,Resim")] Kitap kitap, DosyaModel dosya)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string serverYol = Server.MapPath("~/Content/Resimler");//server yeri
                    string dosyaAdi = Path.GetFileName(dosya.Resim.FileName);//dosya adı
                    dosya.Resim.SaveAs(Path.Combine(serverYol, dosyaAdi));//birleştirerek kaydetmek
                    kitap.Resim = dosyaAdi;
                    db.Kitaps.Add(kitap);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "Kategori1", kitap.KategoriId);
            ViewBag.EkleyenKullaniciId = new SelectList(db.Kullanicis, "Id", "KullaniciAdi", kitap.EkleyenKullaniciId);
            return View(kitap);
        }

        // GET: Kitap/Edit/5
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
                Kitap kitap = db.Kitaps.Find(id);
                if (kitap == null)
                {
                    return HttpNotFound();
                }
                ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "Kategori1", kitap.KategoriId);
                ViewBag.EkleyenKullaniciId = new SelectList(db.Kullanicis, "Id", "KullaniciAdi", kitap.EkleyenKullaniciId);
                return View(kitap);
            }
        }

        // POST: Kitap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KitapAdi,KitapYazar,KitapISBN,KategoriId,Aciklama,YayinTarihi,EklenmeTarihi,KitapAdert,EkleyenKullaniciId,Resim")] Kitap kitap, DosyaModel dosya)
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            else
            {
                
                if (ModelState.IsValid)
                {
                    /*string serverYol = Server.MapPath("~/Content/Resimler");//server yeri
                    string dosyaAdi = Path.GetFileName(dosya.Resim.FileName);//dosya adı
                    dosya.Resim.SaveAs(Path.Combine(serverYol, dosyaAdi));//birleştirerek kaydetmek
                    kitap.Resim = dosyaAdi;*/

                    db.Entry(kitap).State = EntityState.Modified;
                    db.SaveChanges();
                   
                    return RedirectToAction("Index");
                }
                ViewBag.KategoriId = new SelectList(db.Kategoris, "Id", "Kategori1", kitap.KategoriId);
                ViewBag.EkleyenKullaniciId = new SelectList(db.Kullanicis, "Id", "KullaniciAdi", kitap.EkleyenKullaniciId);

                

                return View(kitap);

            }
        }

        // GET: Kitap/Delete/5
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
                Kitap kitap = db.Kitaps.Find(id);
                if (kitap == null)
                {
                    return HttpNotFound();
                }
                return View(kitap);
            }
        }

        // POST: Kitap/Delete/5
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
                Kitap kitap = db.Kitaps.Find(id);
                db.Kitaps.Remove(kitap);
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
