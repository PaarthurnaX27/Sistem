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
using Newtonsoft.Json;

namespace SmServis.Controllers
{

    public class TempCariPersonelKartiController : Controller
    {
        #region Manager
        CinsiyetManager cnsm = new CinsiyetManager(new EfCinsiyetDal());
        CariPersonelManager cpm = new CariPersonelManager(new EfCariPersonelDal());
        UnvanManager unvm = new UnvanManager(new EfUnvanDal());
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        CariManager cm = new CariManager(new EfCariDal());
        TempCariManager tcm = new TempCariManager(new EfTempCariDal());
        PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        UlkeManager um = new UlkeManager(new EfUlkeDal());
        SehirManager sm = new SehirManager(new EfSehirDal());
        CalismaDurumuManager cdm=new CalismaDurumuManager(new EfCalismaDurumuDal());
        TempCariPersonelManager tcpm = new TempCariPersonelManager(new EfTempCariPersonelDal());
        #endregion

        [HttpGet]
        public IActionResult TempCariPersonelKarti(TempCari tempCari)
        {
            var tbTempCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
            if (tbTempCari != null)
            {
                var tempCariList = tcm.TGetList();
                foreach (var item in tempCariList)
                {
                    tcm.TDelete(item);
                }
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("AddCari", "Cari"); ;
                }
            }
            else
            {
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("AddCari", "Cari");
                }
            }
            var hesapKodu = HttpContext.Session.GetString("HesapKodu").ToString();
            return RedirectToAction("TempCariPersonelKartiEkle", "TempCariPersonelKarti");
        }

        // [HttpPost]
        // public ActionResult TempCariPersonelKarti(string personelAdi, string personelAdi2, string personelSoyadi, string cinsiyet, string telefon, bool silindi = false)
        // {
        //     personelAdi = (personelAdi == null) ? personelAdi = "" : personelAdi = personelAdi.ToUpper();
        //     personelAdi2 = (personelAdi2 == null) ? personelAdi2 = "" : personelAdi2 = personelAdi2.ToUpper();
        //     personelSoyadi = (personelSoyadi == null) ? personelSoyadi = "" : personelSoyadi = personelSoyadi.ToUpper();
        //     telefon = (telefon == null) ? telefon = "" : telefon = telefon.ToUpper();
        //     cinsiyet = (cinsiyet == null) ? cinsiyet = "" : cinsiyet = cinsiyet.ToUpper();
        //     ViewBag.chckSilindi = silindi;
        //     ViewBag.personelAdi = personelAdi;
        //     ViewBag.personelSoyadi = personelSoyadi;
        //     ViewBag.telefon = telefon;
        //     ViewBag.cinsiyetId = cinsiyet;
        //     if (silindi == true)
        //     {
        //         ViewBag.lblSilindi = "Silindi";
        //     }
        //     else
        //     {
        //         ViewBag.lblSilindi = "Mevcut";
        //     }
        //     if (cinsiyet == "")
        //     {
        //         var tblPersonel = tcpm.TGetList().Where(x => x.CariPersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.CariPersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.Silindi == silindi);
        //         ViewBag.personelList = tblPersonel;
        //         if (tblPersonel.ToList().Count == 0)
        //         {
        //             ViewBag.personelList = tcpm.TGetList().Where(x => x.CariPersonelAdi == "none");
        //         }
        //     }
        //     else
        //     {
        //         var tblPersonel = tcpm.TGetList().Where(x => x.CariPersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.CariPersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.CinsiyetId.ToString() == cinsiyet && x.Silindi == silindi);
        //         ViewBag.personelList = tblPersonel;
        //     }
        //     ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
        //     return RedirectToAction("AddCari", "Cari");
        // }

        [HttpGet]
        public IActionResult TempCariPersonelKartiGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult TempCariPersonelKartiGuncelle(TempCari tempCari, int personelId)
        {
            var tbTempCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
            if (tbTempCari != null)
            {
                var tempCariList = tcm.TGetList();
                foreach (var item in tempCariList)
                {
                    tcm.TDelete(item);
                }
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("AddCari", "Cari"); ;
                }
            }
            else
            {
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("AddCari", "Cari");
                }
            }
            var hesapKodu = HttpContext.Session.GetString("HesapKodu").ToString();
            Vb();
            ViewBag.id = personelId;
            return View();
        }

        [HttpPost]
        public IActionResult TempCariPersonelKartiGuncelle(TempCariPersonel personel, int personelId, string iseGiris, int olusturan, string olusturulmaTarihi)
        {
            try
            {
                personel.CariPersonelId = personelId;
                personel.Olusturan = olusturan;
                personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                personel.SonDegistirmeTarih = DateTime.UtcNow;
                personel.IseGirisTarihi=DateTimeOffset.Parse(iseGiris).UtcDateTime;
                tcpm.TUpdate(personel);
                var cariId = HttpContext.Session.GetInt32("CariId");
                TempData["error"] = null;
                return RedirectToAction("AddCari", "Cari");
            }
            catch (Exception ex)
            {
                string asdf = ex.Message;
                Vb();
                TempData["error"] = "err";
                ViewBag.id = personelId;
                return View();
            }
        }

        [HttpGet]
        public IActionResult TempCariPersonelKartiEkle()
        {
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.posisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            Vb();
            return View();
        }

        [HttpPost]
        public IActionResult TempCariPersonelKartiEkle(TempCariPersonel personel, string iseGiris)
        {
            ViewBag.tempPersonelList = tcpm.TGetList().Where(x => x.Silindi == false);
            try
            {
                var kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                //personel.CalismaDurumu = true;
                personel.SonDegistiren = kullaniciId;
                personel.Olusturan = kullaniciId;
                personel.SonDegistirmeTarih = DateTime.UtcNow.Date;
                personel.OlusturulmaTarih = DateTime.UtcNow;
                personel.IseGirisTarihi = DateTimeOffset.Parse(iseGiris).UtcDateTime;
                tcpm.TAdd(personel);
            }
            catch (Exception ex)
            {
                Vb();
                TempData["error"] = "Ekleme İşlemi Başarısız Oldu";
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                return View();
            }
            // var cariId = HttpContext.Session.GetInt32("CariId");
            TempData["error"] = null;
            return RedirectToAction("AddCari", "Cari");
        }

        [HttpPost]
        public IActionResult TempCariKaydet(TempCari tempCari)
        {
            try
            {
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
                tempCari.SonDegistiren = kullanici;
                tempCari.Olusturan = kullanici;
                tempCari.SonDegistirmeTarih = DateTime.UtcNow.Date;
                tempCari.OlusturulmaTarih = DateTime.UtcNow;
                tcm.TAdd(tempCari);
            }
            catch (Exception ex)
            {
                ViewBag.hesapKodu = tempCari.HesapKodu;
                TempData["error"] = "Eklemem İşlemi Başarısız Oldu";
                return View();
            }

            TempData["error"] = null;
            return RedirectToAction("TempCariPersonelKartiEkle", "TempCariPersonelKarti");
        }
        public ActionResult DeleteTempPersonel(int id)
        {
            var personel = tcpm.TGetByID(id);
            personel.Silindi = true;
            tcpm.TUpdate(personel);
            var cariId = HttpContext.Session.GetInt32("CariId");
            return RedirectToAction("AddCari", "Cari");
        }
        public void Vb()
        {
            
            var personelList = tcpm.TGetList().Where(x => x.Silindi == false);
            ViewBag.calismaDurumuList=cdm.TGetList().Where(x=>x.Silindi==false);
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.posisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = personelList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }




        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        //////////GTEMPCARİPERSONELKARTİ////////////
        [HttpGet]
        public IActionResult GTempCariPersonelKarti(TempCari tempCari)
        {
            var tbTempCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
            int cariId = (int)HttpContext.Session.GetInt32("CariId");
            ViewBag.cariId = cariId;
            if (tbTempCari != null)
            {
                var tempCariList = tcm.TGetList();
                foreach (var item in tempCariList)
                {
                    tcm.TDelete(item);
                }
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }
            }
            else
            {
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }
            }

            return RedirectToAction("GTempCariPersonelKartiEkle", "TempCariPersonelKarti");
        }

        // [HttpPost]
        // public ActionResult GTempCariPersonelKarti(string personelAdi, string personelAdi2, string personelSoyadi, string cinsiyet, string telefon, bool silindi = false)
        // {
        //     personelAdi = (personelAdi == null) ? personelAdi = "" : personelAdi = personelAdi.ToUpper();
        //     personelAdi2 = (personelAdi2 == null) ? personelAdi2 = "" : personelAdi2 = personelAdi2.ToUpper();
        //     personelSoyadi = (personelSoyadi == null) ? personelSoyadi = "" : personelSoyadi = personelSoyadi.ToUpper();
        //     telefon = (telefon == null) ? telefon = "" : telefon = telefon.ToUpper();
        //     cinsiyet = (cinsiyet == null) ? cinsiyet = "" : cinsiyet = cinsiyet.ToUpper();
        //     ViewBag.chckSilindi = silindi;
        //     ViewBag.personelAdi = personelAdi;
        //     ViewBag.personelSoyadi = personelSoyadi;
        //     ViewBag.telefon = telefon;
        //     ViewBag.cinsiyetId = cinsiyet;
        //     if (silindi == true)
        //     {
        //         ViewBag.lblSilindi = "Silindi";
        //     }
        //     else
        //     {
        //         ViewBag.lblSilindi = "Mevcut";
        //     }
        //     if (cinsiyet == "")
        //     {
        //         var tblPersonel = tcpm.TGetList().Where(x => x.CariPersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.CariPersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.Silindi == silindi);
        //         ViewBag.personelList = tblPersonel;
        //         if (tblPersonel.ToList().Count == 0)
        //         {
        //             ViewBag.personelList = tcpm.TGetList().Where(x => x.CariPersonelAdi == "none");
        //         }
        //     }
        //     else
        //     {
        //         var tblPersonel = tcpm.TGetList().Where(x => x.CariPersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.CariPersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.CinsiyetId.ToString() == cinsiyet && x.Silindi == silindi);
        //         ViewBag.personelList = tblPersonel;
        //     }
        //     ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
        //     return RedirectToAction("AddCari", "Cari");
        // }

        [HttpGet]
        public IActionResult GTempCariPersonelKartiGor(int id)
        {
            ViewBag.id = id;
            ViewBag.cariId=HttpContext.Session.GetInt32("CariId");
            return View();
        }

        [HttpGet]
        public IActionResult GTempCariPersonelKartiGuncelle(TempCari tempCari, int personelId)
        {
            var tbTempCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
            int cariId = (int)HttpContext.Session.GetInt32("CariId");
            ViewBag.cariId=cariId;
            if (tbTempCari != null)
            {
                var tempCariList = tcm.TGetList();
                foreach (var item in tempCariList)
                {
                    tcm.TDelete(item);
                }
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("CariGuncelle", "Cari"); ;
                }
            }
            else
            {
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }
            }
            Vb();
            ViewBag.id = personelId;
            return View();
        }

        [HttpPost]
        public IActionResult GTempCariPersonelKartiGuncelle(TempCariPersonel personel, TempCari cari, int personelId, int olusturan, string olusturulmaTarihi,string iseGiris)
        {
            try
            {
                var cariId = (int)HttpContext.Session.GetInt32("CariId");
                var tempCariPersonel = tcpm.TGetList().Where(x => x.CariPersonelKodu == personel.CariPersonelKodu).FirstOrDefault();
                if (personel.CariPersonelKodu != null)
                {
                    try
                    {

                        // personel.Olusturan = olusturan;
                        // personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                        personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                        personel.SonDegistirmeTarih = DateTime.UtcNow;
                        if (tempCariPersonel != null)
                        {   tempCariPersonel.Adres1 = personel.Adres1;
                            tempCariPersonel.Adres2 = personel.Adres2;
                            tempCariPersonel.CalismaDurumuId = personel.CalismaDurumuId;
                            tempCariPersonel.CariPersonelAdi = personel.CariPersonelAdi;
                            tempCariPersonel.CariPersonelAdi2 = personel.CariPersonelAdi2;
                            tempCariPersonel.CariPersonelSoyadi = personel.CariPersonelSoyadi;
                            tempCariPersonel.CinsiyetId = personel.CinsiyetId;
                            tempCariPersonel.DepartmanId = personel.DepartmanId;
                            tempCariPersonel.IseGirisTarihi =  DateTimeOffset.Parse(iseGiris).UtcDateTime;
                            tempCariPersonel.Mail = personel.Mail;
                            tempCariPersonel.PozisyonId = personel.PozisyonId;
                            tempCariPersonel.SerivsMailGonder = personel.SerivsMailGonder;
                            tempCariPersonel.ServisFaturaGonder = personel.ServisFaturaGonder;
                            tempCariPersonel.Telefon = personel.Telefon;
                            tempCariPersonel.UnvanId = personel.UnvanId;
                            tempCariPersonel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                            tempCariPersonel.SonDegistirmeTarih = DateTime.UtcNow;
                            tcpm.TUpdate(tcpm.TGetByID(tempCariPersonel.CariPersonelId));
                        }
                        else
                        {
                            tcpm.TAdd(personel);
                        }

                        var tbCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
                        ViewBag.tempId = tbCari.CariId;
                        HttpContext.Session.SetInt32("TempCari", tbCari.CariId);
                        TempData["error"] = null;
                        return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                    }
                    catch (Exception ex)
                    {
                        string asdf = ex.Message;
                        Vb();
                        TempData["error"] = "err";
                        ViewBag.id = personelId;
                        return View();
                    }

                }
                else if (cari.HesapKodu != null)
                {
                    try
                    {
                        tcm.TAdd(cari);
                        return RedirectToAction("GTempCariPersonelKartiGuncelle", "TempCariPersonelKarti", new { id = personelId });
                    }
                    catch (Exception ex)
                    {
                        Vb();
                        TempData["error"] = "err";
                        ViewBag.id = personelId;
                        return View();
                    }

                }
                else
                {
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }
                // try
                // {
                //     personel.CariPersonelId = personelId;
                //     personel.Olusturan = olusturan;
                //     personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                //     personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                //     personel.SonDegistirmeTarih = DateTime.UtcNow;
                //     tcpm.TUpdate(personel);
                //     var cariId = HttpContext.Session.GetInt32("CariId");
                //     TempData["error"] = null;
                //     return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
            }
            catch (Exception ex)
            {
                string asdf = ex.Message;
                Vb();
                TempData["error"] = "err";
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                ViewBag.id = personelId;
                return View();
            }
        }
        [HttpGet]
        public IActionResult GCariPersonelKartiGuncelle(TempCari tempCari, int personelId)
        {
            var tbTempCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
            int cariId = (int)HttpContext.Session.GetInt32("CariId");
           
            ViewBag.cariId=cariId;
            if (tbTempCari != null)
            {
                var tempCariList = tcm.TGetList();
                foreach (var item in tempCariList)
                {
                    tcm.TDelete(item);
                }
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("CariGuncelle", "Cari"); ;
                }
            }
            else
            {
                try
                {
                    tempCari.Olusturan = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.OlusturulmaTarih = DateTime.UtcNow;
                    tempCari.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    tempCari.SonDegistirmeTarih = DateTime.UtcNow;
                    tcm.TAdd(tempCari);
                }
                catch (Exception ex)
                {
                    Vb();
                    TempData["error"] = "err";
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }
            }
            Vb();
            ViewBag.id = personelId;
            return View();
        }

        [HttpPost]
        public IActionResult GCariPersonelKartiGuncelle(TempCariPersonel personel, TempCari cari, int personelId, int olusturan, string olusturulmaTarihi,string iseGiris)
        {
            try
            {
                var cariId = (int)HttpContext.Session.GetInt32("CariId");
                var tempCariPersonel = tcpm.TGetList().Where(x => x.CariPersonelKodu == personel.CariPersonelKodu).FirstOrDefault();
                if (personel.CariPersonelKodu != null)
                {
                    try
                    {

                        personel.Olusturan = olusturan;
                        personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                        personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                        personel.SonDegistirmeTarih = DateTime.UtcNow;
                        personel.IseGirisTarihi=DateTimeOffset.Parse(iseGiris).UtcDateTime;
                        if (tempCariPersonel != null)
                        {
                            // personel.CariPersonelId = personelId;
                            tempCariPersonel.Adres1 = personel.Adres1;
                            tempCariPersonel.Adres2 = personel.Adres2;
                            tempCariPersonel.CalismaDurumuId = personel.CalismaDurumuId;
                            tempCariPersonel.CariPersonelAdi = personel.CariPersonelAdi;
                            tempCariPersonel.CariPersonelAdi2 = personel.CariPersonelAdi2;
                            tempCariPersonel.CariPersonelSoyadi = personel.CariPersonelSoyadi;
                            tempCariPersonel.CinsiyetId = personel.CinsiyetId;
                            tempCariPersonel.DepartmanId = personel.DepartmanId;
                            tempCariPersonel.IseGirisTarihi =  DateTimeOffset.Parse(iseGiris).UtcDateTime;
                            tempCariPersonel.Mail = personel.Mail;
                            tempCariPersonel.PozisyonId = personel.PozisyonId;
                            tempCariPersonel.SerivsMailGonder = personel.SerivsMailGonder;
                            tempCariPersonel.ServisFaturaGonder = personel.ServisFaturaGonder;
                            tempCariPersonel.Telefon = personel.Telefon;
                            tempCariPersonel.UnvanId = personel.UnvanId;
                            tempCariPersonel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                            tempCariPersonel.SonDegistirmeTarih = DateTime.UtcNow;
                            tcpm.TUpdate(tcpm.TGetByID(tempCariPersonel.CariPersonelId));
                        }
                        else
                        {
                            
                            tcpm.TAdd(personel);
                        }

                        var tbCari = tcm.TGetList().Where(x => x.Silindi == false).FirstOrDefault();
                        ViewBag.tempId = tbCari.CariId;
                        HttpContext.Session.SetInt32("TempCari", tbCari.CariId);
                        TempData["error"] = null;
                        return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                    }
                    catch (Exception ex)
                    {
                        string asdf = ex.Message;
                        Vb();
                        TempData["error"] = "err";
                        ViewBag.id = personelId;
                        return View();
                    }

                }
                else if (cari.HesapKodu != null)
                {
                    try
                    {
                        tcm.TAdd(cari);
                        return RedirectToAction("GTempCariPersonelKartiGuncelle", "TempCariPersonelKarti", new { id = personelId });
                    }
                    catch (Exception ex)
                    {
                        Vb();
                        TempData["error"] = "err";
                        ViewBag.id = personelId;
                        return View();
                    }

                }
                else
                {
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }
                // try
                // {
                //     personel.CariPersonelId = personelId;
                //     personel.Olusturan = olusturan;
                //     personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                //     personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                //     personel.SonDegistirmeTarih = DateTime.UtcNow;
                //     tcpm.TUpdate(personel);
                //     var cariId = HttpContext.Session.GetInt32("CariId");
                //     TempData["error"] = null;
                //     return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
            }
            catch (Exception ex)
            {
                string asdf = ex.Message;
                Vb();
                TempData["error"] = "err";
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                ViewBag.id = personelId;
                return View();
            }
        }

        [HttpGet]
        public IActionResult GTempCariPersonelKartiEkle(int id)
        {
            ViewBag.cariId=HttpContext.Session.GetInt32("CariId");
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.posisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            ViewBag.calismaDurumuList=cdm.TGetList().Where(x=>x.Silindi==false);
            return View();
        }

        [HttpPost]
        public IActionResult GTempCariPersonelKartiEkle(TempCariPersonel personel, string iseGiris)
        {
            int cariId = (int)HttpContext.Session.GetInt32("CariId");

            ViewBag.tempPersonelList = tcpm.TGetList().Where(x => x.Silindi == false);
            try
            {
                var kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
               // personel.CalismaDurumu = true;
                personel.SonDegistiren = kullaniciId;
                personel.Olusturan = kullaniciId;
                personel.SonDegistirmeTarih = DateTime.UtcNow.Date;
                personel.OlusturulmaTarih = DateTime.UtcNow;
                personel.IseGirisTarihi = DateTimeOffset.Parse(iseGiris).UtcDateTime;

                tcpm.TAdd(personel);
            }
            catch (Exception ex)
            {
                Vb();
                TempData["error"] = "Ekleme İşlemi Başarısız Oldu";
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                return View();
            }
            TempData["error"] = null;
            return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
        }
        public ActionResult DeleteGTempPersonel(int id)
        {
            var personel = tcpm.TGetByID(id);
            personel.Silindi = true;
            tcpm.TUpdate(personel);
            var cariId = HttpContext.Session.GetInt32("CariId");
            return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
        }
        public IActionResult TumunuKaydet(Cari cari)
        {
            int cariId = (int)HttpContext.Session.GetInt32("CariId");
            var tblTempCari = tcm.TGetList().FirstOrDefault();

            if (tblTempCari != null)
            {
                var tempCariList = tcm.TGetList();
                foreach (var item in tempCariList)
                {
                    tcm.TDelete(item);
                }
            }
            try
            {
                var tbCari = cm.TGetList().Where(x => x.Silindi == false && x.HesapKodu == cari.HesapKodu).FirstOrDefault();
                var tblCari = cm.TGetByID(tbCari.CariId);
                tblCari.Adres = cari.Adres;
                tblCari.AnaSektorId = cari.AnaSektorId;
                tblCari.BagliSektorId = cari.BagliSektorId;
                tblCari.CariAdi = cari.CariAdi;
                tblCari.CariDil = cari.CariDil;
                tblCari.CariDurumId = cari.CariDurumId;
                tblCari.CariTipiId = cari.CariTipiId;
                tblCari.eFaturaMukellefi = cari.eFaturaMukellefi;
                tblCari.eIrsaliyeMukellefi = cari.eIrsaliyeMukellefi;
                tblCari.FirmaNo = cari.FirmaNo;
                tblCari.IlceId = cari.IlceId;
                tblCari.MailAdresi1 = cari.MailAdresi1;
                tblCari.MailAdresi2 = cari.MailAdresi2;
                tblCari.ParaBirimiId = cari.ParaBirimiId;
                tblCari.SehirId = cari.SehirId;
                tblCari.Telefon1 =  cari.Telefon1;
                tblCari.Telefon2 = cari.Telefon2;
                tblCari.UlkeId = cari.UlkeId;
                tblCari.VergiDairesi = cari.VergiDairesi;
                tblCari.VergiNo = cari.VergiNo;
                tblCari.WebSitesi = cari.WebSitesi;

                // var cariId=(int)HttpContext.Session.GetInt32("CariId");
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
                cari.SonDegistiren = kullanici;
                //cari.Olusturan = kullanici;
                cari.SonDegistirmeTarih = DateTime.UtcNow.Date;
                //cari.OlusturulmaTarih = DateTime.UtcNow;


                cm.TUpdate(tblCari);
                var tempCariPersonel = tcpm.TGetList().Where(x => x.Silindi == false);

                List<string> list = new List<string>();
                foreach (var item in tempCariPersonel)
                {
                    var tbCariPersonel = cpm.TGetList().Where(x => x.CariPersonelKodu == item.CariPersonelKodu).FirstOrDefault(); 
                    CariPersonel cariPersonel = new CariPersonel();
                    cariPersonel.Adres1 = item.Adres1;
                    cariPersonel.Adres2 = item.Adres2;
                    cariPersonel.CalismaDurumuId = item.CalismaDurumuId;
                    cariPersonel.CariPersonelAdi = item.CariPersonelAdi;
                    cariPersonel.CariPersonelAdi2 = item.CariPersonelAdi2;
                    cariPersonel.CariPersonelKodu = item.CariPersonelKodu;
                    cariPersonel.CariPersonelSoyadi = item.CariPersonelSoyadi;
                    cariPersonel.CinsiyetId = item.CinsiyetId;
                    cariPersonel.DepartmanId = item.DepartmanId;
                    cariPersonel.IseGirisTarihi = item.IseGirisTarihi;
                    cariPersonel.IstenCikisTarihi = item.IstenCikisTarihi;
                    cariPersonel.Mail = item.Mail;
                    cariPersonel.Olusturan = item.Olusturan;
                    cariPersonel.OlusturulmaTarih = item.OlusturulmaTarih;
                    cariPersonel.PozisyonId = item.PozisyonId;
                    cariPersonel.SerivsMailGonder = item.SerivsMailGonder;
                    cariPersonel.ServisFaturaGonder = item.ServisFaturaGonder;
                    cariPersonel.Silindi = item.Silindi;
                    cariPersonel.SonDegistiren = item.SonDegistiren;
                    cariPersonel.SonDegistirmeTarih = item.SonDegistirmeTarih;
                    cariPersonel.Telefon = item.Telefon;
                    cariPersonel.UnvanId = item.UnvanId;
                    cariPersonel.CariId = cariId;
                    cpm.TAdd(cariPersonel);
                    if (tbCariPersonel!=null)
                    {
                         if (item.CariPersonelKodu == tbCariPersonel.CariPersonelKodu)
                    {
                        cpm.TDelete(tbCariPersonel);
                    }
                    }
                   
                    tcpm.TDelete(item);
                    list.Add(item.CariPersonelKodu);

                }
               var tblCariPersonel=cpm.TGetList().Where(x=>x.Silindi==false && x.Silinecek==true);
               foreach (var item in tblCariPersonel)
               {
                item.Silindi=true;
                item.Silinecek=null;
                cpm.TUpdate(item);
               }
                //   var tbCari = cm.TGetList().Where(x => x.HesapKodu == cari.HesapKodu).FirstOrDefault();
                var tempCariList = tcm.TGetList();
                if (tempCariList.Count() != 0)
                {
                    foreach (var item in tempCariList)
                    {
                        tcm.TDelete(item);
                    }

                }

                VbDelete();
                TempData["error"] = null;
                return RedirectToAction("Index", "Cari");
            }
            catch (Exception ex)
            {
                Vb();
                TempData["error"] = "Ekleme İşlemi Başarısız Oldu";
                return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
            }


        }
        public void VbDelete()
        {
            // sCari = null;
            var hesapKodu = cm.TGetList().Count;
            if (hesapKodu == 0)
            {
                ViewBag.hesapKodu = "10001";
                HttpContext.Session.SetString("HesapKodu", "10001");
            }
            else
            {

                ViewBag.hesapKodu = (Int32.Parse(cm.TGetList().OrderByDescending(x => x.HesapKodu).FirstOrDefault().HesapKodu) + 1).ToString();
                HttpContext.Session.SetString("HesapKodu", (Int32.Parse(cm.TGetList().OrderByDescending(x => x.HesapKodu).FirstOrDefault().HesapKodu) + 1).ToString());
            }
        }
    }
}