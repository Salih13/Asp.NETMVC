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
    public class KategoriController : Controller
    {
        // GET: Kategori
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
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public ActionResult MakaleListele(int id)
        {
            var data = db.Makale.Where(x => x.KategoriID == id);
            return View("MakaleListele", data);
        }
    }
}