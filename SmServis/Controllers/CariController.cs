using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace SmServis.Controllers
{
    public class CariController : Controller
    {
        #region Manager
        CariManager cm = new CariManager(new EfCariDal());
        // IlgiliKisilerManager im = new IlgiliKisilerManager(new EfIlgiliKisilerDal());
        IlceManager ilcem = new IlceManager(new EfIlceDal());
        SehirManager sm = new SehirManager(new EfSehirDal());
        UlkeManager um = new UlkeManager(new EfUlkeDal());
        IlgiliKisilerValidation ikValidations = new IlgiliKisilerValidation();
        CariDurumManager cdm = new CariDurumManager(new EfCariDurumDal());
        ParaBirimiManager pbm = new ParaBirimiManager(new EfParaBirimiDal());
        AnaSektorManager asm = new AnaSektorManager(new EfAnaSektorDal());
        BagliSektorManager bsm = new BagliSektorManager(new EfBagliSektorDal());
        CariTipiManager ctm = new CariTipiManager(new EfCariTipiDal());
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        PozisyonManager pzm = new PozisyonManager(new EfPozisyonDal());
        CariPersonelManager cpm = new CariPersonelManager(new EfCariPersonelDal());
        UnvanManager unvm = new UnvanManager(new EfUnvanDal());
        PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());
        CinsiyetManager cnsm = new CinsiyetManager(new EfCinsiyetDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        Ana_BagliSektorManager a_bm = new Ana_BagliSektorManager(new EfAna_BagliSektorDal());
        TempCariPersonelManager tcpm = new TempCariPersonelManager(new EfTempCariPersonelDal());
        TempCariManager tcm = new TempCariManager(new EfTempCariDal());
        ServisProjeIcerikManager spim = new ServisProjeIcerikManager(new EfServisProjeIcerikDal());
        ProjeIcerikManager pim = new ProjeIcerikManager(new EfProjeIcerikDal());
        ProjeManager prjm = new ProjeManager(new EfProjeDal());
        //FirmaValidation fValidations = new FirmaValidation();
        SmServisContext db = new SmServisContext();
        #endregion
        public IActionResult Index()
        {
            var cariList = cm.TGetList();
            try
            {
               
                var tempCari = tcm.TGetList().FirstOrDefault();
                if (tempCari != null)
                {
                    tcm.TDelete(tempCari);
                }
                var tempCariPersonel = tcpm.TGetList();
                if (tempCariPersonel != null)
                {
                    foreach (var item in tempCariPersonel)
                    {
                        tcpm.TDelete(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            ViewBag.cariList = cariList;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firmaNo, string hesapKodu, string subeKodu, string cariAdi, string vergiDairesi, string vergiNo, string cariDil, string ulke, string sehir)
        {
             firmaNo = (firmaNo == null) ? firmaNo = "" : firmaNo = firmaNo;
             hesapKodu = (hesapKodu == null) ? hesapKodu = "" : hesapKodu = hesapKodu.ToUpper();
             subeKodu = (subeKodu == null) ? subeKodu = "" : subeKodu = subeKodu.ToUpper();
             cariAdi = (cariAdi == null) ? cariAdi = "" : cariAdi = cariAdi.ToUpper();
             vergiDairesi = (vergiDairesi == null) ? vergiDairesi = "" : vergiDairesi = vergiDairesi.ToUpper();
             vergiNo = (vergiNo == null) ? vergiNo = "" : vergiNo = vergiNo.ToUpper();
             cariDil = (cariDil == null) ? cariDil = "" : cariDil = cariDil.ToUpper();
             ulke = (ulke == null) ? ulke = "" : ulke = ulke.ToUpper();
             sehir = (sehir == null) ? sehir = "" : sehir = sehir.ToUpper();
             var tblCari=cm.TGetList().Where(x=>x.FirmaNo.ToString().StartsWith(firmaNo) && x.HesapKodu.ToUpper().StartsWith(hesapKodu) && x.CariAdi.ToUpper() .Contains(cariAdi) && x.VergiDairesi.ToUpper().Contains(vergiDairesi) && x.VergiNo.StartsWith(vergiNo) &&x.CariDil.ToUpper().StartsWith(cariDil) && x.Silindi==false );
             ViewBag.cariList=tblCari;
             
             return View();
        }
        [HttpGet]
        public IActionResult AddCari()
        {
            ViewBag.pesonelList = tcpm.TGetList();
            var tbCari = tcm.TGetList().FirstOrDefault();
            if (tbCari != null)
            {
                ViewBag.cariTipiId = tbCari.CariTipiId;
                ViewBag.cariTipi = ctm.TGetByID(tbCari.CariTipiId).CariTipiAciklama;
                ViewBag.vergiNumarasi = tbCari.VergiNo;
                ViewBag.vergiDairesi = tbCari.VergiDairesi;
                ViewBag.adres = tbCari.Adres;
                ViewBag.firmaNo = tbCari.FirmaNo;
                ViewBag.cariAdi = tbCari.CariAdi;
                ViewBag.cariDili = tbCari.CariDil;
                ViewBag.ulkeId = tbCari.UlkeId;
                ViewBag.ulkeAdi = um.TGetByID(tbCari.UlkeId).UlkeAdi;
                ViewBag.sehirId = tbCari.SehirId;
                ViewBag.sehirAdi = sm.TGetByID(tbCari.SehirId).SehirAdi;
                ViewBag.ilceId = tbCari.IlceId;
                ViewBag.ilceAdi = ilcem.TGetByID(tbCari.IlceId).IlceAdi;
                ViewBag.cariDurumId = tbCari.CariDurumId;
                ViewBag.cariDurumAdi = cdm.TGetByID(tbCari.CariDurumId).CariDurumAciklama;
                ViewBag.sektorId = tbCari.AnaSektorId;
                ViewBag.sektorAdi = asm.TGetByID(tbCari.AnaSektorId).AnaSektorAdi;
                ViewBag.bagliSektorId = tbCari.BagliSektorId;
                if (tbCari.BagliSektorId != null)
                {
                    ViewBag.bagliSektorAdi = bsm.TGetByID((int)tbCari.BagliSektorId).BagliSektorAdi;
                }
                ViewBag.bagliSektorAdi = "";
                ViewBag.paraBirimiId = tbCari.ParaBirimiId;
                ViewBag.paraBirimiAdi = pbm.TGetByID(tbCari.ParaBirimiId).ParaBirimiAdi;
                ViewBag.paraBirimiSimge = pbm.TGetByID(tbCari.ParaBirimiId).ParaBirimiSimge;
                ViewBag.telefon1 = tbCari.Telefon1;
                ViewBag.telefon2 = tbCari.Telefon2;
                ViewBag.mailAdresi1 = tbCari.MailAdresi1;
                ViewBag.mailAdresi2 = tbCari.MailAdresi2;
                ViewBag.adres = tbCari.Adres;
                ViewBag.eFatura = tbCari.eFaturaMukellefi;
                ViewBag.eIrsaliye = tbCari.eIrsaliyeMukellefi;
                ViewBag.webSitesi = tbCari.WebSitesi;
            }
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
            Vb();
            ViewBag.personelList = tcpm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public IActionResult AddCari(TempCari cari, string hesapKodu, string isDone)
        {
            try
            {
                try
                {
                    var tbTempCari = tcm.TGetList();
                    if (tbTempCari.Count() != 0)
                    {
                        tcm.TDelete(tbTempCari.FirstOrDefault());
                    }
                }
                catch (Exception ex)
                {


                }
                // cari.Telefon1 = "(+" + um.TGetByID(cari.UlkeId).TelefonKodu + ") " + cari.Telefon1;
                // cari.Telefon2 = "(+" + um.TGetByID(cari.SehirId).TelefonKodu + ") " + cari.Telefon2;
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
                cari.SonDegistiren = kullanici;
                cari.Olusturan = kullanici;
                cari.SonDegistirmeTarih = DateTime.UtcNow.Date;
                cari.OlusturulmaTarih = DateTime.UtcNow;
                tcm.TAdd(cari);
                TempData["error"] = null;
                return RedirectToAction("TempCariPersonelKartiEkle", "TempCariPersonelKarti");
            }
            catch (Exception ex)
            {
                Vb();
                ViewBag.hesapKodu = hesapKodu;
                TempData["error"] = "Eklemem İşlemi Başarısız Oldu";
                return View();
            }
        }
        public IActionResult CariVeriKaydet(Cari cari)
        {
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
                // cari.Telefon1 = "(+" + um.TGetByID(cari.UlkeId).TelefonKodu + ") " + cari.Telefon1;
                // cari.Telefon2 = "(+" + um.TGetByID(cari.SehirId).TelefonKodu + ") " + cari.Telefon2;
                // var cariId=(int)HttpContext.Session.GetInt32("CariId");
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
                cari.SonDegistiren = kullanici;
                cari.Olusturan = kullanici;
                cari.SonDegistirmeTarih = DateTime.UtcNow.Date;
                cari.OlusturulmaTarih = DateTime.UtcNow;
                cm.TAdd(cari);
                var cariId = cm.TGetList().Where(x => x.HesapKodu == cari.HesapKodu).FirstOrDefault().CariId;
                var tempCariPersonel = tcpm.TGetList().Where(x=>x.Silindi==false);
                List<string> list = new List<string>();
                foreach (var item in tempCariPersonel)
                {
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
                    tcpm.TDelete(item);
                    list.Add(item.CariPersonelKodu);
                }
                var tbCari = cm.TGetList().Where(x => x.HesapKodu == cari.HesapKodu).FirstOrDefault();
                var tempCariList=tcm.TGetList();
                if (tempCariList.Count() != 0)
                {
                    foreach (var item in tempCariList)
                    {
                         tcm.TDelete(item);
                    }
                   
                }

                VbDelete();
                TempData["error"] = null;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Vb();
                TempData["error"] = "Ekleme İşlemi Başarısız Oldu";
                return RedirectToAction("AddCari");
            }

        }

        [HttpGet]
        public IActionResult CariGuncelle(int id)
        {
            var cari = cm.TGetByID(id);
            var ulke = um.TGetByID(cari.UlkeId);
            var sehir = sm.TGetByID(cari.SehirId);
            var anaSektor = asm.TGetByID(cari.AnaSektorId);
            HttpContext.Session.SetInt32("CariId", id);
            // var ilgiliKisiler=im.TGetList().Where(x=>x.CariId==id);
            Vb();
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariList = cm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = cpm.TGetList().Where(x => x.CariId == id && x.Silindi == false);
            ViewBag.cariTipiList = ctm.TGetList().Where(x => x.Silindi == false);
            ViewBag.bagliSektorList = bsm.TGetList().Where(x =>x.AnaSektorId==anaSektor.AnaSektorId && x.Silindi == false);
            ViewBag.anaSektorList = asm.TGetList().Where(x => x.Silindi == false);
            ViewBag.paraBirimiList = pbm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariDurumList = cdm.TGetList().Where(x => x.Silindi == false);
            ViewBag.ilceList = ilcem.TGetList().Where(x =>x.SehirId==sehir.SehirId && x.Silindi == false);
            ViewBag.sehirList = sm.TGetList().Where(x =>x.UlkeId==ulke.UlkeId && x.Silindi == false);
            ViewBag.ulkeList = um.TGetList().Where(x => x.Silindi == false);
            ViewBag.id = id;
            ViewBag.tempPersonelList = tcpm.TGetList().Where(x => x.Silindi == false);
            ViewBag.servisProjeList = spim.TGetList().Where(x => x.CariId == id && x.Silindi == false);
            ViewBag.projeIcerikList = pim.TGetList().Where(x=>x.Silindi==false && prjm.TGetList().Any(x => x.CariId == id));
            ViewBag.projeList = prjm.TGetList().Where(x => x.CariId == id && x.Silindi == false);
            CariPersonelKartiController.CariId = id;
            return View();
        }

        [HttpPost]
        public IActionResult CariGuncelle(Cari cari, int id)
        {
            try
            {
                var kullanici = (int)HttpContext.Session.GetInt32("kullanici");
                var tempCariPersonel = tcpm.TGetList().Where(x => x.Silindi == false);

                cari.SonDegistiren = kullanici;
                cari.Olusturan = kullanici;
                cari.SonDegistirmeTarih = DateTime.UtcNow.Date;
                cari.OlusturulmaTarih = DateTime.UtcNow;
                cari.CariId = id;
                cm.TUpdate(cari);

                foreach (var item in tempCariPersonel)
                {
                    CariPersonel cariPersonel = new CariPersonel();
                    var tbCariPersonel = cpm.TGetList().Where(x => x.CariPersonelKodu == item.CariPersonelKodu).FirstOrDefault();
                    cariPersonel.Adres1 = item.Adres1;
                    cariPersonel.Adres2 = item.Adres2;
                    cariPersonel.CalismaDurumuId = item.CalismaDurumuId;
                    cariPersonel.CariId = cari.CariId;
                    cariPersonel.CariPersonelAdi = item.CariPersonelAdi;
                    cariPersonel.CariPersonelAdi2 = item.CariPersonelAdi2;
                    cariPersonel.CariPersonelSoyadi = item.CariPersonelSoyadi;
                    cariPersonel.CariPersonelKodu = item.CariPersonelKodu;
                    cariPersonel.CinsiyetId = item.CinsiyetId;
                    cariPersonel.DepartmanId = item.DepartmanId;
                    cariPersonel.PozisyonId = item.PozisyonId;
                    cariPersonel.IseGirisTarihi = item.IseGirisTarihi;
                    cariPersonel.IstenCikisTarihi = item.IstenCikisTarihi;
                    cariPersonel.Mail = item.Mail;
                    cariPersonel.Olusturan = kullanici;
                    cariPersonel.OlusturulmaTarih = DateTime.UtcNow.Date;
                    cariPersonel.SonDegistiren = kullanici;
                    cariPersonel.SonDegistirmeTarih = DateTime.UtcNow.Date;
                    cariPersonel.Telefon = item.Telefon;
                    cariPersonel.UnvanId = item.UnvanId;
                    cpm.TAdd(cariPersonel);
                    if (item.CariPersonelKodu == tbCariPersonel.CariPersonelKodu)
                    {
                        cpm.TDelete(tbCariPersonel);
                    }
                }
                TempData["error"] = null;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {


                ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
                ViewBag.cariList = cm.TGetList().Where(x => x.Silindi == false);
                ViewBag.personelList = cpm.TGetList().Where(x => x.Silindi == false);
                ViewBag.pozisyonList = pzm.TGetList().Where(x => x.Silindi == false);
                ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
                ViewBag.cariTipiList = ctm.TGetList().Where(x => x.Silindi == false);
                ViewBag.bagliSektorList = bsm.TGetList().Where(x => x.Silindi == false);
                ViewBag.anaSektorList = asm.TGetList().Where(x => x.Silindi == false);
                ViewBag.paraBirimiList = pbm.TGetList().Where(x => x.Silindi == false);
                ViewBag.cariDurumList = cdm.TGetList().Where(x => x.Silindi == false);
                ViewBag.ilceList = ilcem.TGetList().Where(x => x.Silindi == false);
                ViewBag.sehirList = sm.TGetList().Where(x => x.Silindi == false);
                ViewBag.ulkeList = um.TGetList().Where(x => x.Silindi == false);
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                ViewBag.id = id;
                TempData["error"] = "err";
                ViewBag.ulkeList = um.TGetList().OrderBy(x => x.UlkeAdi);
                return View();
            }

        }
        public ActionResult BagliSektorGetir(int anaSektorId)
        {
            var bagli = bsm.TGetList().Where(x => x.AnaSektorId == anaSektorId).ToList();
            ViewBag.bagliList = bagli;
            return Json(bagli);
        }
        public ActionResult DeleteCari(int id)
        {
            var cariValue = cm.TGetByID(id);
            cm.TDelete(cariValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCari(int id)
        {
            var cariValue = cm.TGetByID(id);
            return View(cariValue);
        }

        [HttpGet]
        public ActionResult IlceGetir(int sehirId)
        {
            var sehir = sm.TGetByID(sehirId);
            var ilce = ilcem.TGetList().Where(x => x.SehirId == sehir.SehirId).ToList();
            return Json(ilce);
        }

        [HttpGet]
        public ActionResult SehirGetir(int ulkeId)
        {
            var ulke = um.TGetByID(ulkeId);
            var sehir = sm.TGetList().Where(x => x.UlkeId == ulke.UlkeId).ToList();
            return Json(sehir);
        }
        [HttpGet]
        public ActionResult UlkeGetir()
        {
            var ulke = um.TGetList();
            return Json(ulke);
        }

        [HttpGet]
        public ActionResult TelCode(int ulkeId)
        {
            var ulke = um.TGetByID(ulkeId);
            var telKodu = ulke.TelefonKodu;
            return Json(telKodu);
        }

        [HttpGet]
        public ActionResult TelCode2(int sehirId)
        {
            var sehir = sm.TGetByID(sehirId);
            var telKodu = sehir.TelefonKodu;
            return Json(telKodu);
        }

        [HttpPost]
        public ActionResult InputChange(string cari)
        {
            var cariList = cm.TGetList();
            cariList = cariList.Where(x => x.CariDil.StartsWith(cari)).ToList();
            ViewBag.cariList = cariList;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult IcerikGor(int id)
        {
            Vb();
            var cari = cm.TGetByID(id);
            HttpContext.Session.SetInt32("CariId", id);
            ViewBag.id = id;
            ViewBag.projeList = prjm.TGetList().Where(x => x.CariId == id && x.Silindi == false);
            ViewBag.tempPersonelList = tcpm.TGetList().Where(x => x.CariPersonelId == 0);
            ViewBag.personelList = cpm.TGetList().Where(x => x.CariId == id && x.Silindi == false);
            return View();
        }
        public void Vb()
        {
          //  ViewBag.pesonelList = tcpm.TGetList();
            var tbCari = tcm.TGetList().FirstOrDefault();
            if (tbCari != null)
            {
                ViewBag.cariTipiId = tbCari.CariTipiId;
                ViewBag.cariTipi = ctm.TGetByID(tbCari.CariTipiId).CariTipiAciklama;
                ViewBag.vergiNumarasi = tbCari.VergiNo;
                ViewBag.vergiDairesi = tbCari.VergiDairesi;
                ViewBag.adres = tbCari.Adres;
                ViewBag.firmaNo = tbCari.FirmaNo;
                ViewBag.cariAdi = tbCari.CariAdi;
                ViewBag.cariDili = tbCari.CariDil;
                ViewBag.ulkeId = tbCari.UlkeId;
                ViewBag.ulkeAdi = um.TGetByID(tbCari.UlkeId).UlkeAdi;
                ViewBag.sehirId = tbCari.SehirId;
                ViewBag.sehirAdi = sm.TGetByID(tbCari.SehirId).SehirAdi;
                ViewBag.ilceId = tbCari.IlceId;
                ViewBag.ilceAdi = ilcem.TGetByID(tbCari.IlceId).IlceAdi;
                ViewBag.cariDurumId = tbCari.CariDurumId;
                ViewBag.cariDurumAdi = cdm.TGetByID(tbCari.CariDurumId).CariDurumAciklama;
                ViewBag.sektorId = tbCari.AnaSektorId;
                ViewBag.sektorAdi = asm.TGetByID(tbCari.AnaSektorId).AnaSektorAdi;
                ViewBag.bagliSektorId = tbCari.BagliSektorId;
                if (tbCari.BagliSektorId != null)
                {
                    ViewBag.bagliSektorAdi = bsm.TGetByID((int)tbCari.BagliSektorId).BagliSektorAdi;
                }
                ViewBag.bagliSektorAdi = "";
                ViewBag.paraBirimiId = tbCari.ParaBirimiId;
                ViewBag.paraBirimiAdi = pbm.TGetByID(tbCari.ParaBirimiId).ParaBirimiAdi;
                ViewBag.paraBirimiSimge = pbm.TGetByID(tbCari.ParaBirimiId).ParaBirimiSimge;
                ViewBag.telefon1 = tbCari.Telefon1;
                ViewBag.telefon2 = tbCari.Telefon2;
                ViewBag.mailAdresi1 = tbCari.MailAdresi1;
                ViewBag.mailAdresi2 = tbCari.MailAdresi2;
                ViewBag.adres = tbCari.Adres;
                ViewBag.eFatura = tbCari.eFaturaMukellefi;
                ViewBag.eIrsaliye = tbCari.eIrsaliyeMukellefi;
                ViewBag.webSitesi = tbCari.WebSitesi;
            }
            // var hesapKodu = HttpContext.Session.GetString("HesapKodu").ToString();
            // try
            // {
            //     var cari = cm.TGetList().Where(x => x.HesapKodu == hesapKodu).FirstOrDefault();
            //     var ilgiliKisi = im.TGetList().Where(x => x.CariId == cari.CariId);
            //     List<int> personelList = new List<int>();
            //     foreach (var item in ilgiliKisi)
            //     {
            //         personelList.Add(item.PersonelId);
            //     }
            //     ViewBag.personelList = tcpm.TGetList();
            // }
            // catch (System.Exception)
            // {

            //     ViewBag.personelList = pm.TGetList().Where(x => x.CariPersonelId == 0);

            // }

            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariList = cm.TGetList().Where(x => x.Silindi == false);
            ViewBag.pozisyonList = pzm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariTipiList = ctm.TGetList().Where(x => x.Silindi == false);
            ViewBag.bagliSektorList = bsm.TGetList().Where(x => x.Silindi == false);
            ViewBag.anaSektorList = asm.TGetList().Where(x => x.Silindi == false);
            ViewBag.paraBirimiList = pbm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariDurumList = cdm.TGetList().Where(x => x.Silindi == false);
            ViewBag.ilceList = ilcem.TGetList().Where(x => x.Silindi == false);
            ViewBag.sehirList = sm.TGetList().Where(x => x.Silindi == false);
            ViewBag.ulkeList = um.TGetList().Where(x => x.Silindi == false);
            ViewBag.posisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = tcpm.TGetList();
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







// [HttpPost]
// public IActionResult AddIlgiliKisi([Bind(Prefix = "Item2")] IlgiliKisiler ilgiliKisiler)
// {
//     try
//     {
//         im.TAdd(ilgiliKisiler);
//         return RedirectToAction("Index");

//         //ValidationResult result = ikValidations.Validate(Model2);

//         //if (result.IsValid)
//         //{
//         //    im.TAdd(Model2);
//         //    return RedirectToAction("Index");
//         //}

//         //else
//         //{
//         //    foreach (var item in result.Errors)
//         //    {
//         //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//         //    }
//         //}
//     }
//     catch (Exception ex)
//     {

//     }
//     return RedirectToAction("AddCari");
// }
//[HttpPost]
//public IActionResult AddFirma(Firma p)
//{

//    return ();

//    ////p.Unvan = "a";
//    ////fm.FirmaAddBl(p);
//    ////return View();
//    //FirmaValidation validations = new FirmaValidation();
//    //ValidationResult result = validations.Validate(p);
//    //if (result.IsValid)
//    //{
//    //    fm.FirmaAddBl(p);
//    //    return RedirectToAction("Index");
//    //}

//    //else
//    //{
//    //    foreach (var item in result.Errors)
//    //    {
//    //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//    //    }
//    //}
//    //return View();

//}

// [HttpPost]
// public IActionResult AddIlgiliKisiler(IlgiliKisiler p)
// {
//     im.TAdd(p);
//     return RedirectToAction("AddCari");
//     //p.Unvan = "a";
//     //fm.FirmaAddBl(p);
//     //return View();
//     //FirmaValidation validations = new FirmaValidation();
//     //ValidationResult result = validations.Validate(p);
//     //if (result.IsValid)
//     //{
//     //    im.IlgiliKisilerAddBl(p);
//     //    return RedirectToAction("Index");
//     //}

//     //else
//     //{
//     //    foreach (var item in result.Errors)
//     //    {
//     //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//     //    }
//     //}
//     //return View();

// }