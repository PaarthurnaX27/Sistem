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
    
    public class DtIslemYeriController : Controller
    {
       IslemYeriManager mm = new IslemYeriManager(new EfIslemYeriDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtIslemYeriController> _logger;

        public DtIslemYeriController(ILogger<DtIslemYeriController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtIslemYeri(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.islemYeriList = mm.TGetList().Where(x => x.IslemYeriId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtIslemYeri(string islemYeriAdi,  bool silindi)
        {
            islemYeriAdi = (islemYeriAdi == null) ? islemYeriAdi = "" : islemYeriAdi = islemYeriAdi.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.islemYeriAdi = islemYeriAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblIslemYeri = mm.TGetList().Where(x => x.IslemYeriAdi.ToUpper().Contains(islemYeriAdi) &&  x.Silindi == silindi);
            ViewBag.islemYeriList = tblIslemYeri;
            if (tblIslemYeri.ToList().Count == 0)
            {
                ViewBag.islemYeriList = mm.TGetList().Where(x => x.IslemYeriAdi == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult IslemYeriGor(int id)
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
        public IActionResult IslemYeriGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult IslemYeriGuncelle(IslemYeri islemYeri, int islemYeriId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.IslemYeris.Where(t => t.IslemYeriId != islemYeriId && t.Silindi == false).Any(x => x.IslemYeriAdi.ToUpper() == islemYeri.IslemYeriAdi.ToUpper() );
            islemYeri.Olusturan = olusturan;
            islemYeri.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            islemYeri.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            islemYeri.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                mm.TUpdate(islemYeri);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = islemYeriId;
                return View();
            }
            return RedirectToAction("DtIslemYeri");
        }
        [HttpGet]
        public IActionResult IslemYeriEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IslemYeriEkle(IslemYeri islemYeri)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            islemYeri.SonDegistiren = kullanici;
            islemYeri.Olusturan = kullanici;
            islemYeri.SonDegistirmeTarih = DateTime.UtcNow.Date;
            islemYeri.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.IslemYeris.Where(t => t.Silindi == false).Any(x => x.IslemYeriAdi == islemYeri.IslemYeriAdi);
            if (canBeAdded == false)
            {
                islemYeri.IslemYeriAdi = islemYeri.IslemYeriAdi.ToUpper();
                mm.TAdd(islemYeri);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtIslemYeri");
        }
        public ActionResult DeleteIslemYeri(int id)
        {
            var islemYeri = mm.TGetByID(id);
            islemYeri.Silindi = true;
            mm.TUpdate(islemYeri);
            return RedirectToAction("DTIslemYeri");
        }
    }
}