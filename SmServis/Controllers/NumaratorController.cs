using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmServis.Controllers
{
    public class NumaratorController : Controller
    {
        CariManager cm = new CariManager(new EfCariDal());
        NumaratorManager nm = new NumaratorManager(new EfNumaratorDal());
        NumaratorDegerManager ndm = new NumaratorDegerManager(new EfNumaratorDegerDal());
        // GET: /<controller>/
        public IActionResult Numarator(string numarator, string no)
        {
            ViewBag.tempNumaratorParca = cm.TGetList().Where(x => x.CariId == 0);
            ViewBag.numaratorList = nm.TGetList();
            ViewBag.numarator = numarator;
            ViewBag.no = no;
            return View();
        }
        [HttpPost]
        public IActionResult Numarator(string numaratorAciklama, int parcaUzunluğu, string onEk, int baslangicSayisi, int arttirmaAraligi, string doldurmaKarakteri, string sonEk, string numara, int sira1, int sira2, int sira3, int sira4, int sira5, int sira6, string karakter1, string karakter2, string karakter3, string karakter4, string karakter5)
        {
            Numarator numarator = new Numarator();
            NumaratorDeger numaratorDeger = new NumaratorDeger();
            numarator.NumaratorAciklama = numaratorAciklama;
            numarator.OnEk = onEk;
            numarator.Sira1 = sira1;
            numarator.Sira2 = sira2;
            numarator.Sira3 = sira3;
            numarator.Sira4 = sira4;
            numarator.Sira5 = sira5;
            numarator.Sira6 = sira6;
            numarator.Karakter1 = karakter1;
            numarator.Karakter2 = karakter2;
            numarator.Karakter3 = karakter3;
            numarator.Karakter4 = karakter4;
            numarator.Karakter5 = karakter5;
            numarator.ArttirmaAraligi = arttirmaAraligi;
            numarator.BaslangicSayisi = baslangicSayisi;
            numarator.DoldurmaKarakteri = doldurmaKarakteri;
            numarator.ParcaUzunlugu = parcaUzunluğu;
            numarator.SonEk = sonEk;
            numaratorDeger.SimdikiDeger = 0;

            try
            {
                nm.TAdd(numarator);
                numaratorDeger.NumaratorId = numarator.NumaratorId;
                ndm.TAdd(numaratorDeger);
            }
            catch (Exception ex)
            {
                ViewBag.numarator = numara;
                return View(new { numarator = numara });
            }
            ViewBag.numaratorList = nm.TGetList();
            ViewBag.tempNumaratorParca = cm.TGetList().Where(x => x.CariId == 0);
            ViewBag.numarator = numara;
            return View(new { numarator = numara });
        }
        public IActionResult NumaraUret(int numaratorId)
        {
            var tblNumarator = nm.TGetByID(numaratorId);
            var tblNumaratorDeger = ndm.TGetList().Where(x => x.NumaratorId == numaratorId).FirstOrDefault();
            string no = "";
            string sira = "";
            int siraNo1 = Convert.ToInt32(tblNumarator.Sira1);
            int siraNo2 = Convert.ToInt32(tblNumarator.Sira2);
            int siraNo3 = Convert.ToInt32(tblNumarator.Sira3);
            int siraNo4 = Convert.ToInt32(tblNumarator.Sira4);
            int siraNo5 = Convert.ToInt32(tblNumarator.Sira5);
            int siraNo6 = Convert.ToInt32(tblNumarator.Sira6);
            int baslangic = 0;
            string sira1 = "";
            string sira2 = "";
            string sira3 = "";
            string sira4 = "";
            string sira5 = "";
            string sira6 = "";
            //if (tblNumarator.BaslangicSayisi == tblNumaratorDeger.SimdikiDeger)
            //{
            //    baslangic = tblNumarator.BaslangicSayisi;
            //}
            if (siraNo1 != 0)
            {
                switch (siraNo1)
                {
                    case 1:
                        sira1 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira1 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira1 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira1 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira1);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            if (siraNo2 != 0)
            {
                switch (siraNo2)
                {
                    case 1:
                        sira2 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira2 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira2 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        if (baslangic != 0)
                        {
                            sira2 = baslangic.ToString();
                        }
                        else
                        {
                            sira2 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();

                        }
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira2);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            if (siraNo3 != 0)
            {
                switch (siraNo3)
                {
                    case 1:
                        sira3 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira3 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira3 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        if (baslangic != 0)
                            sira3 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira3);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            if (siraNo4 != 0)
            {
                switch (siraNo4)
                {
                    case 1:
                        sira4 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira4 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira4 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira4 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira4);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            if (siraNo5 != 0)
            {
                switch (siraNo5)
                {
                    case 1:
                        sira5 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira5 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira5 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira5 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira5);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
            if (siraNo6 != 0)
            {
                switch (siraNo6)
                {
                    case 1:
                        sira6 = DateTime.Now.Day.ToString();
                        break;
                    case 2:
                        sira6 = DateTime.Now.Month.ToString();
                        break;
                    case 3:
                        sira6 = DateTime.Now.Year.ToString();
                        break;
                    case 4:
                        sira6 = (tblNumaratorDeger.SimdikiDeger + tblNumarator.ArttirmaAraligi).ToString();
                        tblNumaratorDeger.SimdikiDeger = Convert.ToInt32(sira6);
                        ndm.TUpdate(tblNumaratorDeger);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }


            no = tblNumarator.OnEk + sira1 + tblNumarator.Karakter1 + sira2 + tblNumarator.Karakter2 + sira3 + tblNumarator.Karakter3 + sira4 + tblNumarator.Karakter4 + sira5 + tblNumarator.Karakter5 + sira6 + tblNumarator.SonEk;
            tblNumarator.Numara += tblNumarator.ArttirmaAraligi;
            ViewBag.numaratorList = nm.TGetList();
            ViewBag.tempNumaratorParca = cm.TGetList().Where(x => x.CariId == 0);
            return RedirectToAction("Numarator", new { no = no });
        }
    }
}

