using Blog_Son.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Son.Controllers
{
    public class EtiketController : Controller
    {
        // GET: Etiket
        KisiselBlogEntities db = new KisiselBlogEntities();
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public ActionResult MakaleListele(int id)
        {
            var data = db.Makale.Where(x => x.Etiket.Any(me => me.Id == id));
            return View("MakaleListele", data);
        }     
    }
}