using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using Dapper;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SmServis.Controllers
{
    public class LoginController : Controller
    {
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        KullaniciFirmaManager kfm = new KullaniciFirmaManager(new EfKullaniciFirmaDal());
        SecCmpManager scm = new SecCmpManager(new EfSecCmpDal());

        Random r =new Random();

        public static int a=0;
        [AllowAnonymous]
        public IActionResult Giris()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Giris(Kullanici kullanici)
        {   
            var giris = km.TGetList().Where(x => x.KullaniciMail == kullanici.KullaniciMail && x.KullaniciParola == kullanici.KullaniciParola).FirstOrDefault();
         //   var asd = km.TGetList().Where(x=>x.KullaniciMail==);
            if (giris != null)
            {
                var kisiId = giris.KullaniciId;
                var kullanici_firmaId = kfm.TGetList().Where(x => x.KullaniciId == kisiId).OrderBy(x => x.CompanyId);
                List<int> firmaList = new List<int>();
                foreach (var item in kullanici_firmaId)
                {
                    firmaList.Add(item.CompanyId);
                }
                ViewBag.firmaList = firmaList;
                ViewBag.parametre = "select";
                HttpContext.Session.SetInt32("kullanici", giris.KullaniciId);
                TempData["error"]=null;
                return View();
            }
            else
            {
                TempData["error"] = "err";
                return RedirectToAction("Giris", "Login");
            }
        }

        [HttpPost]
        public IActionResult FirmaSec(string companyNo)
        {
            var cmp = scm.TGetList().Where(x => x.CompanyNo == companyNo).FirstOrDefault();
            DataAccessLayer.Concrete.SmServisContext.data = cmp.DatabaseName;
            HttpContext.Session.SetString("firma", cmp.CompanyName);
            return RedirectToAction("Index", "Home");
        }
    }
}

