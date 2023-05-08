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
    public class DtCinsiyetController : Controller
    {
        CinsiyetManager cnsm = new CinsiyetManager(new EfCinsiyetDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtCinsiyet(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.CinsiyetId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtCinsiyet(string cinsiyetAciklama, string cinsiyetKisaltma, string cinsiyetSimge, bool silindi = false)
        {

            cinsiyetAciklama = (cinsiyetAciklama == null) ? cinsiyetAciklama = "" : cinsiyetAciklama = cinsiyetAciklama.ToUpper();
            cinsiyetKisaltma = (cinsiyetKisaltma == null) ? cinsiyetKisaltma = "" : cinsiyetKisaltma = cinsiyetKisaltma;
            cinsiyetSimge = (cinsiyetSimge == null) ? cinsiyetSimge = "" : cinsiyetSimge = cinsiyetSimge;
            ViewBag.chckSilindi = silindi;
            ViewBag.cinsiyetAciklama = cinsiyetAciklama;
            ViewBag.cinsiyetKisaltma = cinsiyetKisaltma;
            ViewBag.cinsiyetSimge = cinsiyetSimge;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblCinsiyet = cnsm.TGetList().Where(x => x.CinsiyetAciklama.ToString().ToUpper().Contains(cinsiyetAciklama) && x.Silindi == silindi);
            ViewBag.cinsiyetList = tblCinsiyet;
            if (tblCinsiyet.ToList().Count == 0)
            {
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.CinsiyetAciklama == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CinsiyetGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult CinsiyetGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult CinsiyetGuncelle(Cinsiyet cinsiyet, int cinsiyetId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Cinsiyets.Where(t => t.CinsiyetId != cinsiyetId && t.Silindi == false).Any(x => x.CinsiyetAciklama == cinsiyet.CinsiyetAciklama);
            cinsiyet.Olusturan = olusturan;
            cinsiyet.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            cinsiyet.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            cinsiyet.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                cnsm.TUpdate(cinsiyet);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = cinsiyetId;
                return View();
            }
            return RedirectToAction("DtCinsiyet");
        }

        public ActionResult DeleteCinsiyet(int id)
        {
            var cinsiyet = cnsm.TGetByID(id);
            cinsiyet.Silindi = true;
            cnsm.TUpdate(cinsiyet);
            return RedirectToAction("DtCinsiyet");
        }

        [HttpGet]
        public IActionResult CinsiyetEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CinsiyetEkle(Cinsiyet cinsiyet)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            cinsiyet.SonDegistiren = kullanici;
            cinsiyet.Olusturan = kullanici;
            cinsiyet.SonDegistirmeTarih = DateTime.UtcNow.Date;
            cinsiyet.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Cinsiyets.Where(t => t.Silindi == false).Any(x => x.CinsiyetAciklama == cinsiyet.CinsiyetAciklama);
            if (canBeAdded == false)
            {
                cinsiyet.CinsiyetAciklama = cinsiyet.CinsiyetAciklama.ToUpper();
                cnsm.TAdd(cinsiyet);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtCinsiyet");
        }
    }
}

