using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restorant.Controllers
{
    public class YemekController : Controller
    {
        // GET: Yemek
        public ActionResult Index()
        {
            RestorantEntities DB = new RestorantEntities();
            List<yemekler> yemek = DB.yemekler.ToList();
            

            return View(yemek);
        }
    }
}