using Blog_Son.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Son.Controllers
{
    using Models;
    using System.Globalization;
    using System.Threading;

    [Authorize(Roles = "Admin")]
    public class YonetimController : Controller
    {
        // GET: Yonetim
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
            return View("Index");
        }
        public ActionResult Index()
        {
            //ViewBag.Tip = 1;
            return View(db.Makale.ToList());
        }

        public ActionResult Kategori()
        {
            //ViewBag.Tip = 1;
            return View(db.Kategori.ToList());
        }
        public ActionResult KategoriEkle()
        {
            //ViewBag.Tip = 1;
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            db.Kategori.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }
        public ActionResult KategoriDuzenle(int id)
        {
            //ViewBag.Tip = 1;
            return View(db.Kategori.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori kategori)
        {
            db.Entry(kategori).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriSil(int id)
        {
            try
            {
                db.Kategori.Remove(db.Kategori.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Hata");
            }
            return RedirectToAction("Kategori");
        }
        public ActionResult Hata()
        {
            return View();
        }
        public ActionResult EtiketListele()
        {
            var data = db.Etiket.ToList();
            return View(data);
        }
        public ActionResult EtiketSil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EtiketSil(int id)
        {
            try
            {
                Etiket etiket = db.Etiket.Find(id);
                db.Etiket.Remove(etiket);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Hata");
            }
            return RedirectToAction("EtiketListele");
        }
        public ActionResult TumMakaleler()
        {
            var data = db.Makale.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult MakaleSil(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("TumMakaleler", "Yonetim");
            }
            Makale makale = db.Makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakaleSil(int id)
        {
            try
            {
                Makale makale = db.Makale.Find(id);
                db.Makale.Remove(makale);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Hata");
            }
            return RedirectToAction("TumMakaleler", "Yonetim");
        }
        //public static int ResimKaydet(HttpPostedFileBase resim, HttpContextBase ctx)
        //{
        //    KisiselBlogEntities db = new KisiselBlogEntities();

        //    int kucukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["kw"]);
        //    int kucukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["kh"]);
        //    int ortaWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ow"]);
        //    int ortaHeight = Convert.ToInt32(ConfigurationManager.AppSettings["oh"]);
        //    int buyukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
        //    int buyukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);

        //    string newName = Path.GetFileNameWithoutExtension((string)Resim.FileName) + "-" + Guid.NewGuid() + Path.GetExtension((string)(Resim.FileName));

        //    Image orjRes = Image.FromStream((Stream)Resim.InputStream);
        //    Bitmap kucukRes = new Bitmap(orjRes, kucukWidth, kucukHeight);
        //    Bitmap ortaRes = new Bitmap(orjRes, ortaWidth, ortaHeight);
        //    Bitmap buyukRes = new Bitmap(orjRes);

        //    kucukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Kucuk/" + newName));
        //    ortaRes.Save(ctx.Server.MapPath("~/Content/Resimler/Orta/" + newName));
        //    buyukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Buyuk/" + newName));

        //    Kullanici k = (Kullanici)ctx.Session["Kullanici"];

        //    Resim dbRes = new Resim();
        //    dbRes.Adi = (string)Resim.FileName;
        //    dbRes.BuyukResimYol = "/Content/Resimler/Buyuk/" + newName;
        //    dbRes.OrtaResimYol = "/Content/Resimler/Orta/" + newName;
        //    dbRes.KucukResimYol = "/Content/Resimler/Kucuk/" + newName;
        //    dbRes.EklenmeTarihi = DateTime.Now;
        //    dbRes.EkleyenID = k.Id;

        //    db.Resim.Add(dbRes);
        //    db.SaveChanges();
        //    return dbRes.Id;
        //}
    }
}