using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrBilgiSistemi.Models.EntitiyFramework;
using OgrBilgiSistemi.Models;

namespace OgrBilgiSistemi.Controllers
{
    public class SinavController : Controller
    {
        // GET: Sinav
        DbMVCokulEntities db = new DbMVCokulEntities();
        public ActionResult Index()
        {
            var sinav = db.TblNotlar.ToList();
            return View(sinav);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TblNotlar p2)
        {
            db.TblNotlar.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.TblNotlar.Find(id);
            return View("NotGetir",notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(TblNotlar p,Class1 mdl, int sinav1=0,int sinav2=0,int sinav3=0, int proje=0)
        {
            if (mdl.islem == "Hesapla")
            {
                //İşlem1
                int ortlama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortlama;
            }
            if (mdl.islem == "Guncelle1")
            {
                //İşlem2
                var snv = db.TblNotlar.Find(p.NotId);
                snv.Sınav1 = p.Sınav1;
                snv.Sınav2 = p.Sınav2;
                snv.Sınav3 = p.Sınav3;
                snv.Proje = p.Proje;
                snv.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index", "Sinav");
            }
            return View();

            //var snv = db.TblNotlar.Find(p.NotId);
            //snv.DersId = p.DersId;
            //snv.OgrId = p.OgrId;
            //snv.Sınav1 = p.Sınav1;
            //snv.Sınav2 = p.Sınav2;
            //snv.Sınav3 = p.Sınav3;
            //snv.Proje = p.Proje;
            //snv.Ortalama = p.Ortalama;
            //snv.Durum = p.Durum;
            //db.SaveChanges();
            //return RedirectToAction("Index", "Sinav");
        }
    }
}