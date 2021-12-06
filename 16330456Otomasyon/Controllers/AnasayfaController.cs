using _16330456Otomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _16330456Otomasyon.Controllers
{
    
    public class AnasayfaController : Controller
    {
        private kutuphaneEntities db = new kutuphaneEntities();
        // GET: Anasayfa
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null) {
                return RedirectToAction("Index", "GirisYap");
            }
            else {
                
                return View(db.Kitaps.ToList());
            }
        }
    }
}