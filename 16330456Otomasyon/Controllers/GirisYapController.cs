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
    public class GirisYapController : Controller
    {
        private kutuphaneEntities db = new kutuphaneEntities();

        // GET: GirisYap
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanici yonetici)
        {
            if (ModelState.IsValid)
            {
                var girisyap = db.Kullanicis.Where(a => a.KullaniciAdi == yonetici.KullaniciAdi && a.Sifre == yonetici.Sifre).FirstOrDefault();
                if (girisyap != null)
                {
                    Session["KullaniciId"] = girisyap.Id;
                    Session["KullaniciAdi"] = girisyap.KullaniciAdi;
                    return RedirectToAction("Index","Anasayfa");
                }
                else
                {
                    ViewBag.GirisHata = "Hatalı Giriş";
                    return View();
                }
            }
            return View();
        }
        public ActionResult CikisYap()
        {
            Session["KullaniciId"] = null;
            Session["KullaniciAdi"] = null;
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
