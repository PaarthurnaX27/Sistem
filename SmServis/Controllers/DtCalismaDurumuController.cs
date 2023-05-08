using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmServis.Controllers
{
   public class DtCalismaDurumuController : Controller
    {
        CalismaDurumuManager cdm = new CalismaDurumuManager(new EfCalismaDurumuDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtCalismaDurumu(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.calismaDurumuList = cdm.TGetList().Where(x => x.CalismaDurumuId == 0);
            }

            return View();
        }

        [HttpPost]
        public ActionResult DtCalismaDurumu(string calismaDurumuAciklama, bool silindi = false)
        {

            calismaDurumuAciklama = (calismaDurumuAciklama == null) ? calismaDurumuAciklama = "" : calismaDurumuAciklama = calismaDurumuAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.calismaDurumuAciklama = calismaDurumuAciklama;
  
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblCalismaDurumu = cdm.TGetList().Where(x => x.CalismaDurumuAciklama.ToString().ToUpper().Contains(calismaDurumuAciklama) && x.Silindi == silindi);
            ViewBag.calismaDurumuList = tblCalismaDurumu;
            if (tblCalismaDurumu.ToList().Count == 0)
            {
                ViewBag.calismaDurumuList = cdm.TGetList().Where(x => x.CalismaDurumuAciklama == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CalismaDurumuGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult CalismaDurumuGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult CalismaDurumuGuncelle(CalismaDurumu calismaDurumu, int calismaDurumuId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.CalismaDurumus.Where(t => t.CalismaDurumuId != calismaDurumuId && t.Silindi == false).Any(x => x.CalismaDurumuAciklama == calismaDurumu.CalismaDurumuAciklama);
            calismaDurumu.Olusturan = olusturan;
            calismaDurumu.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            calismaDurumu.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            calismaDurumu.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                cdm.TUpdate(calismaDurumu);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = calismaDurumuId;
                return View();
            }
            return RedirectToAction("DtCalismaDurumu");
        }

        public ActionResult DeleteCalismaDurumu(int id)
        {
            var calismaDurumu = cdm.TGetByID(id);
            calismaDurumu.Silindi = true;
            cdm.TUpdate(calismaDurumu);
            return RedirectToAction("DtCalismaDurumu");
        }

        [HttpGet]
        public IActionResult CalismaDurumuEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CalismaDurumuEkle(CalismaDurumu calismaDurumu)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            calismaDurumu.SonDegistiren = kullanici;
            calismaDurumu.Olusturan = kullanici;
            calismaDurumu.SonDegistirmeTarih = DateTime.UtcNow.Date;
            calismaDurumu.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.CalismaDurumus.Where(t => t.Silindi == false).Any(x => x.CalismaDurumuAciklama == calismaDurumu.CalismaDurumuAciklama );
            if (canBeAdded == false)
            {
                calismaDurumu.CalismaDurumuAciklama = calismaDurumu.CalismaDurumuAciklama.ToUpper();
                cdm.TAdd(calismaDurumu);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtCalismaDurumu");
        }
    }
}