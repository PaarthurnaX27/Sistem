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

    public class DtOncelikController : Controller
    {
        OncelikManager om = new OncelikManager(new EfOncelikDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtOncelikController> _logger;

        public DtOncelikController(ILogger<DtOncelikController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtOncelik(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.oncelikList = om.TGetList().Where(x => x.OncelikId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtOncelik(string oncelikAciklama,  bool silindi)
        {
            oncelikAciklama = (oncelikAciklama == null) ? oncelikAciklama = "" : oncelikAciklama = oncelikAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.oncelikAciklama = oncelikAciklama;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblOncelik = om.TGetList().Where(x => x.OncelikAciklama.ToUpper().Contains(oncelikAciklama)  && x.Silindi == silindi);
            ViewBag.oncelikList = tblOncelik;
            if (tblOncelik.ToList().Count == 0)
            {
                ViewBag.oncelikList = om.TGetList().Where(x => x.OncelikAciklama == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult OncelikGor(int id)
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
        public IActionResult OncelikGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult OncelikGuncelle(Oncelik oncelik, int oncelikId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Onceliks.Where(t => t.OncelikId != oncelikId && t.Silindi == false).Any(x => x.OncelikAciklama.ToUpper() == oncelik.OncelikAciklama.ToUpper() );
            oncelik.Olusturan = olusturan;
            oncelik.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            oncelik.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            oncelik.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                om.TUpdate(oncelik);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = oncelikId;
                return View();
            }
            return RedirectToAction("DtOncelik");
        }
        [HttpGet]
        public IActionResult OncelikEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult OncelikEkle(Oncelik oncelik)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            oncelik.SonDegistiren = kullanici;
            oncelik.Olusturan = kullanici;
            oncelik.SonDegistirmeTarih = DateTime.UtcNow.Date;
            oncelik.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Onceliks.Where(t => t.Silindi == false).Any(x => x.OncelikAciklama == oncelik.OncelikAciklama);
            if (canBeAdded == false)
            {
                oncelik.OncelikAciklama = oncelik.OncelikAciklama.ToUpper();
                om.TAdd(oncelik);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtOncelik");
        }
        public ActionResult DeleteOncelik(int id)
        {
            var oncelik = om.TGetByID(id);
            oncelik.Silindi = true;
            om.TUpdate(oncelik);
            return RedirectToAction("DTOncelik");
        }
    }
}