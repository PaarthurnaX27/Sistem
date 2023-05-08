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

    public class DtSonDurumController : Controller
    {
        SonDurumManager mm = new SonDurumManager(new EfSonDurumDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtSonDurumController> _logger;

        public DtSonDurumController(ILogger<DtSonDurumController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtSonDurum(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.sonDurumList = mm.TGetList().Where(x => x.SonDurumId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtSonDurum(string sonDurumAciklama, bool silindi)
        {
            sonDurumAciklama = (sonDurumAciklama == null) ? sonDurumAciklama = "" : sonDurumAciklama = sonDurumAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.sonDurumAciklama = sonDurumAciklama;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblSonDurum = mm.TGetList().Where(x => x.SonDurumAciklama.ToUpper().Contains(sonDurumAciklama) && x.Silindi == silindi);
            ViewBag.sonDurumList = tblSonDurum;
            if (tblSonDurum.ToList().Count == 0)
            {
                ViewBag.sonDurumList = mm.TGetList().Where(x => x.SonDurumAciklama == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SonDurumGor(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public IActionResult SonDurumGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult SonDurumGuncelle(SonDurum sonDurum, int sonDurumId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.SonDurums.Where(t => t.SonDurumId != sonDurumId && t.Silindi == false).Any(x => x.SonDurumAciklama.ToUpper() == sonDurum.SonDurumAciklama.ToUpper());
            sonDurum.Olusturan = olusturan;
            sonDurum.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            sonDurum.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            sonDurum.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                mm.TUpdate(sonDurum);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = sonDurumId;
                return View();
            }
            return RedirectToAction("DtSonDurum");
        }
        [HttpGet]
        public IActionResult SonDurumEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SonDurumEkle(SonDurum sonDurum)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            sonDurum.SonDegistiren = kullanici;
            sonDurum.Olusturan = kullanici;
            sonDurum.SonDegistirmeTarih = DateTime.UtcNow.Date;
            sonDurum.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.SonDurums.Where(t => t.Silindi == false).Any(x => x.SonDurumAciklama == sonDurum.SonDurumAciklama);
            if (canBeAdded == false)
            {
                sonDurum.SonDurumAciklama = sonDurum.SonDurumAciklama.ToUpper();
                mm.TAdd(sonDurum);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtSonDurum");
        }
        public ActionResult DeleteSonDurum(int id)
        {
            var sonDurum = mm.TGetByID(id);
            sonDurum.Silindi = true;
            mm.TUpdate(sonDurum);
            return RedirectToAction("DTSonDurum");
        }
    }
}