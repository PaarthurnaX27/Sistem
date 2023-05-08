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
    public class DtDepartmanController : Controller
    {
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());
        SmServisContext db = new SmServisContext();
        [HttpGet]
        public IActionResult DtDepartman(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.departmanList = dptm.TGetList().Where(x => x.DepartmanId == 0);
            }


            return View();
        }

        [HttpPost]
        public ActionResult DtDepartman(string departmanAdi, bool silindi = false)
        {

            departmanAdi = (departmanAdi == null) ? departmanAdi = "" : departmanAdi = departmanAdi.ToUpper();
           
           
            ViewBag.chckSilindi = silindi;
            ViewBag.departmanAdi = departmanAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblDepartman = dptm.TGetList().Where(x => x.DepartmanAdi.ToString().ToUpper().Contains(departmanAdi.ToUpper()) && x.Silindi == silindi);
            ViewBag.departmanList = tblDepartman;
            if (tblDepartman.ToList().Count == 0)
            {
                ViewBag.departmanList = dptm.TGetList().Where(x => x.DepartmanAdi == "none");
            }

            return View();
        }

        [HttpGet]
        public IActionResult DepartmanGor(int id)
        {
            ViewBag.id = id;
            ViewBag.pozisyonList = pznm.TGetList().Where(x => x.DepartmanId == id);
            return View();
        }

        [HttpGet]
        public IActionResult DepartmanGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult DepartmanGuncelle(Departman departman, int departmanId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Departmans.Where(t => t.DepartmanId != departmanId && t.Silindi == false).Any(x => x.DepartmanAdi == departman.DepartmanAdi);
            departman.Olusturan = olusturan;
            departman.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            departman.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            departman.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                dptm.TUpdate(departman);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = departmanId;
                return View();
            }
            return RedirectToAction("DtDepartman");
        }

        public ActionResult DeleteDepartman(int id)
        {
            var departman = dptm.TGetByID(id);
            departman.Silindi = true;
            dptm.TUpdate(departman);
            return RedirectToAction("DtDepartman");
        }

        [HttpGet]
        public IActionResult DepartmanEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            departman.SonDegistiren = kullanici;
            departman.Olusturan = kullanici;
            departman.SonDegistirmeTarih = DateTime.UtcNow.Date;
            departman.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Departmans.Where(t => t.Silindi == false).Any(x => x.DepartmanAdi == departman.DepartmanAdi);
            if (canBeAdded == false)
            {
                departman.DepartmanAdi = departman.DepartmanAdi.ToUpper();
                dptm.TAdd(departman);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtDepartman");
        }
    }
}

