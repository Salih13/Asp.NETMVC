using Blog_Son.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog_Son.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        KisiselBlogEntities db = new KisiselBlogEntities();
        [AllowAnonymous]
        public ActionResult Girisyap()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Girisyap(string kullaniciAdi, string Parola)
        {
            if (Membership.ValidateUser(kullaniciAdi, Parola))
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciAdi, true);
                Guid id = (Guid)Membership.GetUser(kullaniciAdi).ProviderUserKey;
                Session["Kullanici"] = db.Kullanici.FirstOrDefault(x => x.Id == id);
                string kAdi = Membership.GetUser(kullaniciAdi).UserName;
                if (kAdi == "Admin")
                {
                    Session["Kullanici"] = "Admin";
                    //ViewBag.Tip = 1;
                }
                Session["KullaniciAdi"] = kAdi;
                return RedirectToAction("Index", "Home");
            }
            else if (kullaniciAdi == "" || Parola == "")
            {
                ViewBag.Mesaj = "Kullanici adi veya Parola bos gecilemez.";
                return View();
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya parola yanlış.";
                return View();
            }
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult KayitOl(Kullanici kullanici, HttpPostedFileBase Resim, string Parola)
        {
            MembershipUser user = Membership.CreateUser(kullanici.Nick, Parola, kullanici.Mail);
            kullanici.Id = (Guid)user.ProviderUserKey;
            Session["Kullanici"] = kullanici;
            Session["KullaniciAdi"] = kullanici.Nick;
            //kullanici.ResimID = YonetimController.ResimKaydet(Resim, HttpContext);
            kullanici.KayitTarihi = DateTime.Now;
            if (kullanici.Nick == "Admin")
            { 
                ViewBag.Tip = 1;
            }
            db.Kullanici.Add(kullanici);
            db.SaveChanges();
            FormsAuthentication.RedirectFromLoginPage(kullanici.Nick, true);
            Session["Kullanici"] = kullanici;
            return RedirectToAction("Index", "Home");
        }
    }
}