using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrBilgiSistemi.Models.EntitiyFramework;

namespace OgrBilgiSistemi.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DbMVCokulEntities db = new DbMVCokulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TblKulup.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TblKulup p2)
        {
            db.TblKulup.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TblKulup.Find(id);
            db.TblKulup.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup2 = db.TblKulup.Find(id);
            return View("KulupGetir",kulup2);
        }
        public ActionResult Guncelle(TblKulup p)
        {
            var klp = db.TblKulup.Find(p.KulupId);
            klp.KulupAd = p.KulupAd;
            klp.KulupKontenjan = p.KulupKontenjan;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulup");
        }
    }
}