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

    public class DtServisSekliController : Controller
    {
        ServisSekliManager ssm = new ServisSekliManager(new EfServisSekliDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtServisSekliController> _logger;

        public DtServisSekliController(ILogger<DtServisSekliController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtServisSekli(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.servisSekliList = ssm.TGetList().Where(x => x.ServisSekliId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtServisSekli(string servisSekliAciklama, bool silindi)
        {
            servisSekliAciklama = (servisSekliAciklama == null) ? servisSekliAciklama = "" : servisSekliAciklama = servisSekliAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.servisSekliAdi = servisSekliAciklama;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblServisSekli = ssm.TGetList().Where(x => x.ServisSekliAciklama.ToUpper().Contains(servisSekliAciklama) && x.Silindi == silindi);
            ViewBag.servisSekliList = tblServisSekli;
            if (tblServisSekli.ToList().Count == 0)
            {
                ViewBag.servisSekliList = ssm.TGetList().Where(x => x.ServisSekliAciklama == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ServisSekliGor(int id)
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
        public IActionResult ServisSekliGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult ServisSekliGuncelle(ServisSekli servisSekli, int servisSekliId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.ServisSeklis.Where(t => t.ServisSekliId != servisSekliId && t.Silindi == false).Any(x => x.ServisSekliAciklama.ToUpper() == servisSekli.ServisSekliAciklama.ToUpper() );
            servisSekli.Olusturan = olusturan;
            servisSekli.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            servisSekli.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            servisSekli.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                ssm.TUpdate(servisSekli);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = servisSekliId;
                return View();
            }
            return RedirectToAction("DtServisSekli");
        }
        [HttpGet]
        public IActionResult ServisSekliEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ServisSekliEkle(ServisSekli servisSekli)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            servisSekli.SonDegistiren = kullanici;
            servisSekli.Olusturan = kullanici;
            servisSekli.SonDegistirmeTarih = DateTime.UtcNow.Date;
            servisSekli.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.ServisSeklis.Where(t => t.Silindi == false).Any(x => x.ServisSekliAciklama == servisSekli.ServisSekliAciklama);
            if (canBeAdded == false)
            {
                servisSekli.ServisSekliAciklama = servisSekli.ServisSekliAciklama.ToUpper();
                ssm.TAdd(servisSekli);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtServisSekli");
        }
        public ActionResult DeleteServisSekli(int id)
        {
            var servisSekli = ssm.TGetByID(id);
            servisSekli.Silindi = true;
            ssm.TUpdate(servisSekli);
            return RedirectToAction("DTServisSekli");
        }
    }
}