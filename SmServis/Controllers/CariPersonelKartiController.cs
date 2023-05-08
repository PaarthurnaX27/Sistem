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

    public class CariPersonelKartiController : Controller
    {
        #region Manager
        CinsiyetManager cnsm = new CinsiyetManager(new EfCinsiyetDal());
        CariPersonelManager pm = new CariPersonelManager(new EfCariPersonelDal());
        UnvanManager unvm = new UnvanManager(new EfUnvanDal());
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        CariManager cm = new CariManager(new EfCariDal());
        PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        TempCariManager tcm = new TempCariManager(new EfTempCariDal());
        TempCariPersonelManager tcpm = new TempCariPersonelManager(new EfTempCariPersonelDal());
        #endregion
        public static int CariId;
        [HttpGet]
        public IActionResult CariPersonelKarti()
        {
           // var hesapKodu = HttpContext.Session.GetString("HesapKodu").ToString();
            bool isFirst = false;
            if (isFirst == false)
            {
               // var cari = cm.TGetList().Where(x => x.HesapKodu == hesapKodu).FirstOrDefault();
                // var ilgiliKisi=ikm.TGetList().Where(x=>x.CariId==cari.CariId);
                //  List<int> personelList = new List<int>();
                // foreach (var item in ilgiliKisi)
                // {
                //     personelList.Add(item.PersonelId);
                // }
                // ViewBag.personelList = personelList;
                // ViewBag.personelList = pm.TGetList().Where(x => x.CariPersonelId == 0);
            }
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return RedirectToAction("AddCari", "Cari");
        }

        [HttpPost]
        public ActionResult CariPersonelKarti(string personelAdi, string personelAdi2, string personelSoyadi, string cinsiyet, string telefon, bool silindi = false)
        {
            var cariId = HttpContext.Session.GetInt32("CariId");
            personelAdi = (personelAdi == null) ? personelAdi = "" : personelAdi = personelAdi.ToUpper();
            personelAdi2 = (personelAdi2 == null) ? personelAdi2 = "" : personelAdi2 = personelAdi2.ToUpper();
            personelSoyadi = (personelSoyadi == null) ? personelSoyadi = "" : personelSoyadi = personelSoyadi.ToUpper();
            telefon = (telefon == null) ? telefon = "" : telefon = telefon.ToUpper();
            cinsiyet = (cinsiyet == null) ? cinsiyet = "" : cinsiyet = cinsiyet.ToUpper();
            ViewBag.chckSilindi = silindi;
            ViewBag.personelAdi = personelAdi;
            ViewBag.personelSoyadi = personelSoyadi;
            ViewBag.telefon = telefon;
            ViewBag.cinsiyetId = cinsiyet;
            if (silindi == true)
            {
                ViewBag.lblSilindi = "Silindi";
            }
            else
            {
                ViewBag.lblSilindi = "Mevcut";
            }
            if (cinsiyet == "")
            {
                var tblPersonel = pm.TGetList().Where(x => x.CariPersonelAdi.ToString().ToUpper().Contains(personelAdi) || x.CariPersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) || x.Telefon.StartsWith(telefon) || x.Silindi == silindi);
                ViewBag.personelList = tblPersonel;
                if (tblPersonel.ToList().Count == 0)
                {
                    ViewBag.personelList = pm.TGetList().Where(x => x.CariPersonelAdi == "none");
                }
            }
            else
            {
                var tblPersonel = pm.TGetList().Where(x => x.CariPersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.CariPersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.CinsiyetId.ToString() == cinsiyet && x.Silindi == silindi);
                ViewBag.personelList = tblPersonel;
            }


            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
        }

        [HttpGet]
        public IActionResult CariPersonelKartiGor(int id)
        {
            ViewBag.cariId=HttpContext.Session.GetInt32("CariId");
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult CariPersonelKartiGuncelle(int id)
        {
            ViewBag.id = id;
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.posizyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public IActionResult CariPersonelKartiGuncelle(TempCariPersonel personel, TempCari cari, int personelId, int olusturan, string olusturulmaTarihi)
        {

            try
            {
                var cariId = (int)HttpContext.Session.GetInt32("CariId");
                // personel.CariPersonelId=personelId;
                //personel.CariId=cariId;
                if (personel.CariPersonelKodu != null)
                {
                    try
                    {
                    personel.Olusturan = olusturan;
                    personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                    personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                    personel.SonDegistirmeTarih = DateTime.UtcNow;
                    tcpm.TUpdate(personel);
                    var tbCari=tcm.TGetList().Where(x=>x.Silindi==false).FirstOrDefault();
                    ViewBag.tempId=tbCari.CariId;
                    HttpContext.Session.SetInt32("TempCari",tbCari.CariId);
                    TempData["error"] = null;
                    return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                    }
                    catch (Exception ex)
                    {
                        Vb();
                       return View();
                    }
                    
                }
                else if (cari.HesapKodu != null)
                {
                    try
                    {
                        tcm.TAdd(cari);
                    return RedirectToAction("CariPersonelKartiGuncelle", "CariPersonelKarti",new {id=personelId});
                    }
                    catch (System.Exception)
                    {
                        
                       return View();
                    }
                    
                }
                else
                {
                   return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
                }




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
            //burada cari personel direkt olarak veri tabanına kayıt ediliyor
            // try
            // {
            //     var cariId=(int)HttpContext.Session.GetInt32("CariId");
            //     personel.CariPersonelId=personelId;
            //     personel.CariId=cariId;
            //     personel.Olusturan = olusturan;
            //     personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
            //     personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
            //     personel.SonDegistirmeTarih = DateTime.UtcNow;
            //     pm.TUpdate(personel);
            //      TempData["error"] = null;
            //     return RedirectToAction("CariGuncelle", "Cari",new{id=cariId});
            // }
            // catch (Exception ex)
            // {
            //     string asdf = ex.Message;
            //     TempData["error"] = "err";
            //     ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            //     ViewBag.id = personelId;
            //     return View();
            // }
        }

        [HttpGet]
        public IActionResult CariPersonelKartiEkle()
        {
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.posisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public IActionResult CariPersonelKartiEkle(TempCariPersonel personel, string iseGiris)
        {

            ViewBag.personelList = pm.TGetList().Where(x => x.Silindi == false);
            ViewBag.tempPersonelList = tcpm.TGetList().Where(x => x.Silindi == false);



            //ViewBag.personelList = tcpm.TGetList();
            // try
            // {
            //     Kullanici kullanici = new Kullanici();
            //     kullanici.KullaniciAdi = personel.CariPersonelAdi;
            //     kullanici.KullaniciAdi2 = personel.CariPersonelAdi2;
            //     kullanici.KullaniciSoyadi = personel.CariPersonelSoyadi;
            //     kullanici.KullaniciMail = personel.Mail;
            //     // kullanici.KullaniciParola = personel.Parola;
            //     personel.IseGirisTarihi= DateTimeOffset.Parse(iseGiris).UtcDateTime;
            //     km.TAdd(kullanici);
            // }
            // catch (Exception ex)
            // {
            //     Vb();
            //     TempData["error"] = "err";
            //     ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            //     return View();
            // }
            try
            {
                var kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
               // personel.CalismaDurumu = true;
                personel.SonDegistiren = kullaniciId;
                personel.Olusturan = kullaniciId;
                personel.SonDegistirmeTarih = DateTime.UtcNow.Date;
                personel.OlusturulmaTarih = DateTime.UtcNow;
                personel.IseGirisTarihi = DateTimeOffset.Parse(iseGiris).UtcDateTime;
                //CariController.sCariPersonel=personel;
                //    List<CariPersonel> cpersonel = new List<CariPersonel>{
                //        new CariPersonel{
                //         CariPersonelAdi= personel.CariPersonelAdi,
                //         CariPersonelAdi2=personel.CariPersonelAdi2,
                //         CariPersonelSoyadi=personel.CariPersonelSoyadi,
                //         CariPersonelKodu=personel.CariPersonelKodu,
                //         Telefon=personel.Telefon,
                //         Adres1=personel.Adres1,
                //         Adres2=personel.Adres2,
                //         CinsiyetId=personel.CinsiyetId,
                //         Silindi=personel.Silindi,
                //         SonDegistirmeTarih=personel.SonDegistirmeTarih,
                //         OlusturulmaTarih=personel.OlusturulmaTarih,
                //         SonDegistiren=personel.SonDegistiren,
                //         Olusturan=personel.Olusturan,
                //         Mail=personel.Mail,
                //         CalismaDurumu=personel.CalismaDurumu,
                //         DepartmanId=personel.DepartmanId,
                //         PozisyonId=personel.PozisyonId,
                //         SerivsMailGonder=personel.SerivsMailGonder,
                //         ServisFaturaGonder=personel.ServisFaturaGonder,
                //         UnvanId=personel.UnvanId,
                //         IseGirisTarihi=personel.IseGirisTarihi,
                //         IstenCikisTarihi=personel.IstenCikisTarihi
                //         }

                //        };

                // var jsonString=cpersonel;
                // CariController.cpersonel.Add(cpersonel);
                // string result=JsonConvert.SerializeObject(cpersonel);
                //  CariController.jCariPersonel=result;
                // pm.TAdd(personel);
                tcpm.TAdd(personel);

                // var cariPersonel=pm.TGetList().Where(x=>x.CariPersonelKodu==personel.CariPersonelKodu).FirstOrDefault();
                // IlgiliKisiler ilgiliKisiler=new IlgiliKisiler();
                // ilgiliKisiler.PersonelId=cariPersonel.CariPersonelId;
                // ilgiliKisiler.CariId=CariId;
                // ilgiliKisiler.Olusturan = kullaniciId;
                // ilgiliKisiler.OlusturulmaTarih =DateTime.UtcNow;
                // ilgiliKisiler.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                // ilgiliKisiler.SonDegistirmeTarih = DateTime.UtcNow;
                // CariController.ilgiliKisi=ilgiliKisiler;
                //bu alanı daha sonra aç

                //ikm.TAdd(ilgiliKisiler);
            }
            catch (Exception ex)
            {
                Vb();
                TempData["error"] = "err";
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                return View();
            }
            var cariId = (int)HttpContext.Session.GetInt32("CariId");
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            TempData["error"] = null;
            return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
        }
        public ActionResult DeletePersonel(int id)
        {
            var cariId = (int)HttpContext.Session.GetInt32("CariId");
            var personel = pm.TGetByID(id);
            personel.Silinecek = true;
            pm.TUpdate(personel);
            return RedirectToAction("CariGuncelle", "Cari", new { id = cariId });
        }
        public void Vb()
        {
            var personelList = pm.TGetList().Where(x => x.Silindi == false);
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.posisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = personelList;
        }
    }
}