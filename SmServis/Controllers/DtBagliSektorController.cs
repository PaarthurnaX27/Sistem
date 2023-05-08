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
    public class DtBagliSektorController : Controller
    {
        BagliSektorManager bsm = new BagliSektorManager(new EfBagliSektorDal());
        AnaSektorManager asm = new AnaSektorManager(new EfAnaSektorDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        SmServisContext db = new SmServisContext();

        [HttpGet]
        public IActionResult DTBagliSektor(int id = 0)
        {
            ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
            ViewBag.bagliSektorlist = bsm.TGetList().Where(x => x.AnaSektorId == id && x.Silindi == false).OrderBy(x => x.BagliSektorAdi);
            return View();
        }

        [HttpPost]
        public ActionResult DTBagliSektor(string bagliSektorAdi, string anaSektorId, bool silindi = false)
        {

            bagliSektorAdi = (bagliSektorAdi == null) ? bagliSektorAdi = "" : bagliSektorAdi = bagliSektorAdi.ToUpper();
            anaSektorId = (anaSektorId == null) ? anaSektorId = "" : anaSektorId = anaSektorId;
            ViewBag.chckSilindi = silindi;
            ViewBag.bagliSektorAdi = bagliSektorAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            string anaSektorAdi = "";
            if (anaSektorId != "")
            {
                anaSektorAdi = asm.TGetByID(Int32.Parse(anaSektorId)).AnaSektorAdi;
                ViewBag.anaSektorAdi = anaSektorAdi;
            }
            ViewBag.anaSektorId = anaSektorId;
            ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
            if (anaSektorId == "")
            {
                var tblBagliSektor = bsm.TGetList().Where(x => x.BagliSektorAdi.ToString().ToUpper().Contains(bagliSektorAdi) && x.Silindi == silindi).OrderBy(x => x.BagliSektorAdi);
                ViewBag.bagliSektorList = tblBagliSektor;
                if (tblBagliSektor.ToList().Count == 0)
                {
                    ViewBag.bagliSektorList = bsm.TGetList().Where(x => x.BagliSektorAdi == "none");
                }
            }
            else
            {
                var tblBagliSektor = bsm.TGetList().Where(x => x.BagliSektorAdi.Contains(bagliSektorAdi) && x.Silindi == silindi && x.AnaSektorId == Int32.Parse(anaSektorId)).OrderBy(x => x.BagliSektorAdi);
                ViewBag.bagliSektorList = tblBagliSektor;
            }
            return View();
        }

        [HttpGet]
        public IActionResult BagliSektorGor(int id)
        {
            ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
            ViewBag.bagliSektorList = bsm.TGetByID(id);
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult BagliSektorGuncelle(int id)
        {
            ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult BagliSektorGuncelle(BagliSektor bagliSektor, int bagliSektorId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.BagliSektors.Where(t => t.BagliSektorId != bagliSektorId && t.AnaSektorId == bagliSektor.AnaSektorId).Any(x => x.BagliSektorAdi == bagliSektor.BagliSektorAdi);
            bagliSektor.Olusturan = olusturan;
            bagliSektor.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            bagliSektor.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            bagliSektor.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                bsm.TUpdate(bagliSektor);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = bagliSektorId;
                ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
                return View();
            }
            return RedirectToAction("DTBagliSektor");
        }

        [HttpGet]
        public IActionResult BagliSektorEkle()
        {
            ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
            return View();
        }

        [HttpPost]
        public ActionResult BagliSektorEkle(BagliSektor bagliSektor, int anaSektorId)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            bagliSektor.SonDegistiren = kullanici;
            bagliSektor.Olusturan = kullanici;
            bagliSektor.SonDegistirmeTarih = DateTime.UtcNow.Date;
            bagliSektor.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.BagliSektors.Where(x => x.AnaSektorId == anaSektorId).Any(x => x.BagliSektorAdi == bagliSektor.BagliSektorAdi);
            if (canBeAdded == false && bagliSektor.AnaSektorId != 0)
            {
                bagliSektor.BagliSektorAdi = bagliSektor.BagliSektorAdi.ToUpper();
                bsm.TAdd(bagliSektor);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.anaSektorList = asm.TGetList().OrderBy(x => x.AnaSektorAdi);
                return View();
            }
            return RedirectToAction("DTBagliSektor");
        }

        public ActionResult DeleteBagliSektor(int id)
        {
            var bagliSektor = bsm.TGetByID(id);
            bagliSektor.Silindi = true;
            bsm.TUpdate(bagliSektor);
            return RedirectToAction("DTBagliSektor");
        }
    }
}

