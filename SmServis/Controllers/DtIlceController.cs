using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SmServis.Controllers
{
    public class DtIlceController : Controller
    {
        IlceManager ilcem = new IlceManager(new EfIlceDal());
        SehirManager sm = new SehirManager(new EfSehirDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        SmServisContext db = new SmServisContext();

        [HttpGet]
        public IActionResult DTIlce(int id = 0)
        {
            ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
            ViewBag.ilcelist = ilcem.TGetList().Where(x => x.SehirId == id && x.Silindi == false).OrderBy(x => x.IlceAdi);
            return View();
        }

        [HttpPost]
        public ActionResult DTIlce(string ilceAdi, string sehirId,string postaKodu ,bool silindi = false)
        {

            ilceAdi = (ilceAdi == null) ? ilceAdi = "" : ilceAdi = ilceAdi.ToUpper();
            postaKodu = (postaKodu == null) ? postaKodu = "" : postaKodu = postaKodu;
            sehirId = (sehirId == null) ? sehirId = "" : sehirId = sehirId;
            
            ViewBag.chckSilindi = silindi;
            ViewBag.ilceAdi = ilceAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            string sehirAdi = "";
            if (sehirId != "")
            {
                sehirAdi = sm.TGetByID(Int32.Parse(sehirId)).SehirAdi;
                ViewBag.sehirAdi = sehirAdi;
            }
            ViewBag.sehirId = sehirId;
            ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
            if (sehirId == "")
            {
                var tblIlce = ilcem.TGetList().Where(x => x.IlceAdi.ToString().ToUpper().Contains(ilceAdi) && x.PostaKodu.StartsWith(postaKodu) && x.Silindi == silindi).OrderBy(x => x.IlceAdi);
                ViewBag.ilceList = tblIlce;
                if (tblIlce.ToList().Count == 0)
                {
                    ViewBag.ilceList = ilcem.TGetList().Where(x => x.IlceAdi == "none");
                }
            }
            else
            {
                var tblIlce = ilcem.TGetList().Where(x => x.IlceAdi.Contains(ilceAdi) && x.PostaKodu.StartsWith(postaKodu) && x.Silindi == silindi && x.SehirId == Int32.Parse(sehirId)).OrderBy(x => x.IlceAdi);
                ViewBag.ilceList = tblIlce;
            }
            return View();
        }

        [HttpGet]
        public IActionResult IlceGor(int id)
        {
            ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
            ViewBag.ilceList = ilcem.TGetByID(id);
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult IlceGuncelle(int id)
        {
            ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult IlceGuncelle(Ilce ilce, int ilceId, int olusturan, string olusturulmaTarihi)
        {
          
            var isUpdatable = db.Ilces.Where(t => t.IlceId != ilceId).Any(x=> x.PostaKodu==ilce.PostaKodu);
            var isUpdatable2 = db.Ilces.Where(t => t.IlceId == ilceId).Any(x=> x.IlceAdi==ilce.IlceAdi || x.PostaKodu==ilce.PostaKodu);
            ilce.Olusturan = olusturan;
            ilce.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            ilce.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            ilce.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false && isUpdatable2==false)
            {
                ilcem.TUpdate(ilce);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = ilceId;
                ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
                return View();
            }
            return RedirectToAction("DTIlce");
        }

        [HttpGet]
        public IActionResult IlceEkle()
        {
            ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
            return View();
        }

        [HttpPost]
        public ActionResult IlceEkle(Ilce ilce, int sehirId)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            ilce.SonDegistiren = kullanici;
            ilce.Olusturan = kullanici;
            ilce.SonDegistirmeTarih = DateTime.UtcNow.Date;
            ilce.OlusturulmaTarih = DateTime.UtcNow;
            
            if (ilce.PostaKodu==null)
            {
                ilce.PostaKodu = "0";
                var canBeAdded = db.Ilces.Where(x => x.SehirId == sehirId).Any(x => x.IlceAdi == ilce.IlceAdi || x.PostaKodu==ilce.PostaKodu );
                if (canBeAdded == false && ilce.SehirId != 0)
                {
                    ilce.IlceAdi = ilce.IlceAdi.ToUpper();
                    ilcem.TAdd(ilce);
                }
                else
                {
                    TempData["error"] = "err";
                    ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
                    return View();
                }
            }
            else
            {
                var canBeAdded = db.Ilces.Any( x=> x.PostaKodu == ilce.PostaKodu);
                if (canBeAdded == false && ilce.SehirId != 0)
                {
                    ilce.IlceAdi = ilce.IlceAdi.ToUpper();
                    ilcem.TAdd(ilce);
                }
                else
                {
                    TempData["error"] = "err";
                    ViewBag.sehirList = sm.TGetList().OrderBy(x => x.SehirAdi);
                    return View();
                }
            }
            
           
            return RedirectToAction("DTIlce");
        }

        public ActionResult DeleteIlce(int id)
        {
            var ilce = ilcem.TGetByID(id);
            ilce.Silindi = true;
            ilcem.TUpdate(ilce);
            return RedirectToAction("DTIlce");
        }
    }
}

