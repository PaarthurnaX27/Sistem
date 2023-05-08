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
    public class PersonelKartiController : Controller
    {
        CinsiyetManager cnsm = new CinsiyetManager(new EfCinsiyetDal());
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        KullaniciManager km = new KullaniciManager(new EfKullaniciDal());
        UnvanManager unvm = new UnvanManager(new EfUnvanDal());
        PozisyonManager pznm = new PozisyonManager(new EfPozisyonDal());
        DepartmanManager dptm = new DepartmanManager(new EfDepartmanDal());
        SmServisContext db = new SmServisContext();
        SmSecContext db2 = new SmSecContext();
        public IActionResult PersonelKarti(bool isFirst = false)
        {
            if (isFirst == false)
            {
                ViewBag.personelList = pm.TGetList().Where(x => x.PersonelId == 0);
            }
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public ActionResult PersonelKarti(string personelAdi, string personelAdi2, string personelSoyadi, string cinsiyet, string telefon, bool silindi = false)
        {
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
                var tblPersonel = pm.TGetList().Where(x => x.PersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.PersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.Silindi == silindi);
                ViewBag.personelList = tblPersonel;
                if (tblPersonel.ToList().Count == 0)
                {
                    ViewBag.personelList = pm.TGetList().Where(x => x.PersonelAdi == "none");
                }
            }
            else
            {
                var tblPersonel = pm.TGetList().Where(x => x.PersonelAdi.ToString().ToUpper().Contains(personelAdi) && x.PersonelSoyadi.ToString().ToUpper().Contains(personelSoyadi) && x.Telefon.StartsWith(telefon) && x.CinsiyetId.ToString() == cinsiyet && x.Silindi == silindi);
                ViewBag.personelList = tblPersonel;
            }


            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpGet]
        public IActionResult PersonelKartiGor(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult PersonelKartiGuncelle(int id)
        {
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.pozisyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.id = id;
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return View();
        }

        [HttpPost]
        public IActionResult PersonelKartiGuncelle(Personel personel, int personelId, int olusturan, string olusturulmaTarihi)
        {
            try
            {
                string personelKodu = db.Personels.Where(x => x.PersonelId == personelId).FirstOrDefault().PersonelKodu;
                var tblKullanici = db2.Kullanicis.Where(x => x.KullaniciKodu == personelKodu).FirstOrDefault();
                if (tblKullanici != null)
                {

                    tblKullanici.KullaniciKodu = personelKodu;
                    tblKullanici.KullaniciAdi = personel.PersonelAdi;
                    tblKullanici.KullaniciAdi2 = personel.PersonelAdi2;
                    tblKullanici.KullaniciSoyadi = personel.PersonelSoyadi;
                    tblKullanici.PersonelKullaniciAdi = personel.PersonelKullaniciAdi;
                    tblKullanici.KullaniciMail = personel.Mail;
                    tblKullanici.KullaniciParola = personel.Parola;
                    km.TUpdate(tblKullanici);
                }
                else
                {
                    Kullanici kullanici = new Kullanici();
                    kullanici.KullaniciKodu = personelKodu;
                    kullanici.KullaniciAdi = personel.PersonelAdi;
                    kullanici.KullaniciAdi2 = personel.PersonelAdi2;
                    kullanici.KullaniciSoyadi = personel.PersonelSoyadi;
                    kullanici.PersonelKullaniciAdi = personel.PersonelKullaniciAdi;
                    kullanici.KullaniciMail = personel.Mail;
                    kullanici.KullaniciParola = personel.Parola;
                    km.TAdd(kullanici);
                }
                personel.PersonelKodu = personelKodu;
                personel.Olusturan = olusturan;
                personel.OlusturulmaTarih = DateTimeOffset.Parse(olusturulmaTarihi).UtcDateTime;
                personel.SonDegistiren = (int)HttpContext.Session.GetInt32("kullanici");
                personel.SonDegistirmeTarih = DateTime.UtcNow;
                pm.TUpdate(personel);
                return RedirectToAction("PersonelKarti");
            }
            catch (Exception ex)
            {
                ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
                ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
                ViewBag.pozisyonList = pznm.TGetList().Where(x => x.Silindi == false);
                ViewBag.id = personelId;
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                TempData["error"] = "err";
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                ViewBag.id = personelId;
                return View();
            }
        }

        [HttpGet]
        public IActionResult PersonelKartiEkle()
        {
            var personelList = pm.TGetList().Where(x => x.Silindi == false);
            ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
            ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.pozsiyonList = pznm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = personelList;
            return View();
        }

        [HttpPost]
        public IActionResult PersonelKartiEkle(Personel personel)
        {
            ViewBag.personelList = pm.TGetList().Where(x => x.Silindi == false);
            var tbPersonel = pm.TGetList().OrderBy(x => x.PersonelId);
            string personelKodu = "";
            if (tbPersonel.Count() == 0)
            {
                personelKodu = "p1";
            }
            else
            {
                int sira = Int32.Parse(tbPersonel.LastOrDefault().PersonelKodu.TrimStart('p'));
                sira += 1;
                personelKodu = "p" + sira.ToString();
            }
            try
            {

                Kullanici kullanici = new Kullanici();
                kullanici.KullaniciAdi = personel.PersonelAdi;
                kullanici.KullaniciAdi2 = personel.PersonelAdi2;
                kullanici.KullaniciSoyadi = personel.PersonelSoyadi;
                kullanici.PersonelKullaniciAdi = personel.PersonelKullaniciAdi;
                kullanici.KullaniciMail = personel.Mail;
                kullanici.KullaniciParola = personel.Parola;
                kullanici.KullaniciKodu = personelKodu;
                km.TAdd(kullanici);

            }

            catch (Exception ex)
            {
                ViewBag.unvanList = unvm.TGetList().Where(x => x.Silindi == false);
                ViewBag.departmanList = dptm.TGetList().Where(x => x.Silindi == false);
                ViewBag.pozisyonList = pznm.TGetList().Where(x => x.Silindi == false);
                ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
                ViewBag.personelList = pm.TGetList().Where(x => x.Silindi == false);
                TempData["error"] = "err";
                return View();
            }
            try
            {
                var kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                personel.SonDegistiren = kullaniciId;
                personel.Olusturan = kullaniciId;
                personel.SonDegistirmeTarih = DateTime.UtcNow.Date;
                personel.OlusturulmaTarih = DateTime.UtcNow;
                personel.PersonelKodu = personelKodu;
                pm.TAdd(personel);
            }
            catch (Exception ex)
            {
                TempData["error"] = "err";
                return View();
            }
            ViewBag.cinsiyetList = cnsm.TGetList().Where(x => x.Silindi == false);
            return RedirectToAction("PersonelKarti");
        }
        public ActionResult DeletePersonel(int id)
        {
            var personel = pm.TGetByID(id);
            personel.Silindi = true;
            pm.TUpdate(personel);
            return RedirectToAction("PersonelKarti");
        }
    }
}

