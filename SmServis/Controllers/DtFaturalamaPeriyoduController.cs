using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class DtFaturalamaPeriyoduController : Controller
    {
        FaturalamaPeriyoduManager fpm = new FaturalamaPeriyoduManager(new EfFaturalamaPeriyoduDal());
        SmServisContext db = new SmServisContext();
        private readonly ILogger<DtFaturalamaPeriyoduController> _logger;

        public DtFaturalamaPeriyoduController(ILogger<DtFaturalamaPeriyoduController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult DtFaturalamaPeriyodu(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.faturalamaPeriyoduList = fpm.TGetList().Where(x => x.FaturalamaPeriyoduId == 0);
            }
            return View();

        }

        [HttpPost]
        public IActionResult DtFaturalamaPeriyodu(string faturalamaPeriyoduAciklama, bool silindi)
        {
            faturalamaPeriyoduAciklama = (faturalamaPeriyoduAciklama == null) ? faturalamaPeriyoduAciklama = "" : faturalamaPeriyoduAciklama = faturalamaPeriyoduAciklama.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.faturalamaPeriyoduAciklama = faturalamaPeriyoduAciklama;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            var tblFaturalamaPeriyodu = fpm.TGetList().Where(x => x.FaturalamaPeriyoduAciklama.ToUpper().Contains(faturalamaPeriyoduAciklama) && x.Silindi == silindi);
            ViewBag.faturalamaPeriyoduList = tblFaturalamaPeriyodu;
            if (tblFaturalamaPeriyodu.ToList().Count == 0)
            {
                ViewBag.faturalamaPeriyoduList = fpm.TGetList().Where(x => x.FaturalamaPeriyoduAciklama == "none");
            }
 
            return View();
        }

        [HttpGet]
        public IActionResult FaturalamaPeriyoduGor(int id)
        {
            ViewBag.id = id;
            ViewBag.faturaList = fpm.TGetList().Where(x => x.Silindi == false);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public IActionResult FaturalamaPeriyoduGuncelle(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult FaturalamaPeriyoduGuncelle(FaturalamaPeriyodu faturalamaPeriyodu, int faturalamaPeriyoduId, int olusturan, string olusturulmaTarihi)
        {
            var isUpdatable = db.FaturalamaPeriyodus.Where(t => t.FaturalamaPeriyoduId != faturalamaPeriyoduId && t.Silindi == false).Any(x => x.FaturalamaPeriyoduAciklama.ToUpper() == faturalamaPeriyodu.FaturalamaPeriyoduAciklama.ToUpper());
            faturalamaPeriyodu.Olusturan = olusturan;
            faturalamaPeriyodu.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            faturalamaPeriyodu.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            faturalamaPeriyodu.SonDegistirmeTarih = DateTime.UtcNow;
            if (isUpdatable == false)
            {
                fpm.TUpdate(faturalamaPeriyodu);
            }
            else
            {
                TempData["error"] = "err";
                ViewBag.id = faturalamaPeriyoduId;
                return View();
            }
            return RedirectToAction("DtFaturalamaPeriyodu");
        }
        [HttpGet]
        public IActionResult FaturalamaPeriyoduEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult FaturalamaPeriyoduEkle(FaturalamaPeriyodu faturalamaPeriyodu)
        {
            var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
            faturalamaPeriyodu.SonDegistiren = kullanici;
            faturalamaPeriyodu.Olusturan = kullanici;
            faturalamaPeriyodu.SonDegistirmeTarih = DateTime.UtcNow.Date;
            faturalamaPeriyodu.OlusturulmaTarih = DateTime.UtcNow;
            var canBeAdded = db.FaturalamaPeriyodus.Where(t => t.Silindi == false).Any(x => x.FaturalamaPeriyoduAciklama == faturalamaPeriyodu.FaturalamaPeriyoduAciklama);
            if (canBeAdded == false)
            {
                faturalamaPeriyodu.FaturalamaPeriyoduAciklama = faturalamaPeriyodu.FaturalamaPeriyoduAciklama.ToUpper();
                fpm.TAdd(faturalamaPeriyodu);
            }
            else
            {
                TempData["error"] = "err";
                return View();
            }
            return RedirectToAction("DtFaturalamaPeriyodu");
        }
        public ActionResult DeleteFaturalamaPeriyodu(int id)
        {
            var faturalamaPeriyodu = fpm.TGetByID(id);
            faturalamaPeriyodu.Silindi = true;
            fpm.TUpdate(faturalamaPeriyodu);
            return RedirectToAction("DTFaturalamaPeriyodu");
        }
        [HttpPost]
        public IActionResult FaturalamaPeriyoduGor(string tarih, int periyotId)
        {
            int artik;
            string baslangicTarihi="";
            string bitisTarihi="";
            string gun="";
            string kalanGun = "";
            DateTime dt = DateTime.Parse(tarih);
            if (dt.Year % 4 == 0)
            {
                artik = 29;
                if (dt.Year % 100 != 0 && DateTime.Now.Year % 400 != 0)
                {
                    artik = 29;
                }
                else
                {
                    artik = 28;
                }
            }
            else
            {
                artik = 28;
            }
           var ocak = new
            {
                gun = 31,
                ay = 1
            };
            var subat = new
            {
                ay = 2,
                gun = artik
            };
           
            var mart =new {
                 ay=3,
                 gun=31 };
            var nisan = new {
                ay = 4,
                gun = 30
            };
            var mayis = new
            {
                ay = 5,
                gun = 31
            };
            var haziran = new {
                gun = 30,
                ay=6
            };
            var temmuz = new {
                gun=31,
                ay=7
                };
            var agustos = new {
                gun=31,
                ay=8
                };
            var eylul = new {
                gun=30,
                ay=9
                };
            var ekim = new {
                gun=31,
                ay=10
                };
            var kasim = new {
                gun=30,
                ay=11
                };
            var aralik = new {
                gun=31,
                ay=12
                };
            
            var tblFaturaPeriyodu = fpm.TGetByID(periyotId);
            DateTime date = DateTime.Parse(tarih);
            
            switch (tblFaturaPeriyodu.PeriyotNo)
            {
                case 1:
                    DateTime dateD = date.AddDays(-tblFaturaPeriyodu.PeriyotSayisi);
                    TimeSpan tsD = date - dateD;
                    ViewBag.baslangic = dateD.ToShortDateString();
                    ViewBag.bitis = date.ToShortDateString();
                    ViewBag.gun = tsD.Days.ToString();

                    break;
                case 2:
                   var week =new  GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    int minusDay = tblFaturaPeriyodu.PeriyotSayisi * 7;
                   DateTime dateW = date.AddDays(-minusDay);
                    DateTime dateW2 = date.AddDays(-7);
                   var a= FirstDayOfWeek(dateW);
                   var b= LastDayOfWeek(dateW2);
                    TimeSpan tsW = b - a;
                    ViewBag.baslangic = a.ToString("dd/MM/yyyy");
                    ViewBag.bitis = b.ToString("dd/MM/yyyy");
                    ViewBag.gun = tsW.Days;
                    break;
                case 3:
                    int fMonth;
                    int isNegative = Convert.ToInt32(date.Month) - tblFaturaPeriyodu.PeriyotSayisi;
                    int fYear = date.Year;
                    gun="";
                    if (isNegative<0)
                    {
                       fMonth= 12 + isNegative;
                        fYear -= 1;
                    }
                    else if (isNegative == 0)
                    {
                        fMonth = 12;
                        fYear -= 1;
                    }
                    else
                    {
                        fMonth = isNegative ;
                    }
                     baslangicTarihi = "01"+"/"+fMonth+"/"+fYear;

                    int lMonth = Convert.ToInt32(date.Month) - 1;
                    int lYear = date.Year;
                    switch (lMonth)
                    {
                        case 0:
                            lMonth = 12;
                            lYear -= 1;
                            break;
                        case -1:
                            lMonth = 11;
                            break;
                        case -2:
                            lMonth = 10;
                            break;
                        default:
                            break;
                    }
                    if (lMonth == ocak.ay)
                    {
                        gun = ocak.gun.ToString();
                    }
                    else if (lMonth == subat.ay)
                    {
                        gun = subat.gun.ToString();
                    }
                    else if (lMonth == mart.ay)
                    {
                        gun = mart.gun.ToString();
                    }
                    else if (lMonth == nisan.ay)
                    {
                        gun = nisan.gun.ToString();
                    }
                    else if (lMonth == mayis.ay)
                    {
                        gun = mayis.gun.ToString();
                    }
                    else if (lMonth == haziran.ay)
                    {
                        gun = haziran.gun.ToString();
                    }
                    else if (lMonth == temmuz.ay)
                    {
                        gun = temmuz.gun.ToString();
                    }
                    else if (lMonth == agustos.ay)
                    {
                        gun = agustos.gun.ToString();
                    }
                    else if (lMonth == eylul.ay)
                    {
                        gun = eylul.gun.ToString();
                    }
                    else if (lMonth == ekim.ay)
                    {
                        gun = ekim.gun.ToString();
                    }
                    else if (lMonth == kasim.ay)
                    {
                        gun = kasim.gun.ToString();
                    }
                    else if (lMonth == aralik.ay)
                    {
                        gun = aralik.gun.ToString();
                    }
                    bitisTarihi = gun + "/" + lMonth.ToString() + "/" + lYear.ToString();
                    DateTime bas= DateTime.Parse(baslangicTarihi);
                    DateTime bit = DateTime.Parse(bitisTarihi);
                    TimeSpan gunS = bit - bas;
                    ViewBag.baslangic = baslangicTarihi;
                    ViewBag.bitis = bitisTarihi;
                    kalanGun= gunS.Days.ToString() ;
                    ViewBag.gun = kalanGun;
                    break;
                case 4:
                    int fYear1 = date.Year - tblFaturaPeriyodu.PeriyotSayisi;
                    int fYear2 = date.Year - 1;
                    DateTime fDateY = DateTime.Parse("01/01/" + fYear1.ToString());
                    DateTime lDateeY = DateTime.Parse("31/12/" + fYear2.ToString());
                    TimeSpan tsY = lDateeY - fDateY;
                    ViewBag.baslangic = fDateY.ToShortDateString();
                    ViewBag.bitis = lDateeY.ToShortDateString();
                    ViewBag.gun = tsY.Days.ToString();


                    break;
                default:
                    break;
            }
            ViewBag.id = 2;
            ViewBag.faturaList = fpm.TGetList().Where(x => x.Silindi == false);
            return View();
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
    }
}

