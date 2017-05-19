using Blog_Son.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Blog_Son.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolYonetimController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
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
        // GET: RolYonetim
        public ActionResult Index()
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var model = roleManager.Roles.ToList();
            return View(model);
        }
        public ActionResult RolEkle()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult RolEkle(RolEkleModel rol)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if(roleManager.RoleExists(rol.RolAd) == false)
            {
                roleManager.Create(new IdentityRole(rol.RolAd));
            }
            return RedirectToAction("Index");
        }
        public ActionResult RolKullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RolKullaniciEkle(RolKullaniciEkleModel model)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var kullanici = userManager.FindByName(model.KullaniciAdi);
            if(!userManager.IsInRole(kullanici.Id, model.RolAdi))
            {
                userManager.AddToRole(kullanici.Id, model.RolAdi);
            }
            return RedirectToAction("Index");
        }
    }
}