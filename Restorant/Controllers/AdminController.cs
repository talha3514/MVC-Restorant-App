using PagedList;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restorant.Controllers
{
    [Authorize(Users = "Admin")]
    public class AdminController : Controller
    {
        
        RestorantEntities DB = new RestorantEntities();
        public ActionResult Admin(int? page)
        {

            var item = DB.rezervasyon.ToList().ToPagedList(page ?? 1, 10);
            return View(item);
        }
        
        public ActionResult Detail(int id)
        {
            var item = DB.rezervasyon.Where(x => x.rezervasyon_id ==  id).FirstOrDefault();
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = DB.rezervasyon.Where(x => x.rezervasyon_id == id).FirstOrDefault();
            DB.rezervasyon.Remove(item);
            DB.SaveChanges();
            var item2 = DB.rezervasyon.ToList();
            return View("Admin", item2);
        }

        public ActionResult Edit(int id)
        {
            var item = DB.rezervasyon.Where(x => x.rezervasyon_id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(rezervasyon rez)
        {
            DB.Entry(rez).State = EntityState.Modified;
            DB.SaveChanges();
            
            return RedirectToAction("Admin");
        }

        //Kullanıclar
        public ActionResult Users()
        {
            var users = DB.kullanicilar.ToList();
            return View(users);
        }
        public ActionResult UsersEdit(int id)
        {
            var item = DB.kullanicilar.Where(x => x.kullanici_id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public ActionResult UsersEdit(kullanicilar rez)
        {
            DB.Entry(rez).State = EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("Users");
        }

        public ActionResult UsersDelete(int id)
        {
            var item = DB.kullanicilar.Where(x => x.kullanici_id == id).FirstOrDefault();
            DB.kullanicilar.Remove(item);
            DB.SaveChanges();
            var item2 = DB.kullanicilar.ToList();
            return View("Users", item2);
        }

        //Kategoriler
        public ActionResult Categories()
        {
            var item = DB.kategori.ToList();
            return View(item);
        }

        public ActionResult CategoriesEdit(int id)
        {
            var item = DB.kategori.Where(x => x.kategori_id == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult CategoriesEdit(kategori rez)
        {
            DB.Entry(rez).State = EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("Categories");
        }

        public ActionResult CategoriesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoriesAdd( kategori rez)
        {
            DB.kategori.Add(rez);
            DB.SaveChanges();
            return RedirectToAction("Categories", "Admin");
        }
        public ActionResult CategoriesDelete(int id)
        {
            var item = DB.kategori.Where(x => x.kategori_id== id).First();
            DB.kategori.Remove(item);
            DB.SaveChanges();
            var item2 = DB.kategori.ToList();
            return View("Categories", item2);
        }


        //Yemekler
        public ActionResult Yemekler(int? page)
        {
            var item = DB.yemekler.ToList().ToPagedList(page ?? 1, 10);
            return View(item);
        }

        public ActionResult YemeklerEdit(int id)
        {
            var item = DB.yemekler.Where(x => x.yemek_id == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult YemeklerEdit(yemekler rez)
        {
            DB.Entry(rez).State = EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("Yemekler");
        }

        public ActionResult YemeklerAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YemeklerAdd(yemekler rez)
        {
            DB.yemekler.Add(rez);
            DB.SaveChanges();
            return RedirectToAction("Yemekler", "Admin");
        }
        public ActionResult YemeklerDelete(int id)
        {
            var item = DB.yemekler.Where(x => x.yemek_id== id).First();
            DB.yemekler.Remove(item);
            DB.SaveChanges();
            var item2 = DB.yemekler.ToList();
            return View("Yemekler", item2);
        }
    }
}
