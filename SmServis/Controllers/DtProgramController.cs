using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmServis.Controllers
{
    public class DtProgramController : Controller
    {
        ProgramManager prgm = new ProgramManager(new EfProgramDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtProgramController> _logger;

        public DtProgramController(ILogger<DtProgramController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtProgram(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.programList = prgm.TGetList().Where(x => x.ProgramId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtProgram(string programAdi, bool silindi)
        {
            programAdi = (programAdi == null) ? programAdi = "" : programAdi = programAdi.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.programAdi = programAdi;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblProgram = prgm.TGetList().Where(x => x.ProgramAdi.ToUpper().Contains(programAdi) && x.Silindi == silindi);
            ViewBag.programList = tblProgram;
            if (tblProgram.ToList().Count == 0)
            {
                ViewBag.programList = prgm.TGetList().Where(x => x.ProgramAdi == "none");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ProgramGor(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public IActionResult ProgramGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult ProgramGuncelle(Programs program, int programId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.Programs.Where(t => t.ProgramId != programId && t.Silindi == false).Any(x => x.ProgramAdi.ToUpper() == program.ProgramAdi.ToUpper());
            program.Olusturan = olusturan;
            program.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            program.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            program.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                prgm.TUpdate(program);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = programId;
                return View();
            }
            return RedirectToAction("DtProgram");
        }
        [HttpGet]
        public IActionResult ProgramEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ProgramEkle(Programs program)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            program.SonDegistiren = kullanici;
            program.Olusturan = kullanici;
            program.SonDegistirmeTarih = DateTime.UtcNow.Date;
            program.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.Programs.Where(t => t.Silindi == false).Any(x => x.ProgramAdi == program.ProgramAdi);
            if (canBeAdded == false)
            {
                program.ProgramAdi = program.ProgramAdi.ToUpper();
                prgm.TAdd(program);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtProgram");
        }
        public ActionResult DeleteProgram(int id)
        {
            var program = prgm.TGetByID(id);
            program.Silindi = true;
            prgm.TUpdate(program);
            return RedirectToAction("DTProgram");
        }
    }
}

