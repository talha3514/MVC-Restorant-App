using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Restorant.Controllers
{
    public class HomeController : Controller
    {
        RestorantEntities DB = new RestorantEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(kullanicilar p, string returnUrl)
        {
            var datavalues = DB.kullanicilar.FirstOrDefault(x => x.kullanici_adi == p.kullanici_adi
            && x.kullanici_sifre == p.kullanici_sifre);
            
            if (datavalues != null)
            {
                FormsAuthentication.SetAuthCookie(datavalues.kullanici_adi, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Hatalı Giriş Yaptınız!!!";
                return View("Login");
            }
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Creat(kullanicilar uye)
        {
            var dataValue = DB.kullanicilar.FirstOrDefault(x => x.kullanici_adi == uye.kullanici_adi);
            if (uye.kullanici_adi != null && dataValue == null)
            {
                DB.kullanicilar.Add(uye);
                DB.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            else 
            {
                
                return RedirectToAction("Creat", "Home");
            }

        }
    }
}