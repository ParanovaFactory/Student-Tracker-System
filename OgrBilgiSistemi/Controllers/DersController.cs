using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrBilgiSistemi.Models.EntitiyFramework;

namespace OgrBilgiSistemi.Controllers
{
    public class DersController : Controller
    {
        // GET: Default
        DbMVCokulEntities db = new DbMVCokulEntities();
        public ActionResult Index()
        {
            var dersler = db.tblDers.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(tblDers p)
        {
            db.tblDers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ders = db.tblDers.Find(id);
            db.tblDers.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var drs = db.tblDers.Find(id);
            return View("DersGetir", drs);          
        }
        public ActionResult Guncelle(tblDers p)
        {
            var drs = db.tblDers.Find(p.DersId);
            drs.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Ders");
        }
    }
}