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
    public class DtServisDepartmanController : Controller
    {
         ServisDepartmanManager sdm = new ServisDepartmanManager(new EfServisDepartmanDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtServisDepartmanController> _logger;

        public DtServisDepartmanController(ILogger<DtServisDepartmanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtServisDepartman(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.servisDepartmanList = sdm.TGetList().Where(x => x.ServisDepartmanId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtServisDepartman(string servisDepartmanAdi,  bool silindi)
        {
            servisDepartmanAdi = (servisDepartmanAdi == null) ? servisDepartmanAdi = "" : servisDepartmanAdi = servisDepartmanAdi.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.servisDepartmanAdi = servisDepartmanAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblServisDepartman = sdm.TGetList().Where(x => x.ServisDepartmanAdi.ToUpper().Contains(servisDepartmanAdi)  && x.Silindi == silindi);
            ViewBag.servisDepartmanList = tblServisDepartman;
            if (tblServisDepartman.ToList().Count == 0)
            {
                ViewBag.servisDepartmanList = sdm.TGetList().Where(x => x.ServisDepartmanAdi == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ServisDepartmanGor(int id)
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
        public IActionResult ServisDepartmanGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult ServisDepartmanGuncelle(ServisDepartman servisDepartman, int servisDepartmanId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.ServisDepartmans.Where(t => t.ServisDepartmanId != servisDepartmanId && t.Silindi == false).Any(x => x.ServisDepartmanAdi.ToUpper() == servisDepartman.ServisDepartmanAdi.ToUpper());
            servisDepartman.Olusturan = olusturan;
            servisDepartman.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            servisDepartman.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            servisDepartman.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                sdm.TUpdate(servisDepartman);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = servisDepartmanId;
                return View();
            }
            return RedirectToAction("DtServisDepartman");
        }
        [HttpGet]
        public IActionResult ServisDepartmanEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ServisDepartmanEkle(ServisDepartman servisDepartman)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            servisDepartman.SonDegistiren = kullanici;
            servisDepartman.Olusturan = kullanici;
            servisDepartman.SonDegistirmeTarih = DateTime.UtcNow.Date;
            servisDepartman.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.ServisDepartmans.Where(t => t.Silindi == false).Any(x => x.ServisDepartmanAdi == servisDepartman.ServisDepartmanAdi);
            if (canBeAdded == false)
            {
                servisDepartman.ServisDepartmanAdi = servisDepartman.ServisDepartmanAdi.ToUpper();
                sdm.TAdd(servisDepartman);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtServisDepartman");
        }
        public ActionResult DeleteServisDepartman(int id)
        {
            var servisDepartman = sdm.TGetByID(id);
            servisDepartman.Silindi = true;
            sdm.TUpdate(servisDepartman);
            return RedirectToAction("DTServisDepartman");
        }
    }
}