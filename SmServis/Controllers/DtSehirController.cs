using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmServis.Controllers
{
    public class DtSehirController : Controller
    {
        SehirManager sm = new SehirManager(new EfSehirDal());
        UlkeManager um = new UlkeManager(new EfUlkeDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        SmServisContext db = new SmServisContext();

        [HttpGet]
        public IActionResult DTSehir(int id = 0)
        {
            ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            ViewBag.sehirlist = sm.TGetList().Where(x => x.UlkeId == id && x.Silindi == false).OrderBy(x => x.SehirAdi);
            return View();
        }

        [HttpPost]
        public ActionResult DTSehir(string sehirAdi, string plakaKodu, string telefonKodu, string ulkeId, bool silindi = false, bool mevcut = false)
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
            if (silindi == true)
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
            if (ulkeId == "")
            {
                var tblSehir = sm.TGetList().Where(x => x.SehirAdi.ToString().ToUpper().Contains(sehirAdi) && x.PlakaKodu.StartsWith(plakaKodu) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi == silindi).OrderBy(x => x.SehirAdi);
                ViewBag.sehirList = tblSehir;
                if (tblSehir.ToList().Count == 0)
                {
                    ViewBag.sehirList = sm.TGetList().Where(x => x.SehirAdi == "none");
                }
            }
            else
            {
                var tblSehir = sm.TGetList().Where(x => x.SehirAdi.Contains(sehirAdi) && x.PlakaKodu.StartsWith(plakaKodu) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi == silindi && x.UlkeId == Int32.Parse(ulkeId)).OrderBy(x => x.SehirAdi);
                ViewBag.sehirList = tblSehir;
            }
            return View();
        }

        [HttpGet]
        public IActionResult SehirGor(int id)
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
        public IActionResult SehirGuncelle(Sehir sehir, int sehirId, int olusturan, string olusturulmaTarihi)
        {
            //var tblSehir = sm.TGetList().Where(x => x.SehirId == sehirId);
            //var tblSehir = db.Sehirs.Where(x=>x.SehirId!=sehirId).Select(t=>t.PlakaKodu);
            var isUpdatable = db.Sehirs.Where(t => t.SehirId != sehirId && t.UlkeId == sehir.UlkeId).Any(x =>x.SehirAdi==sehir.SehirAdi || x.PlakaKodu == sehir.PlakaKodu || x.TelefonKodu == sehir.TelefonKodu || x.PostaKodu == sehir.PostaKodu);
            //  sehir.SehirId = sehirId;
            sehir.Olusturan = olusturan;
            sehir.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            sehir.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            sehir.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                sm.TUpdate(sehir);
            }
            else
            {
               
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
            var canBeAdded = db.Sehirs.Where(x => x.UlkeId == ulkeId).Any(x => x.SehirAdi==sehir.SehirAdi || x.PlakaKodu == sehir.PlakaKodu || x.TelefonKodu == sehir.TelefonKodu || x.PostaKodu == sehir.PostaKodu);
            if (canBeAdded == false && sehir.UlkeId != 0)
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

        public ActionResult DeleteSehir(int id)
        {
            var sehir = sm.TGetByID(id);
            sehir.Silindi = true;
            sm.TUpdate(sehir);
            return RedirectToAction("DTSehir");
        }

        [HttpGet]
        public ActionResult FindUlkeId(string ulkeAdi)
        {
            var tblUlke = db.Ulkes.Where(x => x.UlkeAdi == ulkeAdi).FirstOrDefault();
            var ulkeId = tblUlke.UlkeId;
            return Json(ulkeId);
        }

        public JsonResult IsUserExists(string PlakaKodu)
        {
            return Json(!db.Sehirs.Any(x => x.PlakaKodu == PlakaKodu));
        }

    

        public IActionResult IsDeleted(bool s)
        {
            int id = 212;
            ViewBag.isChecked = s;
            s = !s;
            ViewBag.sehirlist = sm.TGetList().Where(x => x.UlkeId == id && x.Silindi == s).OrderBy(x => x.SehirAdi);
            return RedirectToAction("DTSehir");
        }

       
    }
}

