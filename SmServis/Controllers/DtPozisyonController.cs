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
    public class DtPozisyonController : Controller
    {
        PozisyonManager pzsm = new PozisyonManager(new EfPozisyonDal());
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        SmServisContext db = new SmServisContext();

        [HttpGet]
        public IActionResult DTPozisyon(int id = 0)
        {
            ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
            ViewBag.pozisyonlist = pzsm.TGetList().Where(x => x.DepartmanId == id && x.Silindi == false).OrderBy(x => x.PozisyonAdi);
            return View();
        }

        [HttpPost]
        public ActionResult DTPozisyon(string pozisyonAdi, string departmanId, bool silindi = false)
        {

            pozisyonAdi = (pozisyonAdi == null) ? pozisyonAdi = "" : pozisyonAdi = pozisyonAdi.ToUpper();
            departmanId = (departmanId == null) ? departmanId = "" : departmanId = departmanId;
            ViewBag.chckSilindi = silindi;
            ViewBag.pozisyonAdi = pozisyonAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            string departmanAdi = "";
            if (departmanId != "")
            {
                departmanAdi = dptm.TGetByID(Int32.Parse(departmanId)).DepartmanAdi;
                ViewBag.departmanAdi = departmanAdi;
            }
            ViewBag.departmanId = departmanId;
            ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
            if (departmanId == "")
            {
                var tblPozisyon = pzsm.TGetList().Where(x => x.PozisyonAdi.ToString().ToUpper().Contains(pozisyonAdi)  && x.Silindi == silindi).OrderBy(x => x.PozisyonAdi);
                ViewBag.pozisyonList = tblPozisyon;
                if (tblPozisyon.ToList().Count == 0)
                {
                    ViewBag.pozisyonList = pzsm.TGetList().Where(x => x.PozisyonAdi == "none");
                }
            }
            else
            {
                var tblPozisyon = pzsm.TGetList().Where(x => x.PozisyonAdi.Contains(pozisyonAdi) && x.Silindi == silindi && x.DepartmanId == Int32.Parse(departmanId)).OrderBy(x => x.PozisyonAdi);
                ViewBag.pozisyonList = tblPozisyon;
            }
            return View();
        }

        [HttpGet]
        public IActionResult PozisyonGor(int id)
        {
            ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
            ViewBag.pozisyonList = pzsm.TGetByID(id);
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult PozisyonGuncelle(int id)
        {
            ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult PozisyonGuncelle(Pozisyon pozisyon, int pozisyonId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Pozisyons.Where(t => t.PozisyonId != pozisyonId && t.DepartmanId == pozisyon.DepartmanId).Any(x => x.PozisyonAdi == pozisyon.PozisyonAdi);
            pozisyon.Olusturan = olusturan;
            pozisyon.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            pozisyon.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            pozisyon.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                pzsm.TUpdate(pozisyon);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = pozisyonId;
                ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
                return View();
            }
            return RedirectToAction("DTPozisyon");
        }

        [HttpGet]
        public IActionResult PozisyonEkle()
        {
            ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
            return View();
        }

        [HttpPost]
        public ActionResult PozisyonEkle(Pozisyon pozisyon, int departmanId)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            pozisyon.SonDegistiren = kullanici;
            pozisyon.Olusturan = kullanici;
            pozisyon.SonDegistirmeTarih = DateTime.UtcNow.Date;
            pozisyon.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Pozisyons.Where(x => x.DepartmanId == departmanId).Any(x => x.PozisyonAdi==pozisyon.PozisyonAdi);
            if (canBeAdded == false && pozisyon.DepartmanId != 0)
            {
                pozisyon.PozisyonAdi = pozisyon.PozisyonAdi.ToUpper();
                pzsm.TAdd(pozisyon);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.departmanList = dptm.TGetList().OrderBy(x => x.DepartmanAdi);
                return View();
            }
            return RedirectToAction("DTPozisyon");
        }

        public ActionResult DeletePozisyon(int id)
        {
            var pozisyon = pzsm.TGetByID(id);
            pozisyon.Silindi = true;
            pzsm.TUpdate(pozisyon);
            return RedirectToAction("DTPozisyon");
        }

    }
}

