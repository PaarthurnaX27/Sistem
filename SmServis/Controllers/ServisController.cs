using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace SmServis.Controllers
{
    public class ServisController : Controller
    {
        #region Manager
        CariManager cm = new CariManager(new EfCariDal());
        ServisDepartmanManager sdptm = new ServisDepartmanManager(new EfServisDepartmanDal());
        ModulManager mm = new ModulManager(new EfModulDal());
        ServisTipiManager stm = new ServisTipiManager(new EfServisTipiDal());
        ServisSekliManager ssm = new ServisSekliManager(new EfServisSekliDal());
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        SonDurumManager sdm = new SonDurumManager(new EfSonDurumDal());
        OncelikManager om = new OncelikManager(new EfOncelikDal());
        ServisBilgiManager sbm = new ServisBilgiManager(new EfServisBilgiDal());
        ServisKalemManager skm = new ServisKalemManager(new EfServisKalemDal());
        IslemYeriManager iym = new IslemYeriManager(new EfIslemYeriDal());
        Modul_ServisDepartmanManager msdm = new Modul_ServisDepartmanManager(new EfModul_ServisDepartmanDal());
        TempServisKalemManager tskm = new TempServisKalemManager(new EfTempServisKalemDal());
        TempServisBilgiManager tsbm = new TempServisBilgiManager(new EfTempServisBilgiDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        SmServisContext db = new SmServisContext();

        #endregion
        private readonly ILogger<ServisController> _logger;

        public ServisController(ILogger<ServisController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ServisBilgileri(int sonDurumId)
        {
            Vb();
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            ViewBag.servisList = sbm.TGetList().Where(x => x.Silindi == false);
            if (sonDurumId != null)
            {
                ViewBag.servisList = sbm.TGetList().Where(x => x.SonDurumID == sonDurumId && x.Silindi == false);
            }
            try
            {
                var tbTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                var tbTempServis = tsbm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                foreach (var item in tbTempKalem)
                {
                    tskm.TDelete(item);
                }
                foreach (var item in tbTempServis)
                {
                    tsbm.TDelete(item);
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult ServisBilgileri(string cariId, string modulId, string departmanId, string sonDurumId, string servisSekliId, string servisTipiId, string departmanYetkili, string tarihAraligi,
            string chckBekle, string chckPlan, string chckDevam, string chckTamam, string chckKuyruk, string chckMusOnay, string chckMusBilgi, string chckIasBilgi,
            bool bBekle, bool bPlan, bool bDevam, bool bTamam, bool bKuyruk, bool bMusOnay, bool bMusBilgi, bool bIasBilgi, bool kapandi, bool silindi = false, bool mevcut = false)
        {

            departmanYetkili = (departmanYetkili == null) ? departmanYetkili = "" : departmanYetkili = departmanYetkili;
            cariId = (cariId == null) ? cariId = "" : cariId = cariId;
            modulId = (modulId == null) ? modulId = "" : modulId = modulId;
            departmanId = (departmanId == null) ? departmanId = "" : departmanId = departmanId;
            sonDurumId = (sonDurumId == null) ? sonDurumId = "" : sonDurumId = sonDurumId;
            servisTipiId = (servisTipiId == null) ? servisTipiId = "" : servisTipiId = servisTipiId;
            servisSekliId = (servisSekliId == null) ? servisSekliId = "" : servisSekliId = servisSekliId;
            chckBekle = (bBekle == false) ? chckBekle = "0" : chckBekle = chckBekle;
            chckPlan = (bPlan == false) ? chckPlan = "0" : chckPlan = chckPlan;
            chckDevam = (bDevam == false) ? chckDevam = "0" : chckDevam = chckDevam;
            chckTamam = (bTamam == false) ? chckTamam = "0" : chckTamam = chckTamam;
            chckKuyruk = (bKuyruk == false) ? chckKuyruk = "0" : chckKuyruk = chckKuyruk;
            chckMusOnay = (bMusOnay == false) ? chckMusOnay = "0" : chckMusOnay = chckMusOnay;
            chckMusBilgi = (bMusBilgi == false) ? chckMusBilgi = "0" : chckMusBilgi = chckMusBilgi;
            chckIasBilgi = (bIasBilgi == false) ? chckIasBilgi = "0" : chckIasBilgi = chckIasBilgi;
            string baslangicTarihi = tarihAraligi.Substring(0,10);
            string bitisTarihi = tarihAraligi.Substring(tarihAraligi.Length-10);
            ViewBag.beklemede = bBekle;
            ViewBag.planaAlindi = bPlan;
            ViewBag.devamEdiyor = bDevam;
            ViewBag.tamamlandi = bTamam;
            ViewBag.kuyrukta = bKuyruk;
            ViewBag.musOnayi = bMusOnay;
            ViewBag.musBilgi = bMusBilgi;
            ViewBag.iasBilgi = bIasBilgi;
            ViewBag.kapandi = kapandi;
            ViewBag.tumu = !kapandi;
            int chckBekle1 = Int32.Parse(chckBekle);
            int chckPlan1 = Int32.Parse(chckPlan);
            int chckDevam1 = Int32.Parse(chckDevam);
            int chckTamam1 = Int32.Parse(chckTamam);
            int chckKuyruk1 = Int32.Parse(chckKuyruk);
            int chckMusOnay1 = Int32.Parse(chckMusOnay);
            int chckMusBilgi1 = Int32.Parse(chckMusBilgi);
            int chckIasBilgi1 = Int32.Parse(chckIasBilgi);
            ViewBag.chckSilindi = silindi;
            ViewBag.chckMevcut = mevcut;
            ViewBag.departmanYetkili = departmanYetkili;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            string ulkeAdi = "";
            Vb();
            var tblServis = sbm.TGetList().Where(x => x.CariId.ToString().Contains(cariId) &&
            x.ModulId.ToString().Contains(modulId) &&
            x.ServisDepartmanId.ToString().Contains(departmanId) &&
            x.SonDurumID.ToString().Contains(sonDurumId) &&
            x.ServisSekliId.ToString().Contains(servisSekliId) &&
            x.ServisTipiId.ToString().Contains(servisTipiId) &&
            x.DepartmanYetkilisi.Contains(departmanYetkili) &&
            x.Kapandi==kapandi&&
            x.TarihSaat.Date>=DateTime.Parse(baslangicTarihi)&&
            x.TarihSaat.Date<=DateTime.Parse(bitisTarihi)&&
            x.SonDurumID == chckBekle1 ||
            x.SonDurumID == chckPlan1 ||
            x.SonDurumID == chckDevam1 ||
            x.SonDurumID == chckTamam1 ||
            x.SonDurumID == chckKuyruk1 ||
            x.SonDurumID == chckMusOnay1 ||
            x.SonDurumID == chckMusBilgi1 ||
            x.SonDurumID == chckIasBilgi1);
            ViewBag.servisList = tblServis;
            ViewBag.cariId = cariId;
            ViewBag.tarihAraligi = baslangicTarihi + " - " + bitisTarihi;
            if (cariId != "")
            {
                ViewBag.cariAdi = cm.TGetByID(Int32.Parse(cariId)).CariAdi;
            }
            ViewBag.modulId = modulId;
            if (modulId != "")
            {
                ViewBag.modulAdi = mm.TGetByID(Int32.Parse(modulId)).ModulAdi;
            }
            ViewBag.departmanId = departmanId;
            if (departmanId != "")
            {
                ViewBag.departmanAdi = sdptm.TGetByID(Int32.Parse(departmanId)).ServisDepartmanAdi;
            }
            ViewBag.sonDurumId = sonDurumId;
            if (sonDurumId != "")
            {
                ViewBag.sonDurumAciklama = sdm.TGetByID(Int32.Parse(sonDurumId)).SonDurumAciklama;
            }
            ViewBag.servisSekliId = servisSekliId;
            if (servisSekliId != "")
            {
                ViewBag.servisSekliAciklama = ssm.TGetByID(Int32.Parse(servisSekliId)).ServisSekliAciklama;
            }
            ViewBag.servisTipiId = servisTipiId;
            if (servisTipiId != "")
            {
                ViewBag.servisTipiAciklama = stm.TGetByID(Int32.Parse(servisTipiId)).ServisTipiAciklama;
            }

            ViewBag.departmanYetkili = departmanYetkili;
            // if (ulkeId != "")
            // {
            //     ulkeAdi = um.TGetByID(Int32.Parse(ulkeId)).UlkeAdi;
            //     ViewBag.ulkeAdi = ulkeAdi;
            // }
            // ViewBag.ulkeId = ulkeId;
            // ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
            // mevcut = !mevcut;
            // if (ulkeId == "")
            // {
            //     var tblSehir = sm.TGetList().Where(x => x.SehirAdi.ToString().ToUpper().Contains(sehirAdi) && x.PlakaKodu.StartsWith(plakaKodu) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi == silindi).OrderBy(x => x.SehirAdi);
            //     ViewBag.sehirList = tblSehir;
            //     if (tblSehir.ToList().Count == 0)
            //     {
            //         ViewBag.sehirList = sm.TGetList().Where(x => x.SehirAdi == "none");
            //     }
            // }
            // else
            // {
            //     var tblSehir = sm.TGetList().Where(x => x.SehirAdi.Contains(sehirAdi) && x.PlakaKodu.StartsWith(plakaKodu) && x.TelefonKodu.StartsWith(telefonKodu) && x.Silindi == silindi && x.UlkeId == Int32.Parse(ulkeId)).OrderBy(x => x.SehirAdi);
            //     ViewBag.sehirList = tblSehir;
            // }
            return View();
        }

        [HttpGet]
        public IActionResult ServisGor(int id)
        {
            Vb();
            ViewBag.kalemList = skm.TGetList().Where(x => x.ServisId == id);
            ViewBag.id = id;
            return View();
        }
        public IActionResult ServisFormu()
        {
            Vb();
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var tblTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
            var girilenSure = 0;
            foreach (var item in tblTempKalem)
            {
                girilenSure += Convert.ToInt32(item.Sure);
            }
            ViewBag.girilenSure = girilenSure.ToString();
            ViewBag.tempKalemList = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
            var servisSiraNo = sbm.TGetList().Count;
            if (servisSiraNo == 0)
            {
                ViewBag.servisSiraNo = "00001";
                HttpContext.Session.SetString("ServisSiraNo", "00001");
            }
            else
            {
                var siraNo = sbm.TGetList().OrderByDescending(x => x.ServisId).FirstOrDefault().ServisNo.Substring(sbm.TGetList().OrderByDescending(x => x.ServisNo).FirstOrDefault().ServisNo.Length - 5);
                ViewBag.servisSiraNo = (Int32.Parse(siraNo) + 1).ToString("00000");
                HttpContext.Session.SetString("ServisSiraNo", (Int32.Parse(siraNo) + 1).ToString("00000"));
            }
            var tbTempServis = tsbm.TGetList().Where(x => x.SonDegistiren == kullaniciId).FirstOrDefault();
            if (tbTempServis != null)
            {
                var cariNo = cm.TGetByID(tsbm.TGetList().OrderBy(x => x.TempServisId).LastOrDefault().CariId).HesapKodu;
                ViewBag.cariNo = cariNo;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TempServisEkle(TempServisBilgi tempServisBilgi, string bitir)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var kullanici = km.TGetByID(kullaniciId);
            if (bitir != "1")
            {
                try
                {
                    tempServisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                    tempServisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
                    // tempServisBilgi.OlusturulmaTarih = DateTime.UtcNow.Date;
                    // tempServisBilgi.SonDegistirmeTarih = DateTime.UtcNow.Date;
                    tempServisBilgi.SonDegistiren = kullaniciId;
                    tempServisBilgi.Olusturan = kullaniciId;
                    tsbm.TAdd(tempServisBilgi);
                    // var tblTempServis = tsbm.TGetList().OrderByDescending(x=>x.TempServisId).FirstOrDefault();
                    // if (tblTempServis != null)
                    // {

                    //         tsbm.TDelete(tblTempServis);

                    // }
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            else
            {
                try
                {
                    ServisBilgi servisBilgi = new ServisBilgi();
                    servisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                    servisBilgi.CariId = tempServisBilgi.CariId;
                    servisBilgi.DepartmanYetkilisi = tempServisBilgi.DepartmanYetkilisi;
                    servisBilgi.FTSuresi = tempServisBilgi.FTSuresi;
                    servisBilgi.GercekSure = tempServisBilgi.GercekSure;
                    servisBilgi.GirilenSure = tempServisBilgi.GirilenSure;
                    servisBilgi.Kapandi = tempServisBilgi.Kapandi;
                    servisBilgi.Konu = tempServisBilgi.Konu;
                    servisBilgi.ModulId = tempServisBilgi.ModulId;
                    servisBilgi.MusteriOnayi = tempServisBilgi.MusteriOnayi;
                    servisBilgi.SonDegistiren = kullaniciId;
                    servisBilgi.Olusturan = kullaniciId;
                    servisBilgi.SonDegistirmeTarih = DateTime.UtcNow;
                    servisBilgi.OlusturulmaTarih = DateTime.UtcNow;
                    servisBilgi.OncelikId = tempServisBilgi.OncelikId;
                    servisBilgi.PersonelId = tempServisBilgi.PersonelId;
                    servisBilgi.PlanlananTarih = tempServisBilgi.PlanlananTarih;
                    servisBilgi.ServisDepartmanId = tempServisBilgi.ServisDepartmanId;
                    var isExist = sbm.TGetList().Where(x => x.ServisNo == tempServisBilgi.ServisNo).FirstOrDefault();
                    if (isExist != null)
                    {
                        var siraNo = isExist.ServisNo.Substring(isExist.ServisNo.Length - 5);
                        var siraNoNew = (Int32.Parse(siraNo) + 1).ToString("00000");
                        var servisNo = cm.TGetByID(tempServisBilgi.CariId).HesapKodu + "-" + siraNoNew;
                        servisBilgi.ServisNo = servisNo;
                    }
                    else
                    {
                        servisBilgi.ServisNo = tempServisBilgi.ServisNo;
                    }
                    servisBilgi.ServisSekliId = tempServisBilgi.ServisSekliId;
                    servisBilgi.ServisTipiId = tempServisBilgi.ServisTipiId;
                    servisBilgi.SonDurumID = tempServisBilgi.SonDurumID;
                    servisBilgi.SonDurumTarihi = tempServisBilgi.SonDurumTarihi;
                    servisBilgi.TahminiSure = tempServisBilgi.TahminiSure;
                    servisBilgi.TarihSaat = tempServisBilgi.TarihSaat;
                    servisBilgi.TSuresi = tempServisBilgi.TSuresi;
                    servisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
                    sbm.TAdd(servisBilgi);
                    var tblTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                    foreach (var item in tblTempKalem)
                    {
                        var tblServis = sbm.TGetList().Where(x => x.ServisNo == servisBilgi.ServisNo).FirstOrDefault();
                        ServisKalem servisKalem = new ServisKalem();
                        servisKalem.BaslamaZamani = item.BaslamaZamani;
                        servisKalem.GenelAciklama = item.GenelAciklama;
                        servisKalem.PersonelId = item.PersonelId;
                        servisKalem.IslemYeriId = item.IslemYeriId;
                        servisKalem.SonDurumId = item.SonDurumId;
                        servisKalem.BitisZamani = item.BaslamaZamani;
                        servisKalem.Sure = item.Sure;
                        servisKalem.Aciklama = item.Aciklama;
                        servisKalem.ServisId = tblServis.ServisId;
                        var servisNo = skm.TGetList().Count;
                        if (servisNo == 0)
                        {
                            servisKalem.ServisKalemNo = "100001";
                            HttpContext.Session.SetString("ServisNo", "100001");
                        }
                        else
                        {
                            servisKalem.ServisKalemNo = (Int32.Parse(skm.TGetList().OrderByDescending(x => x.ServisKalemNo).FirstOrDefault().ServisKalemNo) + 1).ToString();
                            HttpContext.Session.SetString("HesapKodu", (Int32.Parse(skm.TGetList().OrderByDescending(x => x.ServisKalemNo).FirstOrDefault().ServisKalemNo) + 1).ToString());
                        }
                        skm.TAdd(servisKalem);
                        tskm.TDelete(item);
                    }
                    var tbTempServis = tsbm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                    foreach (var item in tbTempServis)
                    {
                        tsbm.TDelete(item);
                    }
                    return RedirectToAction("ServisBilgileri");

                }
                catch (Exception Ex)
                {
                    TempData["error"] = "err";
                    return RedirectToAction("ServisFormu");
                }
            }

        }
        [HttpPost]
        public async Task<IActionResult> TempServisEkleWizard(TempServisBilgi tempServisBilgi, string bitir, string kalemAciklamaWL, string kalemGenelAciklamaWL, string kalemSureWL, int kalemSonDurumIdWL, int kalemIslemYeriIdWL, string kalemIslemYapanWL, string kalemBitisTarihWL, string kalemBaslangicTarihWL)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var kullanici = km.TGetByID(kullaniciId);
            if (bitir != "1")
            {
                try
                {
                    tempServisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                    tempServisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
                    // tempServisBilgi.OlusturulmaTarih = DateTime.UtcNow.Date;
                    // tempServisBilgi.SonDegistirmeTarih = DateTime.UtcNow.Date;
                    tempServisBilgi.SonDegistiren = kullaniciId;
                    tempServisBilgi.Olusturan = kullaniciId;
                    tsbm.TAdd(tempServisBilgi);
                    TempData["modal"] = "0";
                    // var tblTempServis = tsbm.TGetList().OrderByDescending(x=>x.TempServisId).FirstOrDefault();
                    // if (tblTempServis != null)
                    // {

                    //         tsbm.TDelete(tblTempServis);

                    // }
                    TempServisKalem tempServisKalem = new TempServisKalem();
                    tempServisKalem.Aciklama = kalemAciklamaWL;
                    //tempServisKalem.BaslamaZamani =  kalemBaslangicTarihWL;
                    //tempServisKalem.BitisZamani = kalemBitisTarihWL;
                    //DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                    //string baslangic = DateTimeOffset.Parse( kalemBaslangicTarihWL).ToString("dd-MM-yyyyTHH:mm ");
                    //string bitis = DateTimeOffset.Parse(kalemBitisTarihWL).ToString("dd-MM-yyyyTHH:mm");
                    if (kalemBaslangicTarihWL != null)
                    {

                        tempServisKalem.BaslamaZamani = DateTime.Parse(kalemBaslangicTarihWL);
                    }
                    if (kalemBitisTarihWL != null)
                    {
                        tempServisKalem.BitisZamani = DateTime.Parse(kalemBitisTarihWL);
                    }

                    tempServisKalem.GenelAciklama = kalemGenelAciklamaWL;
                    tempServisKalem.IslemYeriId = kalemIslemYeriIdWL;
                    tempServisKalem.Olusturan = kullaniciId;
                    tempServisKalem.PersonelId = pm.TGetList().Where(x => x.PersonelKodu == km.TGetByID(kullaniciId).KullaniciKodu).FirstOrDefault().PersonelId;
                    tempServisKalem.SonDegistiren = kullaniciId;
                    tempServisKalem.SonDurumId = kalemSonDurumIdWL;
                    tempServisKalem.Sure = kalemSureWL;

                    tskm.TAdd(tempServisKalem);
                    return RedirectToAction("ServisFormu");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            else
            {
                try
                {
                    ServisBilgi servisBilgi = new ServisBilgi();
                    servisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                    servisBilgi.CariId = tempServisBilgi.CariId;
                    servisBilgi.DepartmanYetkilisi = tempServisBilgi.DepartmanYetkilisi;
                    servisBilgi.FTSuresi = tempServisBilgi.FTSuresi;
                    servisBilgi.GercekSure = tempServisBilgi.GercekSure;
                    servisBilgi.GirilenSure = tempServisBilgi.GirilenSure;
                    servisBilgi.Kapandi = tempServisBilgi.Kapandi;
                    servisBilgi.Konu = tempServisBilgi.Konu;
                    servisBilgi.ModulId = tempServisBilgi.ModulId;
                    servisBilgi.MusteriOnayi = tempServisBilgi.MusteriOnayi;
                    servisBilgi.SonDegistiren = kullaniciId;
                    servisBilgi.Olusturan = kullaniciId;
                    servisBilgi.SonDegistirmeTarih = DateTime.UtcNow;
                    servisBilgi.OlusturulmaTarih = DateTime.UtcNow;
                    servisBilgi.OncelikId = tempServisBilgi.OncelikId;
                    servisBilgi.PersonelId = tempServisBilgi.PersonelId;
                    servisBilgi.PlanlananTarih = tempServisBilgi.PlanlananTarih;
                    servisBilgi.ServisDepartmanId = tempServisBilgi.ServisDepartmanId;
                    var isExist = sbm.TGetList().Where(x => x.ServisNo == tempServisBilgi.ServisNo).FirstOrDefault();
                    if (isExist != null)
                    {
                        var siraNo = isExist.ServisNo.Substring(isExist.ServisNo.Length - 5);
                        var siraNoNew = (Int32.Parse(siraNo) + 1).ToString("00000");
                        var servisNo = cm.TGetByID(tempServisBilgi.CariId).HesapKodu + "-" + siraNoNew;
                        servisBilgi.ServisNo = servisNo;
                    }
                    else
                    {
                        servisBilgi.ServisNo = tempServisBilgi.ServisNo;
                    }
                    servisBilgi.ServisSekliId = tempServisBilgi.ServisSekliId;
                    servisBilgi.ServisTipiId = tempServisBilgi.ServisTipiId;
                    servisBilgi.SonDurumID = tempServisBilgi.SonDurumID;
                    servisBilgi.SonDurumTarihi = tempServisBilgi.SonDurumTarihi;
                    servisBilgi.TahminiSure = tempServisBilgi.TahminiSure;
                    servisBilgi.TarihSaat = tempServisBilgi.TarihSaat;
                    servisBilgi.TSuresi = tempServisBilgi.TSuresi;
                    servisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
                    sbm.TAdd(servisBilgi);
                    var tblTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                    foreach (var item in tblTempKalem)
                    {
                        var tblServis = sbm.TGetList().Where(x => x.ServisNo == servisBilgi.ServisNo).FirstOrDefault();
                        ServisKalem servisKalem = new ServisKalem();
                        servisKalem.BaslamaZamani = item.BaslamaZamani;
                        servisKalem.GenelAciklama = item.GenelAciklama;
                        servisKalem.PersonelId = item.PersonelId;
                        servisKalem.IslemYeriId = item.IslemYeriId;
                        servisKalem.SonDurumId = item.SonDurumId;
                        servisKalem.BitisZamani = item.BaslamaZamani;
                        servisKalem.Sure = item.Sure;
                        servisKalem.Aciklama = item.Aciklama;
                        servisKalem.ServisId = tblServis.ServisId;
                        var servisNo = skm.TGetList().Count;
                        if (servisNo == 0)
                        {
                            servisKalem.ServisKalemNo = "100001";
                            HttpContext.Session.SetString("ServisNo", "100001");
                        }
                        else
                        {
                            servisKalem.ServisKalemNo = (Int32.Parse(skm.TGetList().OrderByDescending(x => x.ServisKalemNo).FirstOrDefault().ServisKalemNo) + 1).ToString();
                            HttpContext.Session.SetString("HesapKodu", (Int32.Parse(skm.TGetList().OrderByDescending(x => x.ServisKalemNo).FirstOrDefault().ServisKalemNo) + 1).ToString());
                        }
                        skm.TAdd(servisKalem);
                        tskm.TDelete(item);
                    }
                    var tbTempServis = tsbm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                    foreach (var item in tbTempServis)
                    {
                        tsbm.TDelete(item);
                    }
                    return RedirectToAction("ServisBilgileri");

                }
                catch (Exception Ex)
                {
                    TempData["error"] = "err";
                    return RedirectToAction("ServisFormu");
                }
            }

        }

        [HttpPost]
        public IActionResult TempKalemEkle(DateTime kalemBaslangicTarih, string kalemGenelAciklama, int kalemIslemYapanId, int kalemIslemYeriId, int kalemSonDurumId, string kalemBitisTarih, string kalemSure, string kalemAciklamaEkle)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var kullanici = pm.TGetList().Where(x => x.PersonelKodu == km.TGetByID(kullaniciId).KullaniciKodu).FirstOrDefault();
            try
            {
                TempServisKalem tempServisKalem = new TempServisKalem();
                tempServisKalem.BaslamaZamani = kalemBaslangicTarih;
                tempServisKalem.GenelAciklama = kalemGenelAciklama;
                tempServisKalem.PersonelId = kullanici.PersonelId;
                tempServisKalem.IslemYeriId = kalemIslemYeriId;
                tempServisKalem.SonDurumId = kalemSonDurumId;
                tempServisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                tempServisKalem.Sure = kalemSure;
                tempServisKalem.Aciklama = kalemAciklamaEkle;
                tempServisKalem.SonDegistiren = kullaniciId;
                tempServisKalem.Olusturan = kullaniciId;
                // tempServisKalem.SonDegistirmeTarih=DateTime.UtcNow.Date;
                // tempServisKalem.OlusturulmaTarih=DateTime.UtcNow.Date;
                tskm.TAdd(tempServisKalem);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Kalem Ekleme İşlemi Başarısız Oldu";
                return RedirectToAction("ServisFormu");
            }

            return RedirectToAction("ServisFormu");
        }


        [HttpPost]
        public IActionResult TempKalemDuzenle(int id, string kalemBaslangicTarih, string kalemGenelAciklama, int kalemIslemYapanId, int kalemIslemYeriId, int kalemSonDurumId, string kalemBitisTarih, string kalemSure, string kalemAciklamaDuzenle)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                var kullanici = pm.TGetList().Where(x => x.PersonelKodu == km.TGetByID(kullaniciId).KullaniciKodu).FirstOrDefault();
                var tempServisKalem = tskm.TGetByID(id);
                tempServisKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
                tempServisKalem.GenelAciklama = kalemGenelAciklama;
                tempServisKalem.PersonelId = kullanici.PersonelId;
                tempServisKalem.IslemYeriId = kalemIslemYeriId;
                tempServisKalem.SonDurumId = kalemSonDurumId;
                tempServisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                tempServisKalem.Sure = kalemSure;
                tempServisKalem.Aciklama = kalemAciklamaDuzenle;
                tskm.TUpdate(tempServisKalem);
                return RedirectToAction("ServisFormu");
            }
            catch (Exception ex)
            {
                TempData["error"] = "err";
                return RedirectToAction("ServisFormu");
            }
        }

        [HttpGet]
        public IActionResult ServisGuncelle(int id)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            Vb();
            ViewBag.tempKalemList = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
            HttpContext.Session.SetInt32("ServisId", id);
            var tblTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
            var tblKalem = skm.TGetList().Where(x => x.ServisId == id);
            var tblServis = sbm.TGetByID(id);
            int girilenSure = 0;
            foreach (var item in tblKalem)
            {
                var isExist = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.ServisKalemNo == item.ServisKalemNo);
                if (isExist.Count()==0)
                {

                girilenSure += Int32.Parse(item.Sure);
                }
            }
            foreach (var item in tblTempKalem)
            {
                girilenSure += Int32.Parse(item.Sure);
            }
            ViewBag.servisId = id;
            //ViewBag.cariNo = cm.TGetByID(tblServis.CariId).HesapKodu;
            // string siraNo=sbm.TGetByID(id).ServisNo.Substring(sbm.TGetByID(id).ServisNo.Length-5);
            // ViewBag.servisNo =cm.TGetByID(sbm.TGetByID(id).CariId).HesapKodu+"-"+siraNo;
            ViewBag.servisNo = sbm.TGetByID(id).ServisNo;

            //ViewBag.modulList=mm.TGetList().Where(x=>x.ServisDepartmanId== tblServis.ServisDepartmanId && x.Silindi==false);
            ViewBag.cariId = tblServis.CariId;
            ViewBag.cariAdi = cm.TGetByID(tblServis.CariId).CariAdi;
            ViewBag.servisDepartmanId = tblServis.ServisDepartmanId;
            ViewBag.servisDepartmanAdi = sdptm.TGetByID(tblServis.ServisDepartmanId).ServisDepartmanAdi;
            ViewBag.ModulId = tblServis.ModulId;
            ViewBag.modulAdi = mm.TGetByID(tblServis.ModulId).ModulAdi;
            ViewBag.departmanYetkilisi = tblServis.DepartmanYetkilisi;
            ViewBag.konu = tblServis.Konu;
            ViewBag.oncelikId = tblServis.OncelikId;
            ViewBag.oncelikAciklama = om.TGetByID(tblServis.OncelikId).OncelikAciklama;
            ViewBag.servisSekliId = tblServis.ServisSekliId;
            ViewBag.servisSekliAciklama = ssm.TGetByID(tblServis.ServisSekliId).ServisSekliAciklama;
            ViewBag.servisTipiId = tblServis.ServisTipiId;
            ViewBag.servisTipiAciklama = stm.TGetByID(tblServis.ServisTipiId).ServisTipiAciklama;
            ViewBag.personelId = tblServis.PersonelId;
            ViewBag.personelAdi = pm.TGetByID(tblServis.PersonelId).PersonelAdi;
            ViewBag.personelAdi2 = pm.TGetByID(tblServis.PersonelId).PersonelAdi2;
            ViewBag.personelSoyadi = pm.TGetByID(tblServis.PersonelId).PersonelSoyadi;
            ViewBag.tSuresi = tblServis.TSuresi;
            ViewBag.fTSuresi = tblServis.FTSuresi;
            ViewBag.tarihSaat = tblServis.TarihSaat;
            ViewBag.planlananTarih = tblServis.PlanlananTarih;
            ViewBag.tahminiSure = tblServis.TahminiSure;
            ViewBag.gercekSure = tblServis.GercekSure;
            ViewBag.girilenSure = girilenSure;
            ViewBag.sonDurumTarihi = tblServis.SonDurumTarihi;
            ViewBag.sonDurumId = tblServis.SonDurumID;
            ViewBag.SonDurumAciklama = sdm.TGetByID(tblServis.SonDurumID).SonDurumAciklama;
            ViewBag.kalemList = tblKalem;
            return View();


        }
        public IActionResult TumunuGuncelle(ServisBilgi servisBilgi, string kalemBaslangicTarih, string kalemGenelAciklama, int kalemIslemYapanId, int kalemIslemYeriId, int kalemSonDurumId, string kalemBitisTarih, string kalemSure, string kalemAciklama)
        {
            try
            {
                ServisKalem servisKalem = new ServisKalem();
                servisKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
                servisKalem.GenelAciklama = kalemGenelAciklama;
                servisKalem.PersonelId = kalemIslemYapanId;
                servisKalem.IslemYeriId = kalemIslemYeriId;
                servisKalem.SonDurumId = kalemSonDurumId;
                servisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                servisKalem.Sure = kalemSure;
                servisKalem.Aciklama = kalemAciklama;
                servisBilgi.ServisId = (int)HttpContext.Session.GetInt32("ServisId");
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
                servisBilgi.SonDegistiren = kullanici;
                servisBilgi.Olusturan = kullanici;
                //servisBilgi.SonDegistirmeTarih = DateTime.UtcNow.Date;
                //servisBilgi.OlusturulmaTarih = DateTime.UtcNow;
                servisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                servisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
                sbm.TUpdate(servisBilgi);
                var tblServis = sbm.TGetList().Where(x => x.ServisNo == servisBilgi.ServisNo).FirstOrDefault();
                servisKalem.ServisId = tblServis.ServisId;
                skm.TAdd(servisKalem);
                return RedirectToAction("ServisBilgileri");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ServisFormu");
            }
        }




        //////////////////////////////////////GÜNCELLEME SAYFASI//////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult> TempServisEkleG(TempServisBilgi tempServisBilgi, string bitir, int servisId)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            if (bitir != "1")
            {
                try
                {
                    tempServisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                    tempServisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
                    tempServisBilgi.SonDegistiren = kullaniciId;
                    
                    tsbm.TAdd(tempServisBilgi);
                    // var tblTempServis = tsbm.TGetList().OrderByDescending(x=>x.TempServisId).FirstOrDefault();
                    // if (tblTempServis != null)
                    // {

                    //         tsbm.TDelete(tblTempServis);

                    // }
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            else
            {
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");

                try
                {
                    ServisBilgi servisBilgi = new ServisBilgi();
                    servisBilgi.ServisNo = tempServisBilgi.ServisNo;
                    servisId = db.ServisBilgis.Where(x => x.ServisNo == servisBilgi.ServisNo).FirstOrDefault().ServisId;
                    servisBilgi.ServisId = servisId;
                    servisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
                    servisBilgi.CariId = tempServisBilgi.CariId;
                    servisBilgi.DepartmanYetkilisi = tempServisBilgi.DepartmanYetkilisi;
                    servisBilgi.FTSuresi = tempServisBilgi.FTSuresi;
                    servisBilgi.GercekSure = tempServisBilgi.GercekSure;
                    servisBilgi.GirilenSure = tempServisBilgi.GirilenSure;
                    servisBilgi.Kapandi = tempServisBilgi.Kapandi;
                    servisBilgi.Konu = tempServisBilgi.Konu;
                    servisBilgi.ModulId = tempServisBilgi.ModulId;
                    servisBilgi.MusteriOnayi = tempServisBilgi.MusteriOnayi;
                    servisBilgi.SonDegistiren = kullanici;
                    servisBilgi.Olusturan = db.ServisBilgis.Where(x=>x.ServisNo==tempServisBilgi.ServisNo).FirstOrDefault().Olusturan;
                    servisBilgi.SonDegistirmeTarih = DateTime.UtcNow;
                    servisBilgi.OlusturulmaTarih = DateTime.UtcNow;
                    servisBilgi.OncelikId = tempServisBilgi.OncelikId;
                    servisBilgi.PersonelId = tempServisBilgi.PersonelId;
                    servisBilgi.PlanlananTarih = tempServisBilgi.PlanlananTarih;
                    servisBilgi.ServisDepartmanId = tempServisBilgi.ServisDepartmanId;
                    servisBilgi.ServisSekliId = tempServisBilgi.ServisSekliId;
                    servisBilgi.ServisTipiId = tempServisBilgi.ServisTipiId;
                    servisBilgi.SonDurumID = tempServisBilgi.SonDurumID;
                    servisBilgi.SonDurumTarihi = tempServisBilgi.SonDurumTarihi;
                    servisBilgi.TahminiSure = tempServisBilgi.TahminiSure;
                    servisBilgi.TarihSaat = tempServisBilgi.TarihSaat;
                    servisBilgi.TSuresi = tempServisBilgi.TSuresi;
                    servisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();

                    sbm.TUpdate(servisBilgi);
                    var tblTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                    foreach (var item in tblTempKalem)
                    {

                        var tblServisKalem = skm.TGetList().Where(x => x.ServisKalemNo == item.ServisKalemNo);
                        if (tblServisKalem.Count() != 0)
                        {
                            if (item.ServisKalemNo == tblServisKalem.FirstOrDefault().ServisKalemNo)
                            {

                                tblServisKalem.FirstOrDefault().BaslamaZamani = item.BaslamaZamani;
                                tblServisKalem.FirstOrDefault().GenelAciklama = item.GenelAciklama;
                                tblServisKalem.FirstOrDefault().PersonelId = item.PersonelId;
                                tblServisKalem.FirstOrDefault().IslemYeriId = item.IslemYeriId;
                                tblServisKalem.FirstOrDefault().SonDurumId = item.SonDurumId;
                                tblServisKalem.FirstOrDefault().BitisZamani = item.BaslamaZamani;
                                tblServisKalem.FirstOrDefault().Sure = item.Sure;
                                tblServisKalem.FirstOrDefault().Aciklama = item.Aciklama;
                                //tblServisKalem.KalemId = tblServis.ServisId;
                                skm.TUpdate(tblServisKalem.FirstOrDefault());
                            }

                        }
                        else
                        {

                            var tblServis = sbm.TGetList().Where(x => x.ServisNo == servisBilgi.ServisNo).FirstOrDefault();
                            ServisKalem servisKalem = new ServisKalem();
                            servisKalem.BaslamaZamani = item.BaslamaZamani;
                            servisKalem.GenelAciklama = item.GenelAciklama;
                            servisKalem.PersonelId = item.PersonelId;
                            servisKalem.IslemYeriId = item.IslemYeriId;
                            servisKalem.SonDurumId = item.SonDurumId;
                            servisKalem.BitisZamani = item.BaslamaZamani;
                            servisKalem.Sure = item.Sure;
                            servisKalem.Aciklama = item.Aciklama;
                            servisKalem.ServisId = tblServis.ServisId;
                            var servisNo = skm.TGetList().Count;
                            if (servisNo == 0)
                            {
                                servisKalem.ServisKalemNo = "100001";
                                HttpContext.Session.SetString("ServisNo", "100001");
                            }
                            else
                            {
                                servisKalem.ServisKalemNo = (Int32.Parse(skm.TGetList().OrderByDescending(x => x.ServisKalemNo).FirstOrDefault().ServisKalemNo) + 1).ToString();
                                HttpContext.Session.SetString("HesapKodu", (Int32.Parse(skm.TGetList().OrderByDescending(x => x.ServisKalemNo).FirstOrDefault().ServisKalemNo) + 1).ToString());
                            }
                            skm.TAdd(servisKalem);
                        }
                        tskm.TDelete(item);
                    }
                    var tbTempServis = tsbm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                    foreach (var item in tbTempServis)
                    {
                        tsbm.TDelete(item);
                    }
                    return RedirectToAction("ServisBilgileri");

                }
                catch (Exception Ex)
                {
                    TempData["error"] = "err";
                    return RedirectToAction("ServisGuncelle", new { id = servisId });
                }
            }

        }

        [HttpPost]
        public IActionResult TempKalemEkleG(int servisId, string kalemBaslangicTarih, string kalemGenelAciklama, int kalemIslemYapanId, int kalemIslemYeriId, int kalemSonDurumId, string kalemBitisTarih, string kalemSure, string kalemAciklamaEkle)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var kullanici = pm.TGetList().Where(x => x.PersonelKodu == km.TGetByID(kullaniciId).KullaniciKodu).FirstOrDefault();
            TempServisKalem tempServisKalem = new TempServisKalem();
            tempServisKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
            tempServisKalem.GenelAciklama = kalemGenelAciklama;
            tempServisKalem.PersonelId = kullanici.PersonelId;
            tempServisKalem.IslemYeriId = kalemIslemYeriId;
            tempServisKalem.SonDurumId = kalemSonDurumId;
            tempServisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
            tempServisKalem.Sure = kalemSure;
            tempServisKalem.Aciklama = kalemAciklamaEkle;
            tempServisKalem.SonDegistiren = kullaniciId;
            tempServisKalem.Olusturan = kullaniciId;
            try
            {
                tskm.TAdd(tempServisKalem);
            }
            catch (Exception ex)
            {
                TempData["error"] = "err";
                return RedirectToAction("ServisGuncelle", new { id = servisId });
            }

            return RedirectToAction("ServisGuncelle", new { id = servisId });
        }

        [HttpPost]
        public IActionResult TempKalemDuzenleG(int servisId, int id, bool mevcutKalem, string kalemBaslangicTarih, string kalemGenelAciklama, int kalemIslemYapanId, int kalemIslemYeriId, int kalemSonDurumId, string kalemBitisTarih, string kalemSure, string kalemAciklamaDuzenle)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var kullanici = pm.TGetList().Where(x => x.PersonelKodu == km.TGetByID(kullaniciId).KullaniciKodu).FirstOrDefault();
            try
            {
                if (mevcutKalem == true)
                {
                    //var tempServisKalem = tskm.TGetByID(id);
                    var tblServisKalem = skm.TGetByID(id);
                    try
                    {
                        var kalemMevcut = tskm.TGetList().Where(x => x.ServisKalemNo == tblServisKalem.ServisKalemNo && x.SonDegistiren == kullaniciId).FirstOrDefault();
                        if (kalemMevcut == null)
                        {
                            var servisKalem = skm.TGetByID(id);
                            TempServisKalem tblTempKalem = new TempServisKalem();
                            tblTempKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
                            tblTempKalem.GenelAciklama = kalemGenelAciklama;
                            tblTempKalem.PersonelId = kullanici.PersonelId;
                            tblTempKalem.IslemYeriId = kalemIslemYeriId;
                            tblTempKalem.SonDurumId = kalemSonDurumId;
                            tblTempKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                            tblTempKalem.Sure = kalemSure;
                            tblTempKalem.Aciklama = kalemAciklamaDuzenle;
                            tblTempKalem.ServisKalemNo = servisKalem.ServisKalemNo;
                            tblTempKalem.SonDegistiren = kullaniciId;
                            tblTempKalem.Olusturan = kullaniciId;
                            tskm.TAdd(tblTempKalem);
                        }
                        else
                        {
                            var servisKalem = tskm.TGetList().Where(x => x.ServisKalemNo == tblServisKalem.ServisKalemNo && x.SonDegistiren == kullaniciId).FirstOrDefault();
                            servisKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
                            servisKalem.GenelAciklama = kalemGenelAciklama;
                            servisKalem.PersonelId = kullanici.PersonelId;
                            servisKalem.IslemYeriId = kalemIslemYeriId;
                            servisKalem.SonDurumId = kalemSonDurumId;
                            servisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                            servisKalem.Sure = kalemSure;
                            servisKalem.Aciklama = kalemAciklamaDuzenle;
                            servisKalem.SonDegistiren = kullaniciId;
                            tskm.TUpdate(servisKalem);
                        }

                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = "Kalem Güncellenirken Bir Hata Oluştu";
                        return RedirectToAction("ServisGuncelle", new { id = servisId });
                    }
                    // if (tempServisKalem == null)
                    // {
                    //     var kalemno = skm.TGetByID(id).ServisKalemNo;

                    //     var servisKalem = tskm.TGetList().Where(x => x.ServisKalemNo == kalemno).FirstOrDefault();
                    //     servisKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
                    //     servisKalem.GenelAciklama = kalemGenelAciklama;
                    //     servisKalem.PersonelId = kalemIslemYapanId;
                    //     servisKalem.IslemYeriId = kalemIslemYeriId;
                    //     servisKalem.SonDurumId = kalemSonDurumId;
                    //     servisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                    //     servisKalem.Sure = kalemSure;
                    //     servisKalem.Aciklama = kalemAciklamaDuzenle;
                    //     tskm.TUpdate(servisKalem);
                    // }
                    return RedirectToAction("ServisGuncelle", new { id = servisId });
                }
                else
                {
                    var tempServisKalem = tskm.TGetByID(id);
                    tempServisKalem.BaslamaZamani = DateTimeOffset.Parse(kalemBaslangicTarih).UtcDateTime;
                    tempServisKalem.GenelAciklama = kalemGenelAciklama;
                    tempServisKalem.PersonelId = kullanici.PersonelId;
                    tempServisKalem.IslemYeriId = kalemIslemYeriId;
                    tempServisKalem.SonDurumId = kalemSonDurumId;
                    tempServisKalem.BitisZamani = DateTimeOffset.Parse(kalemBitisTarih).UtcDateTime;
                    tempServisKalem.Sure = kalemSure;
                    tempServisKalem.Aciklama = kalemAciklamaDuzenle;
                    tskm.TUpdate(tempServisKalem);
                    return RedirectToAction("ServisGuncelle", new { id = servisId });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "err";
                return RedirectToAction("ServisGuncelle", new { id = servisId });
            }
        }
        ///////////////////////////////JAVA SCRIPT///////////////////////////////////////////

        public ActionResult ModulGetir(int departmanId)
        {
            var modul = msdm.TGetList().Where(x => x.ServisDepartmanId == departmanId);
            List<Modul> modulList = new List<Modul>();
            foreach (var item in modul)
            {
                modulList.Add(mm.TGetByID(item.ModulId));
            }
            ViewBag.modulList = modulList;
            return Json(modulList);
        }

        [HttpGet]
        public ActionResult HesapKoduGetir(int cariId)
        {
            var cari = cm.TGetByID(cariId);
            var hesapKodu = cari.HesapKodu;
            return Json(hesapKodu);
        }

        [HttpGet]
        public JsonResult ServisSiraGetir()
        {
            var servisSiraNo = sbm.TGetList().Count;
            string siraNo;
            if (servisSiraNo == 0)
            {
                siraNo = "00001";
                return Json(siraNo);
            }
            else
            {
                siraNo = sbm.TGetList().OrderByDescending(x => x.ServisId).FirstOrDefault().ServisNo.Substring(sbm.TGetList().OrderByDescending(x => x.ServisId).FirstOrDefault().ServisNo.Length - 5);
                siraNo = (Int32.Parse(siraNo) + 1).ToString("00000");

                return Json(siraNo);
            }
        }

        [HttpGet]
        public JsonResult KalemGetir(int kalemId)
        {
            var tempKalem = tskm.TGetByID(kalemId);
            ViewBag.sonDurumId = tempKalem.SonDurumId;
            ViewBag.sonDurumAciklama = sdm.TGetByID(tempKalem.SonDurumId).SonDurumAciklama;
            ViewBag.peronselId = tempKalem.PersonelId;
            ViewBag.personelAdi = pm.TGetByID(tempKalem.PersonelId).PersonelAdi;
            ViewBag.personelAdi2 = pm.TGetByID(tempKalem.PersonelId).PersonelAdi2;
            ViewBag.personelSoyadi = pm.TGetByID(tempKalem.PersonelId).PersonelSoyadi;
            ViewBag.islemYeriId = tempKalem.IslemYeriId;
            ViewBag.islemYeriAdi = iym.TGetByID(tempKalem.IslemYeriId).IslemYeriAdi;
            return Json(tempKalem);
        }
        [HttpGet]
        public JsonResult KalemGetirG(int kalemId)
        {
            var tblKalem = skm.TGetByID(kalemId);
            ViewBag.sonDurumId = tblKalem.SonDurumId;
            ViewBag.sonDurumAciklama = sdm.TGetByID(tblKalem.SonDurumId).SonDurumAciklama;
            ViewBag.peronselId = tblKalem.PersonelId;
            ViewBag.personelAdi = pm.TGetByID(tblKalem.PersonelId).PersonelAdi;
            ViewBag.personelAdi2 = pm.TGetByID(tblKalem.PersonelId).PersonelAdi2;
            ViewBag.personelSoyadi = pm.TGetByID(tblKalem.PersonelId).PersonelSoyadi;
            ViewBag.islemYeriId = tblKalem.IslemYeriId;
            ViewBag.islemYeriAdi = iym.TGetByID(tblKalem.IslemYeriId).IslemYeriAdi;
            return Json(tblKalem);
        }

        public IActionResult TempKalemSil(int id)
        {
            try
            {
                var tempKalem = tskm.TGetByID(id);
                tskm.TDelete(tempKalem);
                return RedirectToAction("ServisFormu");
            }
            catch (Exception ex)
            {
                TempData["error"] = "err";
                return RedirectToAction("ServisFormu");
            }
        }

        [HttpGet]
        public JsonResult KalanSureGetir(DateTime baslangicZamani, DateTime bitisZamani)
        {
            TimeSpan kalan = bitisZamani - baslangicZamani;
            var sure = kalan.TotalMinutes.ToString();
            return Json(sure);
        }
        [HttpGet]
        public JsonResult KalemAciklamaGetir(int kalemId)
        {
            var tempKalemAciklama = tskm.TGetByID(kalemId);
            return Json(tempKalemAciklama);
        }
        [HttpGet]
        public JsonResult KalemAciklamaGetirG(int kalemId)
        {
            var kalemAciklama = skm.TGetByID(kalemId);
            return Json(kalemAciklama);
        }
        [HttpGet]
        public JsonResult KalemAciklamaGetirGuncelle(int kalemId)
        {
            var tempKalemAciklama = tskm.TGetByID(kalemId).Aciklama;
            return Json(tempKalemAciklama);
        }
        [HttpGet]
        public JsonResult SonDurumGetir(int kalemId)
        {
            var tempKalem = tskm.TGetByID(kalemId);
            var sonDurum = sdm.TGetByID(tempKalem.SonDurumId);
            return Json(sonDurum);
        }
        [HttpGet]
        public JsonResult SonDurumGetirG(int kalemId)
        {
            var tblKalem = skm.TGetByID(kalemId);
            var sonDurum = sdm.TGetByID(tblKalem.SonDurumId);
            return Json(sonDurum);
        }
        [HttpGet]
        public JsonResult SonDurumList()
        {
            var tbSonDurum = sdm.TGetList().Where(x => x.Silindi == false);
            return Json(tbSonDurum);
        }
        [HttpGet]
        public JsonResult IslemYeriGetir(int kalemId)
        {
            var tempKalem = tskm.TGetByID(kalemId);
            var islemYeri = iym.TGetByID(tempKalem.IslemYeriId);
            return Json(islemYeri);
        }
        [HttpGet]
        public JsonResult IslemYeriGetirG(int kalemId)
        {
            var tblKalem = skm.TGetByID(kalemId);
            var islemYeri = iym.TGetByID(tblKalem.IslemYeriId);
            return Json(islemYeri);
        }
        [HttpGet]
        public JsonResult IslemYeriList()
        {
            var tbIslemYeri = iym.TGetList().Where(x => x.Silindi == false);
            return Json(tbIslemYeri);
        }
        [HttpGet]
        public JsonResult PersonelGetir(int kalemId)
        {
            var tempKalem = tskm.TGetByID(kalemId);
            var personel = pm.TGetByID(tempKalem.PersonelId);
            return Json(personel);
        }
        [HttpGet]
        public JsonResult PersonelGetirG(int kalemId)
        {
            var tblKalem = skm.TGetByID(kalemId);
            var personel = pm.TGetByID(tblKalem.PersonelId);
            return Json(personel);
        }
        [HttpGet]
        public JsonResult PersonelList()
        {
            var tbPersonel = pm.TGetList().Where(x => x.Silindi == false);
            return Json(tbPersonel);
        }
        [HttpGet]
        public JsonResult CariGetirW(int id)
        {
            var tbl = cm.TGetByID(id).CariAdi;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult CariListW()
        {
            var tbl = cm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult DepartmanGetirW(int id)
        {
            var tbl = sdptm.TGetByID(id).ServisDepartmanAdi;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult DepartmanListW()
        {
            var tbl = sdptm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult ModulGetirW(int id)
        {
            var tbl = mm.TGetByID(id).ModulAdi;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult ModulListW()
        {
            var tbl = mm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult OncelikGetirW(int id)
        {
            var tbl = om.TGetByID(id).OncelikAciklama;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult OncelikListW()
        {
            var tbl = om.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult ServisSekliGetirW(int id)
        {
            var tbl = ssm.TGetByID(id).ServisSekliAciklama;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult ServisSekliListW()
        {
            var tbl = ssm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult ServisTipiGetirW(int id)
        {
            var tbl = stm.TGetByID(id).ServisTipiAciklama;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult ServisTipiListW()
        {
            var tbl = stm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult SorumluGetirW(int id)
        {
            var tbl = pm.TGetByID(id);
            string personelAdi2 = "";
            if (tbl.PersonelAdi2 != null)
            {
                personelAdi2 = tbl.PersonelAdi2;
            }
            string personelAdi = tbl.PersonelAdi + " " + personelAdi2 + " " + tbl.PersonelSoyadi;
            return Json(personelAdi);
        }
        [HttpGet]
        public JsonResult SorumluListW()
        {
            var tbl = pm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult SonDurumGetirW(int id)
        {
            var tbl = sdm.TGetByID(id).SonDurumAciklama;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult SonDurumListW()
        {
            var tbl = sdm.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult IslemYeriGetirW(int id)
        {
            var tbl = iym.TGetByID(id).IslemYeriAdi;
            return Json(tbl);
        }
        [HttpGet]
        public JsonResult IslemYeriListW()
        {
            var tbl = iym.TGetList().Where(x => x.Silindi == false);
            return Json(tbl);
        }
        [HttpGet]
        public IActionResult SonDurumFilter(int id)
        {
            var filter = sbm.TGetList().Where(x => x.SonDurumID == id && x.Silindi == false);
            ViewBag.servisList = filter;
            return RedirectToAction("ServisBilgileri");
        }
        public IActionResult KaydetmedenCik()
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            try
            {
                var tbTempKalem = tskm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                foreach (var item in tbTempKalem)
                {
                    tskm.TDelete(item);
                }
                var tbTempServis = tsbm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
                foreach (var item in tbTempServis)
                {
                    tsbm.TDelete(item);
                }
                return RedirectToAction("ServisBilgileri", "Servis");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ServisBilgileri", "Servis");
            }
        }
        public void Vb()
        {
            ViewBag.cariList = cm.TGetList().Where(x => x.Silindi == false);
            ViewBag.servisDepartmanList = sdptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = pm.TGetList();
            ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
            ViewBag.servisTipiList = stm.TGetList().Where(x => x.Silindi == false);
            ViewBag.servisSekliList = ssm.TGetList().Where(x => x.Silindi == false);
            ViewBag.sonDurumList = sdm.TGetList().Where(x => x.Silindi == false);
            ViewBag.oncelikList = om.TGetList().Where(x => x.Silindi == false);
            ViewBag.islemYeriList = iym.TGetList().Where(x => x.Silindi == false);
            ViewBag.servisSiraNo = 1;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        // public IActionResult TumunuKaydet(ServisBilgi servisBilgi)
        // {
        //     try
        //     {
        //         var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
        //         servisBilgi.SonDegistiren = kullanici;
        //         servisBilgi.Olusturan = kullanici;
        //         servisBilgi.SonDegistirmeTarih = DateTime.UtcNow;
        //         servisBilgi.OlusturulmaTarih = DateTime.UtcNow;
        //         servisBilgi.Ay = DateTime.UtcNow.Date.Month.ToString();
        //         servisBilgi.Yil = DateTime.UtcNow.Date.Year.ToString();
        //         sbm.TAdd(servisBilgi);
        //         var tblServis = sbm.TGetList().Where(x => x.ServisNo == servisBilgi.ServisNo).FirstOrDefault();
        //         var tblTempKalem = tskm.TGetList();
        //         foreach (var item in tblTempKalem)
        //         {
        //             ServisKalem servisKalem = new ServisKalem();
        //             servisKalem.BaslamaZamani = item.BaslamaZamani;
        //             servisKalem.GenelAciklama = item.GenelAciklama;
        //             servisKalem.PersonelId = item.PersonelId;
        //             servisKalem.IslemYeriId = item.IslemYeriId;
        //             servisKalem.SonDurumId = item.SonDurumId;
        //             servisKalem.BitisZamani = item.BaslamaZamani;
        //             servisKalem.Sure = item.Sure;
        //             servisKalem.Aciklama = item.Aciklama;
        //             servisKalem.ServisId = tblServis.ServisId;
        //             skm.TAdd(servisKalem);
        //             tskm.TDelete(item);
        //         }
        //         return RedirectToAction("ServisBilgileri");
        //     }
        //     catch (Exception ex)
        //     {
        //         return RedirectToAction("ServisFormu");
        //     }
        // }
    }
}