using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrBilgiSistemi.Models.EntitiyFramework;

namespace OgrBilgiSistemi.Controllers
{
    public class OgrController : Controller
    {
        // GET: Ogr
        DbMVCokulEntities db = new DbMVCokulEntities();
        public ActionResult Index()
        {
            var Ogrenciler = db.TblOgrenciler.ToList();
            return View(Ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgr()
        {
            List<SelectListItem> degerler = (from i in db.TblKulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgr(TblOgrenciler p2)
        {
            var klp = db.TblKulup.Where(m => m.KulupId == p2.TblKulup.KulupId).FirstOrDefault();
            p2.TblKulup = klp;
            db.TblOgrenciler.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogr = db.TblOgrenciler.Find(id);
            db.TblOgrenciler.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrGetir(int id)
        {
            var ogr = db.TblOgrenciler.Find(id);

            List<SelectListItem> degerler = (from i in db.TblKulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrGetir",ogr);
        }
        public ActionResult Guncelle(TblOgrenciler p)
        {
            var ogr = db.TblOgrenciler.Find(p.OgrId);
            ogr.OgrAd = p.OgrAd;
            ogr.OgrSoyad = p.OgrSoyad;
            ogr.OgrFotoğraf = p.OgrFotoğraf;
            ogr.OgrCinciyet = p.OgrCinciyet;
            ogr.OgrKulup = p.OgrKulup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogr");
        }
    }
}



//public ActionResult SelectCategory()
//{

//    List<SelectListItem> items = new List<SelectListItem>();

//    items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//    items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

//    items.Add(new SelectListItem { Text = "Coğrafya", Value = "2" });

//    items.Add(new SelectListItem { Text = "Edebiyat", Value = "3" });

//    ViewBag.DersAd = items;

//    return View();

//}