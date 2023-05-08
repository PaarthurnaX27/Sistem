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

namespace SmPersonel.Controllers
{
    public class DtPersonelTipiController : Controller
    {
        PersonelTipiManager ptm = new PersonelTipiManager(new EfPersonelTipiDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtPersonelTipiController> _logger;

        public DtPersonelTipiController(ILogger<DtPersonelTipiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtPersonelTipi(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.personelTipiList = ptm.TGetList().Where(x => x.PersonelTipiId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtPersonelTipi(string personelTipiAciklama, bool silindi)
        {
            personelTipiAciklama = (personelTipiAciklama == null) ? personelTipiAciklama = "" : personelTipiAciklama = personelTipiAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.personelTipiAciklama = personelTipiAciklama;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblPersonelTipi = ptm.TGetList().Where(x => x.PersonelTipiAciklama.ToUpper().Contains(personelTipiAciklama) && x.Silindi == silindi);
            ViewBag.personelTipiList = tblPersonelTipi;
            if (tblPersonelTipi.ToList().Count == 0)
            {
                ViewBag.personelTipiList = ptm.TGetList().Where(x => x.PersonelTipiAciklama == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonelTipiGor(int id)
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
        public IActionResult PersonelTipiGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult PersonelTipiGuncelle(PersonelTipi personelTipi, int personelTipiId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.PersonelTipis.Where(t => t.PersonelTipiId != personelTipiId && t.Silindi == false).Any(x => x.PersonelTipiAciklama.ToUpper() == personelTipi.PersonelTipiAciklama.ToUpper());
            personelTipi.Olusturan = olusturan;
            personelTipi.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            personelTipi.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            personelTipi.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                ptm.TUpdate(personelTipi);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = personelTipiId;
                return View();
            }
            return RedirectToAction("DtPersonelTipi");
        }
        [HttpGet]
        public IActionResult PersonelTipiEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult PersonelTipiEkle(PersonelTipi personelTipi)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            personelTipi.SonDegistiren = kullanici;
            personelTipi.Olusturan = kullanici;
            personelTipi.SonDegistirmeTarih = DateTime.UtcNow.Date;
            personelTipi.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.PersonelTipis.Where(t => t.Silindi == false).Any(x => x.PersonelTipiAciklama == personelTipi.PersonelTipiAciklama);
            if (canBeAdded == false)
            {
                personelTipi.PersonelTipiAciklama = personelTipi.PersonelTipiAciklama.ToUpper();
                ptm.TAdd(personelTipi);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtPersonelTipi");
        }
        public ActionResult DeletePersonelTipi(int id)
        {
            var personelTipi = ptm.TGetByID(id);
            personelTipi.Silindi = true;
            ptm.TUpdate(personelTipi);
            return RedirectToAction("DTPersonelTipi");
        }
    }
}

