using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;

namespace SmServis.Controllers
{
    public class DtParaBirimiController : Controller
    {
        ParaBirimiManager pbm = new ParaBirimiManager(new EfParaBirimiDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtParaBirimi(bool isFirst=false)
        {
            if (isFirst==false)
            {
                ViewBag.paraBirimiList = pbm.TGetList().Where(x => x.ParaBirimiId == 0);
            }
           
           
            return View();
        }

        [HttpPost]
        public ActionResult DtParaBirimi(string paraBirimiAdi, string paraBirimiKisaltma, string paraBirimiSimge, bool silindi = false)
        {

            paraBirimiAdi = (paraBirimiAdi == null) ? paraBirimiAdi = "" : paraBirimiAdi = paraBirimiAdi.ToUpper();
            paraBirimiKisaltma = (paraBirimiKisaltma == null) ? paraBirimiKisaltma = "" : paraBirimiKisaltma = paraBirimiKisaltma;
            paraBirimiSimge = (paraBirimiSimge == null) ? paraBirimiSimge = "" : paraBirimiSimge = paraBirimiSimge;
            ViewBag.chckSilindi = silindi;
            ViewBag.paraBirimiAdi = paraBirimiAdi;
            ViewBag.paraBirimiKisaltma = paraBirimiKisaltma;
            ViewBag.paraBirimiSimge = paraBirimiSimge;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblParaBirimi = pbm.TGetList().Where(x => x.ParaBirimiAdi.ToString().ToUpper().Contains(paraBirimiAdi) && x.ParaBirimiKisaltma.ToUpper().StartsWith(paraBirimiKisaltma.ToUpper()) && x.ParaBirimiSimge.Contains(paraBirimiSimge) && x.Silindi == silindi);
            ViewBag.paraBirimiList = tblParaBirimi;
            if (tblParaBirimi.ToList().Count == 0)
            {
                ViewBag.paraBirimiList = pbm.TGetList().Where(x => x.ParaBirimiAdi == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult ParaBirimiGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult ParaBirimiGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult ParaBirimiGuncelle(ParaBirimi paraBirimi, int paraBirimiId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.ParaBirimis.Where(t => t.ParaBirimiId != paraBirimiId && t.Silindi == false).Any(x => x.ParaBirimiAdi == paraBirimi.ParaBirimiAdi || x.ParaBirimiKisaltma == paraBirimi.ParaBirimiKisaltma || x.ParaBirimiSimge == paraBirimi.ParaBirimiSimge);
            paraBirimi.Olusturan = olusturan;
            paraBirimi.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            paraBirimi.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            paraBirimi.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                pbm.TUpdate(paraBirimi);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = paraBirimiId;
                return View();
            }
            return RedirectToAction("DtParaBirimi");
        }

        public ActionResult DeleteParaBirimi(int id)
        {
            var paraBirimi = pbm.TGetByID(id);
            paraBirimi.Silindi = true;
            pbm.TUpdate(paraBirimi);
            return RedirectToAction("DtParaBirimi");
        }

        [HttpGet]
        public IActionResult ParaBirimiEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ParaBirimiEkle(ParaBirimi paraBirimi)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            paraBirimi.SonDegistiren = kullanici;
            paraBirimi.Olusturan = kullanici;
            paraBirimi.SonDegistirmeTarih = DateTime.UtcNow.Date;
            paraBirimi.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.ParaBirimis.Where(t=>t.Silindi==false).Any(x => x.ParaBirimiAdi == paraBirimi.ParaBirimiAdi || x.ParaBirimiKisaltma == paraBirimi.ParaBirimiKisaltma || x.ParaBirimiSimge == paraBirimi.ParaBirimiSimge);
            if (canBeAdded == false)
            {
                paraBirimi.ParaBirimiAdi = paraBirimi.ParaBirimiAdi.ToUpper();
                pbm.TAdd(paraBirimi);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtParaBirimi");
        }
    }
}

