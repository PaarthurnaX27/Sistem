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

    public class DtServisTipiController : Controller
    {
        ServisTipiManager stm = new ServisTipiManager(new EfServisTipiDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtServisTipiController> _logger;

        public DtServisTipiController(ILogger<DtServisTipiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtServisTipi(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.servisTipiList = stm.TGetList().Where(x => x.ServisTipiId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtServisTipi(string servisTipiAciklama, bool silindi)
        {
            servisTipiAciklama = (servisTipiAciklama == null) ? servisTipiAciklama = "" : servisTipiAciklama = servisTipiAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.servisTipiAciklama = servisTipiAciklama;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblServisTipi = stm.TGetList().Where(x => x.ServisTipiAciklama.ToUpper().Contains(servisTipiAciklama) && x.Silindi == silindi);
            ViewBag.servisTipiList = tblServisTipi;
            if (tblServisTipi.ToList().Count == 0)
            {
                ViewBag.servisTipiList = stm.TGetList().Where(x => x.ServisTipiAciklama == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ServisTipiGor(int id)
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
        public IActionResult ServisTipiGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult ServisTipiGuncelle(ServisTipi servisTipi, int servisTipiId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.ServisTipis.Where(t => t.ServisTipiId != servisTipiId && t.Silindi == false).Any(x => x.ServisTipiAciklama.ToUpper() == servisTipi.ServisTipiAciklama.ToUpper());
            servisTipi.Olusturan = olusturan;
            servisTipi.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            servisTipi.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            servisTipi.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                stm.TUpdate(servisTipi);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = servisTipiId;
                return View();
            }
            return RedirectToAction("DtServisTipi");
        }
        [HttpGet]
        public IActionResult ServisTipiEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ServisTipiEkle(ServisTipi servisTipi)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            servisTipi.SonDegistiren = kullanici;
            servisTipi.Olusturan = kullanici;
            servisTipi.SonDegistirmeTarih = DateTime.UtcNow.Date;
            servisTipi.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.ServisTipis.Where(t => t.Silindi == false).Any(x => x.ServisTipiAciklama == servisTipi.ServisTipiAciklama);
            if (canBeAdded == false)
            {
                servisTipi.ServisTipiAciklama = servisTipi.ServisTipiAciklama.ToUpper();
                stm.TAdd(servisTipi);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtServisTipi");
        }
        public ActionResult DeleteServisTipi(int id)
        {
            var servisTipi = stm.TGetByID(id);
            servisTipi.Silindi = true;
            stm.TUpdate(servisTipi);
            return RedirectToAction("DTServisTipi");
        }
    }
}