using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmServis.Controllers
{
    public class DtModulController : Controller
    {
        ModulManager mm = new ModulManager(new EfModulDal());
        ServisDepartmanManager sdm = new ServisDepartmanManager(new EfServisDepartmanDal());
        Modul_ServisDepartmanManager msdm = new Modul_ServisDepartmanManager(new EfModul_ServisDepartmanDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtModulController> _logger;

        public DtModulController(ILogger<DtModulController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtModul(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.modulList = mm.TGetList().Where(x => x.ModulId == 0);
            }
            var modulSiraNo = mm.TGetList().Count;
            string ModulNo;
            if (modulSiraNo == 0)
            {
                ModulNo = "10001";
                HttpContext.Session.SetString("ModulNo", "10001");
            }
            else
            {
                ModulNo = (Int32.Parse(mm.TGetList().OrderByDescending(x => x.ModulNo).FirstOrDefault().ModulNo) + 1).ToString();
                HttpContext.Session.SetString("ModulNo", (Int32.Parse(mm.TGetList().OrderByDescending(x => x.ModulNo).FirstOrDefault().ModulNo) + 1).ToString());
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtModul(string modulAdi, string modulKisaltma, bool silindi)
        {
            modulAdi = (modulAdi == null) ? modulAdi = "" : modulAdi = modulAdi.ToUpper();
            modulKisaltma = (modulKisaltma == null) ? modulKisaltma = "" : modulKisaltma = modulKisaltma.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.modulAdi = modulAdi;
            ViewBag.modulKisaltma = modulKisaltma;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblModul = mm.TGetList().Where(x => x.ModulAdi.ToUpper().Contains(modulAdi) && x.ModulKisaltma.ToUpper().StartsWith(modulKisaltma) && x.Silindi == silindi);
            ViewBag.modulList = tblModul;
            if (tblModul.ToList().Count == 0)
            {
                ViewBag.modulList = mm.TGetList().Where(x => x.ModulAdi == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ModulGor(int id,int departmanId)
        {
            ViewBag.id = id;
            ViewBag.servisDepartmanId=departmanId;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public IActionResult ModulGuncelle(int id, int departmanId)
        {
            ViewBag.id = id;
            ViewBag.servisDepartmanId = departmanId;
            ViewBag.servisDepartmanAdi = sdm.TGetByID(departmanId).ServisDepartmanAdi;
            ViewBag.servisDepartmanList = sdm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public IActionResult ModulGuncelle(Modul modul, int modulId, int servisDepartmanId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Moduls.Where(t => t.ModulId != modulId && t.Silindi == false).Any(x => x.ModulAdi.ToUpper() == modul.ModulAdi.ToUpper() || x.ModulKisaltma.ToUpper() == modul.ModulKisaltma.ToUpper());
            modul.Olusturan = olusturan;
            modul.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            modul.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            modul.SonDegistirmeTarih = DateTime.UtcNow;
            modul.ModulNo = db.Moduls.Where(x => x.ModulId == modulId).FirstOrDefault().ModulNo;
            if (isUpdatable == false)
            {
                try
                {
                    mm.TUpdate(modul);
                }
                catch (Exception ex)
                {

                    TempData["error"] = "err";
                    ViewBag.id = modulId;
                    ViewBag.servisDepartmanId = servisDepartmanId;
                    return View();
                }

            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = modulId;
                ViewBag.servisDepartmanId = servisDepartmanId;
                return View();
            }
            return RedirectToAction("DtModul");
        }
        [HttpGet]
        public IActionResult ModulEkle()
        {
            ViewBag.servisDepartmaniList = sdm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public ActionResult ModulEkle(Modul modul, int servisDepartmanId, int[] Departmans)
        {

            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            modul.ModulNo = HttpContext.Session.GetString("ModulNo");
            modul.SonDegistiren = kullanici;
            modul.Olusturan = kullanici;
            modul.SonDegistirmeTarih = DateTime.UtcNow.Date;
            modul.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Moduls.Where(t => t.Silindi == false).Any(x => x.ModulAdi == modul.ModulAdi);
            if (canBeAdded == false)
            {
                modul.ModulAdi = modul.ModulAdi.ToUpper();
                modul.ModulKisaltma = modul.ModulKisaltma.ToUpper();
                try
                {
                    mm.TAdd(modul);
                    var tblModul = mm.TGetList().Where(x => x.ModulNo == HttpContext.Session.GetString("ModulNo") && x.Silindi == false).FirstOrDefault();
                    for (int i = 0; i < Departmans.Length; i++)
                    {
                        Modul_ServisDepartman modul_ServisDepartman = new Modul_ServisDepartman();
                        modul_ServisDepartman.ModulId = tblModul.ModulId;
                        modul_ServisDepartman.ServisDepartmanId = Departmans[i];
                        msdm.TAdd(modul_ServisDepartman);
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = "err";
                    return View();
                }

            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtModul");
        }
        public ActionResult DeleteModul(int id)
        {
            var modul = mm.TGetByID(id);
            modul.Silindi = true;
            mm.TUpdate(modul);
            return RedirectToAction("DTModul");
        }
    }
}