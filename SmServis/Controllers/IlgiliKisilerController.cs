using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SmServis.Controllers
{
    public class IlgiliKisilerController : Controller
    {
        IlgiliKisilerManager ikm = new IlgiliKisilerManager(new EfIlgiliKisilerDal());
        CariPersonelManager pm = new CariPersonelManager(new EfCariPersonelDal());
        CariManager cm = new CariManager(new EfCariDal());
        UnvanManager unvm = new UnvanManager(new EfUnvanDal());
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());

        [HttpGet]
        public IActionResult IlgiliKisiler()
        {
            Vb();
            ViewBag.ilgiliKisilerList = ikm.TGetList();
            return View();
        }

        [HttpPost]
        public IActionResult IlgiliKisiler(int id)
        {
            Vb();
            ViewBag.ilgiliKisilerList=ikm.TGetList();
            return View();
        }

        [HttpGet]
        public IActionResult IlgiliKisiGor(int id)
        {
            ViewBag.id = id;
            ViewBag.cariList = cm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpGet]
        public IActionResult IlgiliKisiGuncelle(int id)
        {
            Vb();
            return View();
        }

        // [HttpGet]
        // public IActionResult IlgiliKisiEkle()
        // {
        //     Vb();
        //     ViewBag.personelList = pm.TGetList().Where(x => x.CalismaDurumu == false);
        //     return View();
        // }

        [HttpPost]
        public ActionResult IlgiliKisiEkle(int cariId, int cariPersonelId, IlgiliKisiler ilgiliKisiler)
        {
            try
            {
                if (ilgiliKisiler.CariId == 0 || cariPersonelId == 0)
                {
                    ViewBag.Message = "tekrar dene";
                    Vb();
                    return View();
                }
                Vb();
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");

                var cariPersonel = pm.TGetByID(cariPersonelId);
              //  cariPersonel.CalismaDurumu = true;
                pm.TUpdate(cariPersonel);
                ilgiliKisiler.PersonelId = cariPersonelId;
                ilgiliKisiler.SonDegistiren = kullanici;
                ilgiliKisiler.Olusturan = kullanici;
                ilgiliKisiler.SonDegistirmeTarih = DateTime.UtcNow.Date;
                ilgiliKisiler.OlusturulmaTarih = DateTime.UtcNow;
                ikm.TAdd(ilgiliKisiler);
                return RedirectToAction("IlgiliKisiler");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "tekrar dene";
                Vb();
                return View();
            }
        }

        [HttpPost]
        public ActionResult IlgiliKisilerId(int id)
        {
            return Json(id);
        }
        public ActionResult PersonelGetir(int id)
        {
            var tblPersonel = pm.TGetByID(id);
            return Json(tblPersonel);
        }

        [HttpGet]
        public ActionResult PozisyonGetir(int id)
        {
            var departman = dptm.TGetByID(id);
            var pozisyon = pznm.TGetList().Where(x => x.DepartmanId == departman.DepartmanId).ToList();
            return Json(pozisyon);
        }

        public void Vb()
        {
            ViewBag.cariList = cm.TGetList();
            ViewBag.personelList = pm.TGetList();
            ViewBag.pozisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
        }
    }
}

