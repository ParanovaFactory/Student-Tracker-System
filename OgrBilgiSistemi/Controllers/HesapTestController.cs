using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrBilgiSistemi.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int sayi1 = 0, int sayi2 = 0, int sayi3 = 0, int sayi4 = 0)
        {
            int ortalama = (sayi1 + sayi2 + sayi3 + sayi4) / 4;
            ViewBag.ort = ortalama;
            return View();
        }
    }
}