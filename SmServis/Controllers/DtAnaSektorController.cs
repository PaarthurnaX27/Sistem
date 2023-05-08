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
    public class DtAnaSektorController : Controller
    {
        AnaSektorManager asm = new AnaSektorManager(new EfAnaSektorDal());
        // PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());
        Ana_BagliSektorManager a_bm = new Ana_BagliSektorManager(new EfAna_BagliSektorDal());
        BagliSektorManager bsm = new BagliSektorManager(new EfBagliSektorDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtAnaSektor(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.anaSektorList = asm.TGetList().Where(x => x.AnaSektorId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtAnaSektor(string anaSektorAdi, bool silindi = false)
        {

            anaSektorAdi = (anaSektorAdi == null) ? anaSektorAdi = "" : anaSektorAdi = anaSektorAdi.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.anaSektorAdi = anaSektorAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblAnaSektor = asm.TGetList().Where(x => x.AnaSektorAdi.ToString().ToUpper().Contains(anaSektorAdi.ToUpper()) && x.Silindi == silindi);
            ViewBag.anaSektorList = tblAnaSektor;
            if (tblAnaSektor.ToList().Count == 0)
            {
                ViewBag.anaSektorList = asm.TGetList().Where(x => x.AnaSektorAdi == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AnaSektorGor(int id)
        {
            ViewBag.id = id;

            ViewBag.bagliSektorList = bsm.TGetList().Where(x => x.AnaSektorId == id);
            return View();
        }

        [HttpGet]
        public IActionResult AnaSektorGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AnaSektorGuncelle(AnaSektor anaSektor, int anaSektorId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.AnaSektors.Where(t => t.AnaSektorId != anaSektorId && t.Silindi == false).Any(x => x.AnaSektorAdi == anaSektor.AnaSektorAdi);
            anaSektor.Olusturan = olusturan;
            anaSektor.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            anaSektor.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            anaSektor.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                asm.TUpdate(anaSektor);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = anaSektorId;
                return View();
            }
            return RedirectToAction("DtAnaSektor");
        }

        public ActionResult DeleteAnaSektor(int id)
        {
            var anaSektor = asm.TGetByID(id);
            anaSektor.Silindi = true;
            asm.TUpdate(anaSektor);
            return RedirectToAction("DtAnaSektor");
        }

        [HttpGet]
        public IActionResult AnaSektorEkle()
        {
            ViewBag.bagliSektorList = bsm.TGetList();
            return View();
        }

        [HttpPost]
        public ActionResult AnaSektorEkle(AnaSektor anaSektor)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            anaSektor.SonDegistiren = kullanici;
            anaSektor.Olusturan = kullanici;
            anaSektor.SonDegistirmeTarih = DateTime.UtcNow.Date;
            anaSektor.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.AnaSektors.Where(t => t.Silindi == false).Any(x => x.AnaSektorAdi == anaSektor.AnaSektorAdi);
            if (canBeAdded == false)
            {
                anaSektor.AnaSektorAdi = anaSektor.AnaSektorAdi.ToUpper();
                asm.TAdd(anaSektor);
                ViewBag.isAdded = "true";
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            ViewBag.bagliSektorList = bsm.TGetList();
            return RedirectToAction("DtAnaSektor");
        }
    }
}

