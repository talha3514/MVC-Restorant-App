using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restorant.Controllers
{
    [Authorize]
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        RestorantEntities DB = new RestorantEntities();
        public ActionResult Rezervasyon()
        {
            List<kullanicilar> kullanicilars= DB.kullanicilar.ToList();
            return View(kullanicilars);
        }
        
        [HttpPost]
        public ActionResult Rezervasyon(rezervasyon rez)
        {
            DB.rezervasyon.Add(rez);
            DB.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}