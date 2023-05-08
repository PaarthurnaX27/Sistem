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
    public class DtUlkeController : Controller
    {
        UlkeManager um = new UlkeManager(new EfUlkeDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtUlke(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.ulkeList = um.TGetList().Where(x => x.UlkeId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtUlke(string ulkeAdi, string binaryCode, string tripleCode, string telefonKodu, bool silindi = false)
        {

            ulkeAdi = (ulkeAdi == null) ? ulkeAdi = "" : ulkeAdi = ulkeAdi.ToUpper();
            binaryCode = (binaryCode == null) ? binaryCode = "" : binaryCode = binaryCode;
            tripleCode = (tripleCode == null) ? tripleCode = "" : tripleCode = tripleCode;
            telefonKodu = (telefonKodu == null) ? telefonKodu = "" : telefonKodu = telefonKodu;
            ViewBag.chckSilindi = silindi;
            ViewBag.ulkeAdi = ulkeAdi;
            ViewBag.binaryCode = binaryCode;
            ViewBag.tripleCode = tripleCode;
            ViewBag.telefonKodu = telefonKodu;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblUlke = um.TGetList().Where(x => x.UlkeAdi.ToString().ToUpper().Contains(ulkeAdi) && x.BinaryCode.ToString().ToUpper().StartsWith(binaryCode.ToUpper()) && x.TripleCode.ToString().ToUpper().StartsWith(tripleCode.ToUpper()) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi == silindi).OrderBy(x=>x.UlkeAdi);
            ViewBag.ulkeList = tblUlke;
            if (tblUlke.ToList().Count == 0)
            {
                ViewBag.ulkeList = um.TGetList().Where(x => x.UlkeAdi == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UlkeGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult UlkeGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult UlkeGuncelle(Ulke ulke, int ulkeId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Ulkes.Where(t => t.UlkeId != ulkeId && t.Silindi == false).Any(x => x.UlkeAdi == ulke.UlkeAdi || x.BinaryCode==ulke.BinaryCode || x.TripleCode==ulke.TripleCode || x.TelefonKodu==ulke.TelefonKodu);
            ulke.Olusturan = olusturan;
            ulke.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            ulke.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            ulke.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                um.TUpdate(ulke);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = ulkeId;
                return View();
            }
            return RedirectToAction("DtUlke");
        }

        public ActionResult DeleteUlke(int id)
        {
            var ulke = um.TGetByID(id);
            ulke.Silindi = true;
            um.TUpdate(ulke);
            return RedirectToAction("DtUlke");
        }

        [HttpGet]
        public IActionResult UlkeEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UlkeEkle(Ulke ulke)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            ulke.SonDegistiren = kullanici;
            ulke.Olusturan = kullanici;
            ulke.SonDegistirmeTarih = DateTime.UtcNow.Date;
            ulke.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Ulkes.Where(t => t.Silindi == false).Any(x => x.UlkeAdi == ulke.UlkeAdi || x.BinaryCode == ulke.BinaryCode || x.TripleCode == ulke.TripleCode || x.TelefonKodu == ulke.TelefonKodu);
            if (canBeAdded == false)
            {
                ulke.UlkeAdi = ulke.UlkeAdi.ToUpper();
                um.TAdd(ulke);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtUlke");
        }
    }
}

