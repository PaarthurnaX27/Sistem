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
    public class DtCariTipiController : Controller
    {
        CariTipiManager ctm = new CariTipiManager(new EfCariTipiDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtCariTipi(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.cariTipiList = ctm.TGetList().Where(x => x.CariTipiId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtCariTipi(string cariTipiAciklama, string cariTipiKisaltma, string cariTipiSimge, bool silindi = false)
        {

            cariTipiAciklama = (cariTipiAciklama == null) ? cariTipiAciklama = "" : cariTipiAciklama = cariTipiAciklama.ToUpper();
            cariTipiKisaltma = (cariTipiKisaltma == null) ? cariTipiKisaltma = "" : cariTipiKisaltma = cariTipiKisaltma;
            cariTipiSimge = (cariTipiSimge == null) ? cariTipiSimge = "" : cariTipiSimge = cariTipiSimge;
            ViewBag.chckSilindi = silindi;
            ViewBag.cariTipiAciklama = cariTipiAciklama;
            ViewBag.cariTipiKisaltma = cariTipiKisaltma;
            ViewBag.cariTipiSimge = cariTipiSimge;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblCariTipi = ctm.TGetList().Where(x => x.CariTipiAciklama.ToString().ToUpper().Contains(cariTipiAciklama) && x.Silindi == silindi);
            ViewBag.cariTipiList = tblCariTipi;
            if (tblCariTipi.ToList().Count == 0)
            {
                ViewBag.cariTipiList = ctm.TGetList().Where(x => x.CariTipiAciklama == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CariTipiGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult CariTipiGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult CariTipiGuncelle(CariTipi cariTipi, int cariTipiId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.CariTipis.Where(t => t.CariTipiId != cariTipiId && t.Silindi == false).Any(x => x.CariTipiAciklama == cariTipi.CariTipiAciklama);
            cariTipi.Olusturan = olusturan;
            cariTipi.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            cariTipi.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            cariTipi.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                ctm.TUpdate(cariTipi);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = cariTipiId;
                return View();
            }
            return RedirectToAction("DtCariTipi");
        }

        public ActionResult DeleteCariTipi(int id)
        {
            var cariTipi = ctm.TGetByID(id);
            cariTipi.Silindi = true;
            ctm.TUpdate(cariTipi);
            return RedirectToAction("DtCariTipi");
        }

        [HttpGet]
        public IActionResult CariTipiEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CariTipiEkle(CariTipi cariTipi)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            cariTipi.SonDegistiren = kullanici;
            cariTipi.Olusturan = kullanici;
            cariTipi.SonDegistirmeTarih = DateTime.UtcNow.Date;
            cariTipi.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.CariTipis.Where(t => t.Silindi == false).Any(x => x.CariTipiAciklama == cariTipi.CariTipiAciklama);
            if (canBeAdded == false)
            {
                cariTipi.CariTipiAciklama = cariTipi.CariTipiAciklama.ToUpper();
                ctm.TAdd(cariTipi);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtCariTipi");
        }
    }
}

