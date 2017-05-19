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
    [Authorize]
    public class MakaleController : Controller
    {
        // GET: Makale
        KisiselBlogEntities db = new KisiselBlogEntities();
        public ActionResult ChangeCulture(String lang)
        {
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult TariheGoreListele(int yil, int ay)
        {
            ViewBag.yil = yil;
            ViewBag.ay = ay;
            return View();
        }
        [AllowAnonymous]
        public ActionResult MakaleListele(int yil = 0, int ay = 0)
        {
            var data = db.Makale.Where(x => x.YayimTarihi.Year == yil && x.YayimTarihi.Month == ay);
            return View("MakaleListele", data);
        }
        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            ViewBag.Kullanici = Session["Kullanici"];
            Makale makale = db.Makale.FirstOrDefault(x => x.Id == id);
            return View(makale);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult YorumYaz(Yorum yorum)
        {
            yorum.EklenmeTarihi = DateTime.Now;
            yorum.Baslik = "";
            yorum.Aktif = false;
            db.Yorum.Add(yorum);
            db.SaveChanges();
            return RedirectToAction("Detay", new { id = yorum.MakaleID });
        }
        public ActionResult Makaleyaz()
        {
            //ViewBag.Tip = 1;
            ViewBag.Kategoriler = db.Kategori.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult MakaleYaz(Makale makale, HttpPostedFileBase Resim, string etiketler)
        {
            if (makale != null)
            {
                if (etiketler == "")
                {
                    ViewBag.Mesaj = Resources.HomeLan.EtiketAlan;
                    ViewBag.Tip = 1;
                    ViewBag.Kategoriler = db.Kategori.ToList();
                    return View();
                }
                Kullanici aktif = Session["Kullanici"] as Kullanici;
                makale.YayimTarihi = DateTime.Now;
                makale.MakaleTipID = 1;
                //makale.YazarID = aktif.Id;
                //makale.KapakResimID = ResimKaydet(Resim, HttpContext);
                db.Makale.Add(makale);
                db.SaveChanges();

                string[] etikets = etiketler.Split(',');
                foreach (string etiket in etikets)
                {
                    Etiket etk = db.Etiket.FirstOrDefault(x => x.Adi.ToLower() == etiket.ToLower().Trim());
                    if (etk == null)
                    {
                        etk = new Etiket();
                        etk.Adi = etiket;
                        db.Etiket.Add(etk);
                        db.SaveChanges();
                    }
                    makale.Etiket.Add(etk);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}