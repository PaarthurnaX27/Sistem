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
    public class DtUnvanController : Controller
    {
        UnvanManager unvm = new UnvanManager(new EfUnvanDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtUnvan(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.unvanList = unvm.TGetList().Where(x => x.UnvanId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtUnvan(string unvanAciklama, string unvanKisaltma, string unvanSimge, bool silindi = false)
        {

            unvanAciklama = (unvanAciklama == null) ? unvanAciklama = "" : unvanAciklama = unvanAciklama.ToUpper();
            unvanKisaltma = (unvanKisaltma == null) ? unvanKisaltma = "" : unvanKisaltma = unvanKisaltma;
            unvanSimge = (unvanSimge == null) ? unvanSimge = "" : unvanSimge = unvanSimge;
            ViewBag.chckSilindi = silindi;
            ViewBag.unvanAciklama = unvanAciklama;
            ViewBag.unvanKisaltma = unvanKisaltma;
            ViewBag.unvanSimge = unvanSimge;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblUnvan = unvm.TGetList().Where(x => x.UnvanAciklama.ToString().ToUpper().Contains(unvanAciklama) && x.UnvanKisaltma.ToUpper().StartsWith(unvanKisaltma.ToUpper()) && x.Silindi == silindi);
            ViewBag.unvanList = tblUnvan;
            if (tblUnvan.ToList().Count == 0)
            {
                ViewBag.unvanList = unvm.TGetList().Where(x => x.UnvanAciklama == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UnvanGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult UnvanGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult UnvanGuncelle(Unvan unvan, int unvanId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Unvans.Where(t => t.UnvanId != unvanId && t.Silindi == false).Any(x => x.UnvanAciklama == unvan.UnvanAciklama || x.UnvanKisaltma == unvan.UnvanKisaltma);
            unvan.Olusturan = olusturan;
            unvan.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            unvan.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            unvan.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                unvm.TUpdate(unvan);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = unvanId;
                return View();
            }
            return RedirectToAction("DtUnvan");
        }

        public ActionResult DeleteUnvan(int id)
        {
            var unvan = unvm.TGetByID(id);
            unvan.Silindi = true;
            unvm.TUpdate(unvan);
            return RedirectToAction("DtUnvan");
        }

        [HttpGet]
        public IActionResult UnvanEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UnvanEkle(Unvan unvan)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            unvan.SonDegistiren = kullanici;
            unvan.Olusturan = kullanici;
            unvan.SonDegistirmeTarih = DateTime.UtcNow.Date;
            unvan.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Unvans.Where(t => t.Silindi == false).Any(x => x.UnvanAciklama == unvan.UnvanAciklama || x.UnvanKisaltma == unvan.UnvanKisaltma);
            if (canBeAdded == false)
            {
                unvan.UnvanAciklama = unvan.UnvanAciklama.ToUpper();
                unvm.TAdd(unvan);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtUnvan");
        }
    }
}

