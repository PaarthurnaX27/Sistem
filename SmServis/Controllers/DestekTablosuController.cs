using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SmServis.Controllers
{
    
    public class DestekTablosuController : Controller
    {
        SehirManager sm = new SehirManager(new EfSehirDal());
        UlkeManager um = new UlkeManager(new EfUlkeDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        SmServisContext db = new SmServisContext();
      
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string table, string addorupdate)
        {
            switch (table)
            {
                case "sehir":
                    ViewBag.table = "sehir";
                    ViewBag.addorupdate = addorupdate;
                    ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
                    ViewBag.list = sm.TGetList().OrderBy(x => x.SehirAdi);
                    break;
                case "ulke":
                    ViewBag.table = "ulke";
                    ViewBag.addorupdate = addorupdate;
                    ViewBag.list = um.TGetList().OrderBy(x => x.UlkeAdi);
                    break;
                default:
                    break;
            }
            return View();
        }

        [HttpGet]
        public IActionResult DTSehir(int id=0)
        {
            ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            ViewBag.sehirlist = sm.TGetList().Where(x => x.UlkeId == id && x.Silindi==false).OrderBy(x => x.SehirAdi);
            return View();
        }

        [HttpPost]
        public ActionResult DTSehir(string sehirAdi, string plakaKodu, string telefonKodu, string ulkeId,bool silindi=false,bool mevcut=false)
        {
            
            sehirAdi = (sehirAdi == null) ? sehirAdi = "" : sehirAdi = sehirAdi.ToUpper();
            plakaKodu = (plakaKodu == null) ? plakaKodu = "" : plakaKodu = plakaKodu;
            telefonKodu = (telefonKodu == null) ? telefonKodu = "" : telefonKodu = telefonKodu;
            ulkeId = (ulkeId == null) ? ulkeId = "" : ulkeId = ulkeId;
            ViewBag.chckSilindi = silindi;
            ViewBag.chckMevcut = mevcut;
            ViewBag.sehirAdi = sehirAdi;
            ViewBag.plakaKodu = plakaKodu;
            ViewBag.telefonKodu = telefonKodu;
            if (silindi==true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            string ulkeAdi = "";
            if (ulkeId != "")
            {
                ulkeAdi = um.TGetByID(Int32.Parse(ulkeId)).UlkeAdi;
                ViewBag.ulkeAdi = ulkeAdi;
            }
            ViewBag.ulkeId = ulkeId;
            ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            mevcut = !mevcut;
            if (ulkeId=="")
            {
                var tblSehir = sm.TGetList().Where(x => x.SehirAdi.ToString().ToUpper().Contains(sehirAdi) && x.PlakaKodu.StartsWith(plakaKodu) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi==silindi ).OrderBy(x => x.SehirAdi);
                ViewBag.sehirList = tblSehir;
                if (tblSehir.ToList().Count==0)
                {
                    ViewBag.sehirList = sm.TGetList().Where(x=>x.SehirAdi=="none");
                }
            }
            else
            {
                var tblSehir = sm.TGetList().Where(x => x.SehirAdi.Contains(sehirAdi) && x.PlakaKodu.StartsWith(plakaKodu) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi==silindi && x.UlkeId == Int32.Parse(ulkeId)).OrderBy(x => x.SehirAdi);
                ViewBag.sehirList = tblSehir;
            }
            return View();  
        }

        [HttpGet]
        public IActionResult IcerikGor(int id)
        {
            ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            ViewBag.sehirList = sm.TGetByID(id);
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult SehirGuncelle(int id)
        {
            ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult SehirGuncelle(Sehir sehir, int sehirId,int olusturan,string olusturulmaTarihi)
        {
            //var tblSehir = sm.TGetList().Where(x => x.SehirId == sehirId);
            //var tblSehir = db.Sehirs.Where(x=>x.SehirId!=sehirId).Select(t=>t.PlakaKodu);
            var isUpdatable = db.Sehirs.Where(t => t.SehirId != sehirId && t.UlkeId==sehir.UlkeId).Any(x => x.PlakaKodu == sehir.PlakaKodu || x.TelefonKodu == sehir.TelefonKodu || x.PostaKodu == sehir.PostaKodu);
            //  sehir.SehirId = sehirId;
            sehir.Olusturan = olusturan;
            sehir.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            sehir.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            sehir.SonDegistirmeTarih = DateTime.UtcNow;
            if(isUpdatable==false)
            {
                sm.TUpdate(sehir);
            }
            else
            {
                var a = IsUserExists(sehir.PlakaKodu);
                TempData["error"] = "err";
                ViewBag.id = sehirId;
                ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
                return View();
            }
            return RedirectToAction("DTSehir");
        }  

        [HttpGet]
        public IActionResult SehirEkle()
        {
            ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            return View();
        }

        [HttpPost]
        public ActionResult SehirEkle(Sehir sehir, int ulkeId)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            sehir.SonDegistiren = kullanici;
            sehir.Olusturan = kullanici;
            sehir.SonDegistirmeTarih = DateTime.UtcNow.Date;
            sehir.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Sehirs.Where(x=>x.UlkeId==ulkeId).Any(x => x.PlakaKodu == sehir.PlakaKodu || x.TelefonKodu == sehir.TelefonKodu || x.PostaKodu == sehir.PostaKodu);
            if (canBeAdded == false && sehir.UlkeId!=0)
            {
                sehir.SehirAdi = sehir.SehirAdi.ToUpper();
                sm.TAdd(sehir);
            }
            else
            {
              //  var a = IsUserExists(sehir.PlakaKodu);
                TempData["error"] = "err";
                //ViewBag.id = sehirId;
                ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
                return View();
            }
            return RedirectToAction("DTSehir");
        }

        [HttpPost]
        public IActionResult EditAndAddUlke([Bind(Prefix = "Item1")] Ulke ulke, int id, string table, string addorupdate)
        {
            if (addorupdate == "update")
            {
                ulke.UlkeId = id;
                um.TUpdate(ulke);
                return RedirectToAction("Edit", new { table = table, addorupdate = addorupdate });
            }
            else if (addorupdate == "add")
            {
                um.TAdd(ulke);
                return RedirectToAction("Edit", new { table = table, addorupdate = "update" });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult FindUlkeId(string ulkeAdi)
        {
            var tblUlke = db.Ulkes.Where(x => x.UlkeAdi == ulkeAdi).FirstOrDefault();
            var ulkeId = tblUlke.UlkeId;
            return Json(ulkeId);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Filter(string sehirAdi, string plakaKodu, string telefonKodu)
        {
            var tblSehir = db.Sehirs.Where(x => x.SehirAdi == sehirAdi);
            ViewBag.list2 = tblSehir.ToList();
            return RedirectToAction("Edit", new { table = "sehir", addorupdate = "update" });
        }

        public JsonResult IsUserExists(string PlakaKodu)
        { 
            return Json(!db.Sehirs.Any(x => x.PlakaKodu == PlakaKodu));
        }

        public ActionResult DeleteSehir(int id)
        {
            var sehir = sm.TGetByID(id);
            sehir.Silindi = true;
            sm.TUpdate(sehir);
            return RedirectToAction("DTSehir");
        }

        public IActionResult IsDeleted(bool s)
        {
            int id = 212;
            ViewBag.isChecked = s;
            s = !s;
            ViewBag.sehirlist = sm.TGetList().Where(x => x.UlkeId == id && x.Silindi == s).OrderBy(x => x.SehirAdi);
           
            return RedirectToAction("DTSehir");
        }
     
        //[HttpGet]
        //public IActionResult SehirPartial()
        //{
        //    ViewBag.list = sm.TGetList();
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult SehirPartial( [Bind(Prefix ="Item1")] Sehir sehir)
        //{
        //    sehir.UlkeId = 212;
        //    sehir.SehirId = 2;

        //    sm.TUpdate(sehir);
        //    //ViewBag.list = sm.TGetList();
        //    //ViewBag.table = "sehir";
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult Edit([Bind(Prefix = "Item1")] Sehir sehir,[Bind(Prefix ="Item2")] Ulke ulke,string table,string addorupdate)
        //{
        //    if (addorupdate=="update")
        //    {
        //        //sehir.UlkeId = 212;

        //        //var tbl = db.Sehirs.Where(x => x.SehirId == id).FirstOrDefault();

        //        //sm.TUpdate(tbl);
        //        //sm.TUpdate(tb);
        //        return RedirectToAction("Edit", new { table = table,addorupdate=addorupdate });
        //    }
        //    else if (addorupdate=="add")
        //    {
        //        um.TAdd(ulke);
        //        return RedirectToAction("Edit", new { table = table });

        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}
    }
}

