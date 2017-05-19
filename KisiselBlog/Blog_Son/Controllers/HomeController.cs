using Blog_Son.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Blog_Son.Controllers
{
    public class HomeController : Controller
    {
        KisiselBlogEntities db = new KisiselBlogEntities();
        public ActionResult ChangeCulture(String lang)
        {
            if(lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            return View("Index");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryWidget()
        {
            return View(db.Kategori);
        }
        public ActionResult RecentWidget()
        {
            ViewBag.Fresh = db.Makale.OrderByDescending(x => x.YayimTarihi).Take(5);
            return View();
        }
        public ActionResult PopulerWidget()
        {
            ViewBag.Populer = db.Makale.OrderByDescending(x => x.Goruntulenme).Take(5);
            return View();
        }
        public ActionResult Etiket()
        {
            var etiket = db.Etiket.ToList();
            return View(etiket);
        }
        public ActionResult TumMakaleler()
        {
            var makaleler = db.Makale.ToList();
            return View("MakaleListele", makaleler);
        }
        public ActionResult Hakkimda()
        {
            return View();
        }
        public ActionResult Reklam()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
       
    }
}