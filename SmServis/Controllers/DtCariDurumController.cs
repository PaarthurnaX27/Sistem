using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SmServis.Controllers
{
    public class DtCariDurumController : Controller
    {
        CariDurumManager cdm = new CariDurumManager(new EfCariDurumDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtCariDurum(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.cariDurumList = cdm.TGetList().Where(x => x.CariDurumId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtCariDurum(string cariDurumAciklama, string cariDurumKisaltma, string cariDurumSimge, bool silindi = false)
        {

            cariDurumAciklama = (cariDurumAciklama == null) ? cariDurumAciklama = "" : cariDurumAciklama = cariDurumAciklama.ToUpper();
            cariDurumKisaltma = (cariDurumKisaltma == null) ? cariDurumKisaltma = "" : cariDurumKisaltma = cariDurumKisaltma;
            cariDurumSimge = (cariDurumSimge == null) ? cariDurumSimge = "" : cariDurumSimge = cariDurumSimge;
            ViewBag.chckSilindi = silindi;
            ViewBag.cariDurumAciklama = cariDurumAciklama;
            ViewBag.cariDurumKisaltma = cariDurumKisaltma;
            ViewBag.cariDurumSimge = cariDurumSimge;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblCariDurum = cdm.TGetList().Where(x => x.CariDurumAciklama.ToString().ToUpper().Contains(cariDurumAciklama) && x.Silindi == silindi);
            ViewBag.cariDurumList = tblCariDurum;
            if (tblCariDurum.ToList().Count == 0)
            {
                ViewBag.cariDurumList = cdm.TGetList().Where(x => x.CariDurumAciklama == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CariDurumGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult CariDurumGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult CariDurumGuncelle(CariDurum cariDurum, int cariDurumId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.CariDurums.Where(t => t.CariDurumId != cariDurumId && t.Silindi == false).Any(x => x.CariDurumAciklama == cariDurum.CariDurumAciklama);
            cariDurum.Olusturan = olusturan;
            cariDurum.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            cariDurum.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            cariDurum.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                cdm.TUpdate(cariDurum);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = cariDurumId;
                return View();
            }
            return RedirectToAction("DtCariDurum");
        }

        public ActionResult DeleteCariDurum(int id)
        {
            var cariDurum = cdm.TGetByID(id);
            cariDurum.Silindi = true;
            cdm.TUpdate(cariDurum);
            return RedirectToAction("DtCariDurum");
        }

        [HttpGet]
        public IActionResult CariDurumEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CariDurumEkle(CariDurum cariDurum)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            cariDurum.SonDegistiren = kullanici;
            cariDurum.Olusturan = kullanici;
            cariDurum.SonDegistirmeTarih = DateTime.UtcNow.Date;
            cariDurum.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.CariDurums.Where(t => t.Silindi == false).Any(x => x.CariDurumAciklama == cariDurum.CariDurumAciklama );
            if (canBeAdded == false)
            {
                cariDurum.CariDurumAciklama = cariDurum.CariDurumAciklama.ToUpper();
                cdm.TAdd(cariDurum);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtCariDurum");
        }
    }
}

