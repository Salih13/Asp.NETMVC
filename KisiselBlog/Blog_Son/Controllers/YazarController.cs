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
    public class YazarController : Controller
    {
        // GET: Yazar
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
        public ActionResult Index(Guid id)
        {
            return View(id);
        }
        public ActionResult MakaleListele(Guid id)
        {
            var data = db.Makale.Where(x => x.YazarID == id);
            return View("MakaleListele", data);
        }
    }
}