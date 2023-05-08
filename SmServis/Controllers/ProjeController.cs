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
    public class ProjeController : Controller
    {
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        PersonelTipiManager ptm = new PersonelTipiManager(new EfPersonelTipiDal());
        ParaBirimiManager pbm = new ParaBirimiManager(new EfParaBirimiDal());
        TempDanismanManager tdm = new TempDanismanManager(new EfTempDanismanDal());
        ProjeIcerikManager pim = new ProjeIcerikManager(new EfProjeIcerikDal());
        ServisProjeIcerikManager spim = new ServisProjeIcerikManager(new EfServisProjeIcerikDal());
        TempFiyatManager tfm = new TempFiyatManager(new EfTempFiyatDal());
        ProjeManager prjm = new ProjeManager(new EfProjeDal());
        CariManager cm = new CariManager(new EfCariDal());
        ModulManager mm = new ModulManager(new EfModulDal());
        TempServisProjeIcerikManager tspim = new TempServisProjeIcerikManager(new EfTempServisProjeIcerikDal());
        ProgramManager prgm = new ProgramManager(new EfProgramDal());
        TempCariProgramManager tcpm = new TempCariProgramManager(new EfTempCariProgramDal());
        CariPersonelManager cpm = new CariPersonelManager(new EfCariPersonelDal());
        FaturalamaPeriyoduManager fpm = new FaturalamaPeriyoduManager(new EfFaturalamaPeriyoduDal());
        TempFaturaMailManager tfmm = new TempFaturaMailManager(new EfTempFaturaMailDal());
        FaturaMailManager fmm = new FaturaMailManager(new EfFaturaMailDal());
        public IActionResult Proje()
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var tempDanisman = tdm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFiyatList = tfm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempServisProje = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var servisProjeIcerik = spim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempCariProgram = tcpm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFaturaMail = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            HttpContext.Session.Remove("projeCariId");
            HttpContext.Session.Remove("projeProgramId");
            HttpContext.Session.Remove("projePeriyotId");
            foreach (var item in tempDanisman)
            {
                tdm.TDelete(item);
            }
            foreach (var item in tempFiyatList)
            {
                tfm.TDelete(item);
            }
            foreach (var item in tempServisProje)
            {
                tspim.TDelete(item);
            }
            foreach (var item in servisProjeIcerik)
            {
                item.IsEdit = false;
                spim.TUpdate(item);
            }
            foreach (var item in tempCariProgram)
            {
                tcpm.TDelete(item);
            }
            foreach (var item in tempFaturaMail)
            {
                tfmm.TDelete(item);
            }
            ViewBag.projeList = prjm.TGetList().Where(x => x.Silindi == false);
            return View();
        }
        #region danismanProjesi
        [HttpGet]
        public IActionResult ProjeEkleDanisman(int? projeCariId, int? projeProgramId, int? projePeriyotId)
        {
            Vb();
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            if (projeCariId == null)
            {
                projeCariId = Convert.ToInt32(HttpContext.Session.GetInt32("projeCariId"));
            }
            if (projeProgramId == null)
            {
                projeProgramId = Convert.ToInt32(HttpContext.Session.GetInt32("projeProgramId"));
            }
            if (projePeriyotId == null)
            {
                projePeriyotId = Convert.ToInt32(HttpContext.Session.GetInt32("projePeriyotId"));
            }
            ViewBag.programList = prgm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariId = projeCariId;
            ViewBag.programId = projeProgramId;
            ViewBag.periyotId = projePeriyotId;
            ViewBag.periyotList = fpm.TGetList().Where(x => x.Silindi == false);
            ViewBag.tempFaturaMailList = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.cariPersonelList2 = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
            if (projeCariId != 0)
            {

                ViewBag.cariPersonelListFatura = tfmm.TGetList().Where(x => x.FaturaMailiGonderilecekMi == false);
                ViewBag.cariPersonelListFaturaP = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
                ViewBag.cariPersonelListServis = tfmm.TGetList().Where(x => x.ServisMailiGonderilecekMi == false);
                ViewBag.cariPersonelListServisP = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
            }
            else
            {
                ViewBag.cariPersonelListServis = cpm.TGetList().Where(x => x.CariPersonelId == 0);
                ViewBag.cariPersonelListFatura = cpm.TGetList().Where(x => x.CariPersonelId == 0);
            }
            ViewBag.cariPersonelList = cpm.TGetList().Where(x => x.CariId == projeCariId);
            Vb();
            ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
            ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            return View();
        }
        [HttpPost]
        public IActionResult ProjeEkleDanisman(int cariId, int programId, int periyotId,string tarihAraligi)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            var tblProje = prjm.TGetList().Where(x => x.Silindi == false);
            string projeNo;
            if (tblProje.Count() == 0)
            {
                projeNo = "100001";
            }
            else
            {
                projeNo = (Int32.Parse(prjm.TGetList().OrderByDescending(x => x.ProjeNo).FirstOrDefault().ProjeNo) + 1).ToString();
            }
            var tempDanisman = tdm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFiyatList = tfm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            Proje proje = new Proje();
            proje.ProjeBaslangicTarihi =DateTime.Parse( tarihAraligi.Substring(0, 10));
            proje.ProjeBitisTarihi = DateTime.Parse(tarihAraligi.Substring(tarihAraligi.Length - 10));
            proje.CariId = projeCariId;
            proje.ProgramId = programId;
            proje.FaturalamaPeriyoduId = periyotId;
            proje.SonDegistirmeTarih = DateTime.Now;
            proje.OlusturulmaTarih = DateTime.Now;
            proje.SonDegistiren = kullaniciId;
            proje.Olusturan = kullaniciId;
            proje.ProjeNo = projeNo;
            try
            {
                prjm.TAdd(proje);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Proje Eklenirken Bir Hata Oluştu";
                Vb();
                return View();
            }
            foreach (var danisman in tempDanisman)
            {
                foreach (var fiyat in tempFiyatList)
                {
                    if (danisman.PersonelTipiId == fiyat.PersonelTipiId)
                    {
                        ProjeIcerik projeIcerik = new ProjeIcerik();

                        projeIcerik.PersonelId = danisman.PersonelId;
                        projeIcerik.PersonelTipiId = danisman.PersonelTipiId;
                        projeIcerik.GecerlilikTarihBaslangic = (DateTime)fiyat.GecerlilikTarihBaslangic;
                        projeIcerik.GecerlilikTarihBitis = (DateTime)fiyat.GecerlilikTarihBitis;
                        projeIcerik.ParaBirimiId = (int)fiyat.ParaBirimiId;
                        projeIcerik.Fiyat = fiyat.Fiyat;
                        projeIcerik.SonDegistiren = kullaniciId;
                        projeIcerik.Olusturan = kullaniciId;
                        projeIcerik.OlusturulmaTarih = DateTime.Now;
                        projeIcerik.SonDegistirmeTarih = DateTime.Now;
                        projeIcerik.ProjeId = prjm.TGetList().Where(x => x.ProjeNo == proje.ProjeNo && x.Silindi == false).FirstOrDefault().ProjeId;

                        try
                        {
                            pim.TAdd(projeIcerik);
                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Proje İçeriği Eklenirken Bir Hata Oluştu";
                            Vb();
                            return View();
                        }
                    }
                }
            }
            var tempFaturaMail = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            foreach (var item in tempFaturaMail)
            {
                FaturaMail faturaMail = new FaturaMail();
                faturaMail.CariPersonelId = item.CariPersonelId;
                faturaMail.FaturaMailiGonderilecekMi = item.FaturaMailiGonderilecekMi;
                faturaMail.Olusturan = kullaniciId;
                faturaMail.OlusturulmaTarih = DateTime.Now;
                faturaMail.ProjeId = prjm.TGetList().Where(x => x.ProjeNo == proje.ProjeNo && x.Silindi == false).FirstOrDefault().ProjeId;
                faturaMail.ServisMailiGonderilecekMi = item.ServisMailiGonderilecekMi;
                faturaMail.SonDegistiren = kullaniciId;
                faturaMail.SonDegistirmeTarih = DateTime.Now;
                try
                {
                    fmm.TAdd(faturaMail);

                }
                catch (Exception ex)
                {
                    TempData["error"] = "Proje İçeriği Eklenirken Bir Hata Oluştu";
                    Vb();
                    ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
                    ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
                    return View();
                }
            }
            var tempCariProgram = tcpm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
            foreach (var item in tempCariProgram)
            {
                tcpm.TDelete(item);
            }
            foreach (var item in tempFaturaMail)
            {
                tfmm.TDelete(item);
            }
            return RedirectToAction("Proje");
        }
        [HttpPost]
        public IActionResult TempDanismanEkle([Bind(Prefix = "Item1")] TempDanisman tempDanisman)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            try
            {
                tempDanisman.SonDegistiren = kullaniciId;
                tempDanisman.Olusturan = kullaniciId;
                tempDanisman.SonDegistirmeTarih = DateTime.Now;
                tempDanisman.OlusturulmaTarih = DateTime.Now;
                tdm.TAdd(tempDanisman);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Daışman Eklenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeEkleDanisman");
            }

            ViewBag.tempDanismanList = tdm.TGetList();
            return RedirectToAction("ProjeEkleDanisman");

        }
        [HttpPost]
        public IActionResult TempDanismanDuzenle([Bind(Prefix = "Item1")] TempDanisman tempDanisman, int danismanId)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                var tblTempDanisman = tdm.TGetByID(danismanId);
                tblTempDanisman.SonDegistirmeTarih = DateTime.UtcNow;
                tblTempDanisman.PersonelId = tempDanisman.PersonelId;
                tblTempDanisman.PersonelTipiId = tempDanisman.PersonelTipiId;
                tblTempDanisman.SonDegistiren = kullaniciId;
                tdm.TUpdate(tblTempDanisman);
                return RedirectToAction("ProjeEkleDanisman");


            }
            catch (Exception ex)
            {
                TempData["error"] = "Danışman Güncellenirken Bir Hata Oluştu";
                return View();
            }
        }
        public IActionResult TempDanismanSil(int id)
        {
            var tempDanisman = tdm.TGetByID(id);
            tdm.TDelete(tempDanisman);
            return RedirectToAction("ProjeEkleDanisman");
        }
        [HttpPost]
        public IActionResult TempFiyatEkle([Bind(Prefix = "Item2")] TempFiyatList tempFiyatList)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            try
            {
                tempFiyatList.SonDegistiren = kullaniciId;
                tempFiyatList.Olusturan = kullaniciId;
                tempFiyatList.SonDegistirmeTarih = DateTime.Now;
                tempFiyatList.OlusturulmaTarih = DateTime.Now;
                tfm.TAdd(tempFiyatList);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Fiyat Listeye Eklenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeEkleDanisman");
            }

            ViewBag.tempDanismanList = tdm.TGetList();
            return RedirectToAction("ProjeEkleDanisman");

        }
        [HttpPost]
        public IActionResult TempFiyatDuzenle([Bind(Prefix = "Item2")] TempFiyatList tempFiyatList, int fiyatListId)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                var tblTempFiyat = tfm.TGetByID(fiyatListId);
                tblTempFiyat.SonDegistirmeTarih = DateTime.UtcNow;
                tblTempFiyat.GecerlilikTarihBaslangic = tempFiyatList.GecerlilikTarihBaslangic;
                tblTempFiyat.GecerlilikTarihBitis = tempFiyatList.GecerlilikTarihBitis;
                tblTempFiyat.ParaBirimiId = tempFiyatList.ParaBirimiId;
                tblTempFiyat.PersonelTipiId = tempFiyatList.PersonelTipiId;
                tblTempFiyat.SonDegistiren = kullaniciId;
                tblTempFiyat.Fiyat = tempFiyatList.Fiyat;
                tfm.TUpdate(tblTempFiyat);
                return RedirectToAction("ProjeEkleDanisman");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Danışman Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeEkleDanisman");
            }
        }
        public IActionResult TempFiyatSil(int id)
        {
            var tempFiyatList = tfm.TGetByID(id);
            tfm.TDelete(tempFiyatList);
            return RedirectToAction("ProjeEkleDanisman");
        }

        [HttpGet]
        public IActionResult ProjeDuzenleDanisman(int id, bool isFirst = false)
        {
            Vb();
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var projeIcerik = pim.TGetList().Where(x => x.ProjeId == id && x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tblProje = prjm.TGetByID(id);
            HttpContext.Session.SetInt32("projePeriyotId", tblProje.FaturalamaPeriyoduId);
            HttpContext.Session.SetInt32("projeCariId", tblProje.CariId);
            HttpContext.Session.SetInt32("projeProgramId", tblProje.ProgramId);
            var tblFaturaMail = fmm.TGetList().Where(x => x.ProjeId == id);
            var tblTempFaturaMail = tfmm.TGetList().Where(x => x.Silindi == false && x.SonDegistiren == kullaniciId);
            if (tblTempFaturaMail.Count() == 0)
            {
                foreach (var item in tblFaturaMail)
                {
                    TempFaturaMail tempFaturaMail = new TempFaturaMail();
                    tempFaturaMail.CariPersonelId = item.CariPersonelId;
                    tempFaturaMail.FaturaMailiGonderilecekMi = item.FaturaMailiGonderilecekMi;
                    tempFaturaMail.Olusturan = item.Olusturan;
                    tempFaturaMail.OlusturulmaTarih = item.OlusturulmaTarih;
                    tempFaturaMail.ServisMailiGonderilecekMi = item.ServisMailiGonderilecekMi;
                    tempFaturaMail.SonDegistiren = kullaniciId;
                    tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                    tfmm.TAdd(tempFaturaMail);
                }
            }
            if (isFirst == true)
            {

                foreach (var item in projeIcerik)
                {
                    TempDanisman tempDanisman = new TempDanisman();
                    TempFiyatList tempFiyatList = new TempFiyatList();
                    tempDanisman.Olusturan = kullaniciId;
                    tempDanisman.OlusturulmaTarih = DateTime.Now;
                    tempDanisman.PersonelId = (int)item.PersonelId;
                    tempDanisman.PersonelTipiId = (int)item.PersonelTipiId;
                    tempDanisman.SonDegistiren = kullaniciId;
                    tempDanisman.SonDegistirmeTarih = DateTime.Now;
                    tempFiyatList.Fiyat = item.Fiyat;
                    tempFiyatList.GecerlilikTarihBaslangic = item.GecerlilikTarihBaslangic;
                    tempFiyatList.GecerlilikTarihBitis = item.GecerlilikTarihBitis;
                    tempFiyatList.Olusturan = kullaniciId;
                    tempFiyatList.OlusturulmaTarih = DateTime.Now;
                    tempFiyatList.ParaBirimiId = item.ParaBirimiId;
                    tempFiyatList.PersonelTipiId = item.PersonelTipiId;
                    tempFiyatList.SonDegistiren = kullaniciId;
                    tempFiyatList.SonDegistirmeTarih = DateTime.Now;
                    tdm.TAdd(tempDanisman);
                    tfm.TAdd(tempFiyatList);
                }
            }

            ViewBag.tempDanismanList = tdm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.tempFiyatList = tfm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.projeId = id;
            ViewBag.cariId = prjm.TGetByID(id).CariId;
            ViewBag.cariAdi = cm.TGetByID(prjm.TGetByID(id).CariId).CariAdi;
            ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
            ViewBag.faturaMailList = fmm.TGetList().Where(x => x.ProjeId == id && x.Silindi == false);
            ViewBag.tempFaturaMailList = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.cariPersonelList2 = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
            ViewBag.programList = prgm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariId = tblProje.CariId;
            ViewBag.programId = tblProje.ProgramId;
            ViewBag.periyotId = tblProje.FaturalamaPeriyoduId;
            ViewBag.periyotList = fpm.TGetList().Where(x => x.Silindi == false);
            return View();
        }
        [HttpPost]
        public IActionResult ProjeEkleDanismanG(int projeId, int cariId, int programId, int periyotId)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");

            var tblProje = prjm.TGetByID(projeId);
            var tempDanisman = tdm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFiyatList = tfm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFaturaMail = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tblFaturaMail = fmm.TGetList().Where(x => x.ProjeId == projeId && x.Silindi == false);
            tblProje.ProgramId = programId;
            tblProje.FaturalamaPeriyoduId = periyotId;
            tblProje.SonDegistirmeTarih = DateTime.Now;
            tblProje.SonDegistiren = kullaniciId;

            try
            {
                prjm.TUpdate(tblProje);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Proje Eklenirken Bir Hata Oluştu";
                Vb();
                return View();
            }
            var projeIcerikSil = pim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.ProjeId == projeId);
            foreach (var item in projeIcerikSil)
            {
                pim.TDelete(item);
            }
            foreach (var danisman in tempDanisman)
            {
                foreach (var fiyat in tempFiyatList)
                {
                    if (danisman.PersonelTipiId == fiyat.PersonelTipiId)
                    {
                        ProjeIcerik projeIcerik = new ProjeIcerik();
                        projeIcerik.PersonelId = danisman.PersonelId;
                        projeIcerik.PersonelTipiId = danisman.PersonelTipiId;
                        projeIcerik.GecerlilikTarihBaslangic = (DateTime)fiyat.GecerlilikTarihBaslangic;
                        projeIcerik.GecerlilikTarihBitis = (DateTime)fiyat.GecerlilikTarihBitis;
                        projeIcerik.ParaBirimiId = (int)fiyat.ParaBirimiId;
                        projeIcerik.Fiyat = fiyat.Fiyat;
                        projeIcerik.SonDegistiren = kullaniciId;
                        projeIcerik.Olusturan = kullaniciId;
                        projeIcerik.OlusturulmaTarih = DateTime.Now;
                        projeIcerik.SonDegistirmeTarih = DateTime.Now;
                        projeIcerik.ProjeId = prjm.TGetList().Where(x => x.ProjeNo == tblProje.ProjeNo && x.Silindi == false).FirstOrDefault().ProjeId;
                        try
                        {

                            pim.TAdd(projeIcerik);
                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Proje İçeriği Eklenirken Bir Hata Oluştu";
                            Vb();
                            return View();
                        }
                    }
                }
            }
            try
            {
                foreach (var item in tempFaturaMail)
                {
                    FaturaMail faturaMail = new FaturaMail();
                    faturaMail.CariPersonelId = item.CariPersonelId;
                    faturaMail.FaturaMailiGonderilecekMi = item.FaturaMailiGonderilecekMi;
                    faturaMail.Olusturan = item.Olusturan;
                    faturaMail.OlusturulmaTarih = item.OlusturulmaTarih;
                    faturaMail.ProjeId = projeId;
                    faturaMail.ServisMailiGonderilecekMi = item.ServisMailiGonderilecekMi;
                    faturaMail.SonDegistiren = kullaniciId;
                    faturaMail.SonDegistirmeTarih = DateTime.Now;
                    fmm.TAdd(faturaMail);
                }
                foreach (var item in tblFaturaMail)
                {
                    fmm.TDelete(item);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = cariId, projeProgramId = programId, projePeriyotId = periyotId });
            }


            return RedirectToAction("Proje");
        }
        [HttpPost]
        public IActionResult TempFiyatDuzenleG([Bind(Prefix = "Item2")] TempFiyatList tempFiyatList, int fiyatListId, int projeId)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                var tblTempFiyat = tfm.TGetByID(fiyatListId);
                tblTempFiyat.SonDegistirmeTarih = DateTime.UtcNow;
                tblTempFiyat.GecerlilikTarihBaslangic = tempFiyatList.GecerlilikTarihBaslangic;
                tblTempFiyat.GecerlilikTarihBitis = tempFiyatList.GecerlilikTarihBitis;
                tblTempFiyat.ParaBirimiId = tempFiyatList.ParaBirimiId;
                tblTempFiyat.PersonelTipiId = tempFiyatList.PersonelTipiId;
                tblTempFiyat.SonDegistiren = kullaniciId;
                tblTempFiyat.Fiyat = tempFiyatList.Fiyat;
                tfm.TUpdate(tblTempFiyat);
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });
            }
            catch (Exception ex)
            {
                TempData["error"] = "Danışman Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });
            }
        }
        [HttpPost]
        public IActionResult TempDanismanDuzenleG([Bind(Prefix = "Item1")] TempDanisman tempDanisman, int danismanId, int projeId)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                var tblTempDanisman = tdm.TGetByID(danismanId);
                tblTempDanisman.SonDegistirmeTarih = DateTime.UtcNow;
                tblTempDanisman.PersonelId = tempDanisman.PersonelId;
                tblTempDanisman.PersonelTipiId = tempDanisman.PersonelTipiId;
                tblTempDanisman.SonDegistiren = kullaniciId;
                tdm.TUpdate(tblTempDanisman);
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });


            }
            catch (Exception ex)
            {
                TempData["error"] = "Danışman Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });
            }
        }
        [HttpPost]
        public IActionResult TempDanismanEkleG([Bind(Prefix = "Item1")] TempDanisman tempDanisman, int projeId)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            try
            {
                tempDanisman.SonDegistiren = kullaniciId;
                tempDanisman.Olusturan = kullaniciId;
                tempDanisman.SonDegistirmeTarih = DateTime.Now;
                tempDanisman.OlusturulmaTarih = DateTime.Now;
                tdm.TAdd(tempDanisman);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Daışman Eklenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });
            }

            ViewBag.tempDanismanList = tdm.TGetList();
            return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });

        }
        [HttpPost]
        public IActionResult TempFiyatEkleG([Bind(Prefix = "Item2")] TempFiyatList tempFiyatList, int projeId)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            try
            {
                tempFiyatList.SonDegistiren = kullaniciId;
                tempFiyatList.Olusturan = kullaniciId;
                tempFiyatList.SonDegistirmeTarih = DateTime.Now;
                tempFiyatList.OlusturulmaTarih = DateTime.Now;
                tfm.TAdd(tempFiyatList);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Fiyat Listeye Eklenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });
            }

            ViewBag.tempDanismanList = tdm.TGetList();
            return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId });

        }
        [HttpGet]
        public IActionResult ProjeGorDanisman(int id)
        {
            var tblProje = prjm.TGetByID(id);
            HttpContext.Session.SetInt32("projeCariId", tblProje.CariId);
            HttpContext.Session.SetInt32("projeProgramId", tblProje.ProgramId);
            HttpContext.Session.SetInt32("projePeriyotId", tblProje.FaturalamaPeriyoduId);
            ViewBag.projeId = id;
            ViewBag.projeIcerikList = pim.TGetList().Where(x => x.ProjeId == id && x.Silindi == false);
            ViewBag.faturaMailList = fmm.TGetList().Where(x => x.ProjeId == id && x.Silindi == false);
            return View();
        }
        #endregion

        #region servisProjesi
        [HttpGet]
        public IActionResult ProjeEkleServis(int[] smPersonelIds, int[] fmPersonelIds, int? projeCariId, int? projeProgramId, int? projePeriyotId,string projeBaslangicTarihi,string projeBitisTarihi)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            if (projeCariId == null)
            {
                projeCariId = Convert.ToInt32(HttpContext.Session.GetInt32("projeCariId"));
            }
            if (projeProgramId == null)
            {
                projeProgramId = Convert.ToInt32(HttpContext.Session.GetInt32("projeProgramId"));
            }
            if (projePeriyotId == null)
            {
                projePeriyotId = Convert.ToInt32(HttpContext.Session.GetInt32("projePeriyotId"));
            }
            if (projeBaslangicTarihi == null)
            {
                projeBaslangicTarihi = HttpContext.Session.GetString("projeBaslangicTarihi");
            }
            if (projeBitisTarihi == null)
            {
                projeBitisTarihi = HttpContext.Session.GetString("projeBitisTarihi");
            }
            //if (projeCariId == null)
            //{
            //    projeCariId = 0;
            //}
            //if (projeProgramId == null)
            //{
            //    projeProgramId = 0;
            //}
            //if (projePeriyotId == null)
            //{
            //    projePeriyotId = 0;
            //}
            ViewBag.programList = prgm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariId = projeCariId;
            ViewBag.programId = projeProgramId;
            ViewBag.periyotId = projePeriyotId;
            ViewBag.periyotList = fpm.TGetList().Where(x => x.Silindi == false);
            ViewBag.smPersonelIds = smPersonelIds;
            ViewBag.fmPersonelIds = fmPersonelIds;
            ViewBag.tempFaturaMailList = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.cariPersonelList2 = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
            if (projeCariId != 0)
            {

                //     var list = db.Users.Where(user => !db.Fi.Any(f => f.UserID == user.UserID))
                //.Select(user => user.UserName).ToList()
                //ViewBag.cariPersonelList = cpm.TGetList().Where(x => x.CariId == projeCariId&&x.Silindi==false);
                //var a= cpm.TGetList().Where(x => x.CariId == projeCariId && x.Silindi == false);
                //var b= cpm.TGetList().Where(x => !tfmm.TGetList().Any(y => y.CariPersonelId == x.CariPersonelId));
                // ViewBag.cariPersonelListServis = tfmm.TGetList().Where(x => x.ServisMailiGonderilecekMi == false || cpm.TGetList().Any(t=>x.CariPersonelId!=t.CariPersonelId));
                // ViewBag.cariPersonelListServis = tfmm.TGetList().Where(x =>x.ServisMailiGonderilecekMi==false && !cpm.TGetList().Any(t => t.CariPersonelId == x.CariPersonelId));
                ViewBag.cariPersonelListFatura = tfmm.TGetList().Where(x => x.FaturaMailiGonderilecekMi == false);
                ViewBag.cariPersonelListFaturaP = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
                ViewBag.cariPersonelListServis = tfmm.TGetList().Where(x => x.ServisMailiGonderilecekMi == false);
                ViewBag.cariPersonelListServisP = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));

                //       ViewBag.cariPersonelListFatura = cpm.TGetList().Where(x => !tfmm.TGetList().Any(y => y.CariPersonelId == x.CariPersonelId) && x.ServisFaturaGonder == false);
            }
            else
            {
                ViewBag.cariPersonelListServis = cpm.TGetList().Where(x => x.CariPersonelId == 0);
                ViewBag.cariPersonelListFatura = cpm.TGetList().Where(x => x.CariPersonelId == 0);

            }
            ViewBag.cariPersonelList = cpm.TGetList().Where(x => x.CariId == projeCariId);
            Vb();
            ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
            ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            return View();
        }

        [HttpPost]
        public IActionResult ProjeEkleServis(int cariId, int programId, int periyotId, string tarihAraligi)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            var tblProje = prjm.TGetList().Where(x => x.Silindi == false);
            string projeNo;
            if (tblProje.Count() == 0)
            {
                projeNo = "100001";
            }
            else
            {
                projeNo = (Int32.Parse(prjm.TGetList().OrderByDescending(x => x.ProjeNo).FirstOrDefault().ProjeNo) + 1).ToString();
            }
            var tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            Proje proje = new Proje();
            proje.CariId = cariId;
            proje.ProgramId = programId;
            proje.FaturalamaPeriyoduId = periyotId;
            proje.ProjeBaslangicTarihi = DateTime.Parse(tarihAraligi.Substring(0, 10));
            proje.ProjeBitisTarihi = DateTime.Parse(tarihAraligi.Substring(tarihAraligi.Length - 10));
            proje.SonDegistirmeTarih = DateTime.Now;
            proje.OlusturulmaTarih = DateTime.Now;
            proje.SonDegistiren = kullaniciId;
            proje.Olusturan = kullaniciId;
            proje.ProjeNo = projeNo;
            proje.ServisProjesi = true;
            try
            {
                prjm.TAdd(proje);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Proje Eklenirken Bir Hata Oluştu";
                Vb();
                return View();
            }
            foreach (var item in tempServisProjeList)
            {
                ServisProjeIcerik projeIcerik = new ServisProjeIcerik();
                projeIcerik.ModulId = item.ModulId;
                projeIcerik.GecerlilikTarihBaslangic = (DateTime)item.GecerlilikTarihBaslangic;
                projeIcerik.GecerlilikTarihBitis = (DateTime)item.GecerlilikTarihBitis;
                projeIcerik.ParaBirimiId = (int)item.ParaBirimiId;
                projeIcerik.Fiyat = item.Fiyat;
                projeIcerik.SonDegistiren = kullaniciId;
                projeIcerik.Olusturan = kullaniciId;
                projeIcerik.OlusturulmaTarih = DateTime.Now;
                projeIcerik.SonDegistirmeTarih = DateTime.Now;
                projeIcerik.CariId = projeCariId;
                projeIcerik.ProjeId = prjm.TGetList().Where(x => x.ProjeNo == proje.ProjeNo && x.Silindi == false).FirstOrDefault().ProjeId;
                try
                {
                    spim.TAdd(projeIcerik);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Proje İçeriği Eklenirken Bir Hata Oluştu";
                    Vb();
                    ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
                    ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
                    return View();
                }
            }
            var tempFaturaMail = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            foreach (var item in tempFaturaMail)
            {
                FaturaMail faturaMail = new FaturaMail();
                faturaMail.CariPersonelId = item.CariPersonelId;
                faturaMail.FaturaMailiGonderilecekMi = item.FaturaMailiGonderilecekMi;
                faturaMail.Olusturan = kullaniciId;
                faturaMail.OlusturulmaTarih = DateTime.Now;
                faturaMail.ProjeId = prjm.TGetList().Where(x => x.ProjeNo == proje.ProjeNo && x.Silindi == false).FirstOrDefault().ProjeId;
                faturaMail.ServisMailiGonderilecekMi = item.ServisMailiGonderilecekMi;
                faturaMail.SonDegistiren = kullaniciId;
                faturaMail.SonDegistirmeTarih = DateTime.Now;
                try
                {
                    fmm.TAdd(faturaMail);

                }
                catch (Exception ex)
                {
                    TempData["error"] = "Proje İçeriği Eklenirken Bir Hata Oluştu";
                    Vb();
                    ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
                    ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
                    return View();
                }
            }
            var tempCariProgram = tcpm.TGetList().Where(x => x.SonDegistiren == kullaniciId);
            foreach (var item in tempCariProgram)
            {
                tcpm.TDelete(item);
            }
            foreach (var item in tempFaturaMail)
            {
                tfmm.TDelete(item);
            }
            return RedirectToAction("Proje");

        }

        [HttpPost]
        public IActionResult TempProjeEkleServis(TempServisProjeIcerik tempServisProjeIcerik)
        {
            int cariId = (int)HttpContext.Session.GetInt32("projeCariId");
            var proje = spim.TGetList().Where(x => x.Silindi == false && x.CariId == cariId && x.ModulId == tempServisProjeIcerik.ModulId);
            foreach (var item in proje)
            {
                var firstOverlapDateRange = new DateRange(item.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);
                var secondOverlapDateRange = new DateRange(tempServisProjeIcerik.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);

                bool cakisma = firstOverlapDateRange.Overlap(secondOverlapDateRange);
                if (cakisma == true)
                {
                    TempData["error"] = "Aynı Caride Seçilen Servis Modülü Tarih Çakışması";
                    return RedirectToAction("ProjeEkleServis");
                }
            }
            var proje1 = tspim.TGetList().Where(x => x.Silindi == false && x.CariId == cariId && x.ModulId == tempServisProjeIcerik.ModulId);
            foreach (var item in proje1)
            {
                var firstOverlapDateRange = new DateRange(item.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);
                var secondOverlapDateRange = new DateRange(tempServisProjeIcerik.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);

                bool cakisma = firstOverlapDateRange.Overlap(secondOverlapDateRange);
                if (cakisma == true)
                {
                    TempData["error"] = "Aynı Caride Seçilen Servis Modülü Tarih Çakışması";
                    return RedirectToAction("ProjeEkleServis");
                }
            }
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            tempServisProjeIcerik.SonDegistiren = kullaniciId;
            tempServisProjeIcerik.Olusturan = kullaniciId;
            tempServisProjeIcerik.SonDegistirmeTarih = DateTime.Now;
            tempServisProjeIcerik.OlusturulmaTarih = DateTime.Now;
            tempServisProjeIcerik.CariId = cariId;
            try
            {
                tspim.TAdd(tempServisProjeIcerik);
                ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
                return RedirectToAction("ProjeEkleServis");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Eklenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeEkleServis");
            }
        }

        [HttpPost]
        public IActionResult TempServisProjeDuzenle(TempServisProjeIcerik tempServisProjeIcerik, int servisProjeId)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                int cariId = (int)HttpContext.Session.GetInt32("projeCariId");
                var tblTempServis = tspim.TGetByID(servisProjeId);
                var proje = spim.TGetList().Where(x => x.Silindi == false && x.CariId == cariId && x.ModulId == tempServisProjeIcerik.ModulId);
                foreach (var item in proje)
                {
                    var firstOverlapDateRange = new DateRange(item.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);
                    var secondOverlapDateRange = new DateRange(tempServisProjeIcerik.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);

                    bool cakisma = firstOverlapDateRange.Overlap(secondOverlapDateRange);
                    if (cakisma == true)
                    {
                        TempData["error"] = "Aynı Caride Seçilen Servis Modülü Tarih Çakışması";
                        return RedirectToAction("ProjeEkleServis");
                    }
                }
                var proje1 = tspim.TGetList().Where(x => x.Silindi == false && x.CariId == cariId && x.ModulId == tempServisProjeIcerik.ModulId);
                foreach (var item in proje1)
                {
                    var firstOverlapDateRange = new DateRange(item.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);
                    var secondOverlapDateRange = new DateRange(tempServisProjeIcerik.GecerlilikTarihBaslangic, item.GecerlilikTarihBitis);

                    bool cakisma = firstOverlapDateRange.Overlap(secondOverlapDateRange);
                    if (cakisma == true)
                    {
                        TempData["error"] = "Aynı Caride Seçilen Servis Modülü Tarih Çakışması";
                        return RedirectToAction("ProjeEkleServis");
                    }
                }
                tblTempServis.SonDegistirmeTarih = DateTime.UtcNow;
                tblTempServis.GecerlilikTarihBaslangic = tempServisProjeIcerik.GecerlilikTarihBaslangic;
                tblTempServis.GecerlilikTarihBitis = tempServisProjeIcerik.GecerlilikTarihBitis;
                tblTempServis.ParaBirimiId = tempServisProjeIcerik.ParaBirimiId;
                tblTempServis.ModulId = tempServisProjeIcerik.ModulId;
                tblTempServis.SonDegistiren = kullaniciId;
                tblTempServis.Fiyat = tempServisProjeIcerik.Fiyat;
                tspim.TUpdate(tblTempServis);
                return RedirectToAction("ProjeEkleServis");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeEkleServis");
            }
        }
        [HttpPost]
        public IActionResult TempProjeEkleServisG(TempServisProjeIcerik tempServisProjeIcerik, int projeId)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            int cariId = (int)HttpContext.Session.GetInt32("projeCariId");
            tempServisProjeIcerik.SonDegistiren = kullaniciId;
            tempServisProjeIcerik.Olusturan = kullaniciId;
            tempServisProjeIcerik.SonDegistirmeTarih = DateTime.Now;
            tempServisProjeIcerik.OlusturulmaTarih = DateTime.Now;
            tempServisProjeIcerik.CariId = cariId;
            try
            {
                tspim.TAdd(tempServisProjeIcerik);
                ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
                return RedirectToAction("ProjeDuzenleServis", new { id = projeId });
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Eklenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = projeId });
            }

        }
        [HttpPost]
        public IActionResult TempServisProjeDuzenleG(TempServisProjeIcerik tempServisProjeIcerik, int servisProjeId, int tempServisProjeIcerikId)
        {
            try
            {
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
                var tblTempServis = tspim.TGetByID(tempServisProjeIcerikId);
                tblTempServis.SonDegistirmeTarih = DateTime.UtcNow;
                tblTempServis.GecerlilikTarihBaslangic = tempServisProjeIcerik.GecerlilikTarihBaslangic;
                tblTempServis.GecerlilikTarihBitis = tempServisProjeIcerik.GecerlilikTarihBitis;
                tblTempServis.ParaBirimiId = tempServisProjeIcerik.ParaBirimiId;
                tblTempServis.ModulId = tempServisProjeIcerik.ModulId;
                tblTempServis.SonDegistiren = kullaniciId;
                tblTempServis.Fiyat = tempServisProjeIcerik.Fiyat;
                tspim.TUpdate(tblTempServis);
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId });
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId });
            }
        }
        [HttpPost]
        public IActionResult ServisProjeDuzenleG(TempServisProjeIcerik tempServisProjeIcerik, int servisProjeId, int tempServisProjeIcerikId)
        {
            try
            {
                var servisProjeIcerik = spim.TGetByID(tempServisProjeIcerikId);
                int cariId = (int)HttpContext.Session.GetInt32("projeCariId");
                servisProjeIcerik.IsEdit = true;
                spim.TUpdate(servisProjeIcerik);
                int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");

                var tblTempServis = tspim.TGetByID(tempServisProjeIcerikId);
                tempServisProjeIcerik.SonDegistirmeTarih = DateTime.UtcNow;
                tempServisProjeIcerik.OlusturulmaTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                tempServisProjeIcerik.SonDegistiren = kullaniciId;
                tempServisProjeIcerik.Olusturan = kullaniciId;
                tempServisProjeIcerik.CariId = cariId;
                tspim.TAdd(tempServisProjeIcerik);
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId });
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId });
            }
        }
        public IActionResult TempFiyatSilServisProje(int id)
        {
            var tempServisProje = tspim.TGetByID(id);
            tspim.TDelete(tempServisProje);
            return RedirectToAction("ProjeDuzenleServis");
        }

        [HttpGet]
        public IActionResult ProjeDuzenleServis(int id, int projePeriyotId, int projeProgramId, int projeCariId)
        {
            Vb();
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var tblProje = prjm.TGetByID(id);
            HttpContext.Session.SetInt32("projePeriyotId", tblProje.FaturalamaPeriyoduId);
            HttpContext.Session.SetInt32("projeCariId", tblProje.CariId);
            HttpContext.Session.SetInt32("projeProgramId", tblProje.ProgramId);
            var tblFaturaMail = fmm.TGetList().Where(x => x.ProjeId == id);
            var tblTempFaturaMail = tfmm.TGetList().Where(x => x.Silindi == false && x.SonDegistiren == kullaniciId);
            if (tblTempFaturaMail.Count() == 0)
            {
                foreach (var item in tblFaturaMail)
                {
                    TempFaturaMail tempFaturaMail = new TempFaturaMail();
                    tempFaturaMail.CariPersonelId = item.CariPersonelId;
                    tempFaturaMail.FaturaMailiGonderilecekMi = item.FaturaMailiGonderilecekMi;
                    tempFaturaMail.Olusturan = item.Olusturan;
                    tempFaturaMail.OlusturulmaTarih = item.OlusturulmaTarih;
                    tempFaturaMail.ServisMailiGonderilecekMi = item.ServisMailiGonderilecekMi;
                    tempFaturaMail.SonDegistiren = kullaniciId;
                    tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                    tfmm.TAdd(tempFaturaMail);
                }
            }

            ViewBag.projeId = id;
            ViewBag.cariId = prjm.TGetByID(id).CariId;
            ViewBag.cariAdi = cm.TGetByID(prjm.TGetByID(id).CariId).CariAdi;
            ViewBag.modulList = mm.TGetList().Where(x => x.Silindi == false);
            ViewBag.tempServisProjeList = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.faturaMailList = fmm.TGetList().Where(x => x.ProjeId == id && x.Silindi == false);
            ViewBag.tempFaturaMailList = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            ViewBag.servisProjeList = spim.TGetList().Where(x => x.ProjeId == id && x.IsEdit == false && x.Silindi == false);
            ViewBag.cariPersonelList2 = cpm.TGetList().Where(x => x.Silindi == false && !tfmm.TGetList().Any(t => x.CariPersonelId == t.CariPersonelId));
            ViewBag.programList = prgm.TGetList().Where(x => x.Silindi == false);
            ViewBag.cariId = tblProje.CariId;
            ViewBag.programId = tblProje.ProgramId;
            ViewBag.periyotId = tblProje.FaturalamaPeriyoduId;
            ViewBag.periyotList = fpm.TGetList().Where(x => x.Silindi == false);
            return View();
        }
        [HttpPost]
        public IActionResult ProjeEkleServisG(int servisProjeId, int periyotId, int programId)
        {
            var cariId = prjm.TGetByID(servisProjeId).CariId;
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var projeIcerikMevcut = spim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.IsEdit == true && x.Silindi == false);
            var tempProjeIcerik = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFaturaMail = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tblFaturaMail = fmm.TGetList().Where(x => x.ProjeId == servisProjeId && x.Silindi == false);
            var tblProje = prjm.TGetByID(servisProjeId);
            try
            {
                tblProje.FaturalamaPeriyoduId = periyotId;
                tblProje.ProgramId = programId;
                tblProje.SonDegistirmeTarih = DateTime.Now;
                tblProje.SonDegistiren = kullaniciId;
                prjm.TUpdate(tblProje);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId, projeCariId = projeCariId, projeProgramId = programId, projePeriyotId = periyotId });
            }
            try
            {
                foreach (var item in tempProjeIcerik)
                {
                    ServisProjeIcerik servisProjeIcerik = new ServisProjeIcerik();
                    servisProjeIcerik.Fiyat = item.Fiyat;
                    servisProjeIcerik.GecerlilikTarihBaslangic = item.GecerlilikTarihBaslangic;
                    servisProjeIcerik.GecerlilikTarihBitis = item.GecerlilikTarihBitis;
                    servisProjeIcerik.IsEdit = false;
                    servisProjeIcerik.ModulId = item.ModulId;
                    servisProjeIcerik.Olusturan = kullaniciId;
                    servisProjeIcerik.OlusturulmaTarih = DateTime.Now;
                    servisProjeIcerik.ParaBirimiId = item.ParaBirimiId;
                    servisProjeIcerik.ProjeId = servisProjeId;
                    servisProjeIcerik.SonDegistiren = kullaniciId;
                    servisProjeIcerik.SonDegistirmeTarih = DateTime.Now;
                    servisProjeIcerik.CariId = projeCariId;
                    spim.TAdd(servisProjeIcerik);
                }
                foreach (var item in projeIcerikMevcut)
                {
                    spim.TDelete(item);
                }
            }
            catch (Exception ex)
            {
                Vb();
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId, projeCariId = projeCariId, projeProgramId = programId, projePeriyotId = periyotId });
            }
            try
            {
                foreach (var item in tempFaturaMail)
                {
                    FaturaMail faturaMail = new FaturaMail();
                    faturaMail.CariPersonelId = item.CariPersonelId;
                    faturaMail.FaturaMailiGonderilecekMi = item.FaturaMailiGonderilecekMi;
                    faturaMail.Olusturan = item.Olusturan;
                    faturaMail.OlusturulmaTarih = item.OlusturulmaTarih;
                    faturaMail.ProjeId = servisProjeId;
                    faturaMail.ServisMailiGonderilecekMi = item.ServisMailiGonderilecekMi;
                    faturaMail.SonDegistiren = kullaniciId;
                    faturaMail.SonDegistirmeTarih = DateTime.Now;
                    fmm.TAdd(faturaMail);
                }
                foreach (var item in tblFaturaMail)
                {
                    fmm.TDelete(item);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Servis Projesi Güncellenirken Bir Hata Oluştu";
                return RedirectToAction("ProjeDuzenleServis", new { id = servisProjeId, projeCariId = projeCariId, projeProgramId = programId, projePeriyotId = periyotId });
            }
            return RedirectToAction("Proje");

        }
        [HttpPost]
        public IActionResult TempFaturaMailEkle(List<int> smPersonelIds, List<int> fmPersonelIds, int cariPersonelId, int periyotId, bool isFirst, string faturaMaili, string servisMaili, string proje)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int projeProgramId = (int)HttpContext.Session.GetInt32("projeProgramId");
            int projePeriyotId = (int)HttpContext.Session.GetInt32("projePeriyotId");

            if (isFirst == true)
            {
                for (int i = 0; i < fmPersonelIds.Count(); i++)
                {
                    TempFaturaMail tempFaturaMail = new TempFaturaMail();
                    tempFaturaMail.CariPersonelId = fmPersonelIds[i];
                    tempFaturaMail.Olusturan = kullaniciId;
                    tempFaturaMail.OlusturulmaTarih = DateTime.Now;
                    tempFaturaMail.FaturaMailiGonderilecekMi = true;
                    tempFaturaMail.SonDegistiren = kullaniciId;
                    tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                    for (int j = 0; j < smPersonelIds.Count(); j++)
                    {
                        if (fmPersonelIds[i] == smPersonelIds[j])
                        {
                            tempFaturaMail.ServisMailiGonderilecekMi = true;
                        }
                    }
                    try
                    {
                        tfmm.TAdd(tempFaturaMail);
                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = "Personel Eklenirken Bir Hata Oluştu";
                        if (proje == "servis")
                        {
                            return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
                        }
                        else
                        {
                            return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
                        }

                    }
                }
                for (int i = 0; i < smPersonelIds.Count(); i++)
                {
                    if (!fmPersonelIds.Contains(smPersonelIds[i]))
                    {
                        TempFaturaMail tempFaturaMail = new TempFaturaMail();
                        tempFaturaMail.CariPersonelId = smPersonelIds[i];
                        tempFaturaMail.Olusturan = kullaniciId;
                        tempFaturaMail.OlusturulmaTarih = DateTime.Now;
                        tempFaturaMail.ServisMailiGonderilecekMi = true;
                        tempFaturaMail.SonDegistiren = kullaniciId;
                        tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                        try
                        {
                            tfmm.TAdd(tempFaturaMail);

                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Personel Eklenirken Bir Hata Oluştu";
                            if (proje == "servis")
                            {
                                return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
                            }
                            else
                            {
                                return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
                            }
                        }
                    }
                }
            }
            else
            {
                TempFaturaMail tempFaturaMail = new TempFaturaMail();
                tempFaturaMail.CariPersonelId = cariPersonelId;
                if (faturaMaili == "on")
                {
                    tempFaturaMail.FaturaMailiGonderilecekMi = true;
                }
                if (servisMaili == "on")
                {
                    tempFaturaMail.ServisMailiGonderilecekMi = true;
                }
                tempFaturaMail.Olusturan = kullaniciId;
                tempFaturaMail.OlusturulmaTarih = DateTime.Now;
                tempFaturaMail.SonDegistiren = kullaniciId;
                tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                try
                {
                    tfmm.TAdd(tempFaturaMail);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Personel Eklenirken Bir Hata Oluştu";
                    if (proje == "servis")
                    {
                        return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
                    }
                    else
                    {
                        return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
                    }

                }
            }
            Vb();

            ViewBag.periyotList = fpm.TGetList().Where(x => x.Silindi == false);
            if (proje == "servis")
            {
                return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
            }
            else
            {
                return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds, periyotId = periyotId });
            }
        }
        [HttpPost]
        public IActionResult TempFaturaMailDuzenle(int personelId, string faturaMaili, string servisMaili, int tempFaturaMailId, string proje)
        {
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int projeProgramId = (int)HttpContext.Session.GetInt32("projeProgramId");
            int projePeriyotId = (int)HttpContext.Session.GetInt32("projePeriyotId");
            var tempFaturaMail = tfmm.TGetByID(tempFaturaMailId);
            if (faturaMaili == "on")
            {
                tempFaturaMail.FaturaMailiGonderilecekMi = true;
            }
            else
            {
                tempFaturaMail.FaturaMailiGonderilecekMi = false;
            }
            if (servisMaili == "on")
            {
                tempFaturaMail.ServisMailiGonderilecekMi = true;
            }
            else
            {
                tempFaturaMail.ServisMailiGonderilecekMi = false;
            }
            try
            {
                tfmm.TUpdate(tempFaturaMail);

            }
            catch (Exception ex)
            {
                TempData["error"] = "Personel Bilgileri Guncellenirken Bir Hata Oluştu";
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
                else
                {
                    return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
            }
            if (proje == "servis")
            {
                return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
            }
            else
            {
                return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
            }
        }
        public IActionResult TempFaturaMailEkleG(int projeId, List<int> smPersonelIds, List<int> fmPersonelIds, int cariPersonelId, bool isFirst, string faturaMaili, string servisMaili, string proje)
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int projeProgramId = (int)HttpContext.Session.GetInt32("projeProgramId");
            int projePeriyotId = (int)HttpContext.Session.GetInt32("projePeriyotId");

            if (isFirst == true)
            {
                for (int i = 0; i < fmPersonelIds.Count(); i++)
                {
                    TempFaturaMail tempFaturaMail = new TempFaturaMail();
                    tempFaturaMail.CariPersonelId = fmPersonelIds[i];
                    tempFaturaMail.Olusturan = kullaniciId;
                    tempFaturaMail.OlusturulmaTarih = DateTime.Now;
                    tempFaturaMail.FaturaMailiGonderilecekMi = true;
                    tempFaturaMail.SonDegistiren = kullaniciId;
                    tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                    for (int j = 0; j < smPersonelIds.Count(); j++)
                    {
                        if (fmPersonelIds[i] == smPersonelIds[j])
                        {
                            tempFaturaMail.ServisMailiGonderilecekMi = true;
                        }
                    }
                    try
                    {
                        tfmm.TAdd(tempFaturaMail);
                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = "Personel Eklenirken Bir Hata Oluştu";
                        if (proje == "servis")
                        {
                            return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
                        }
                        else
                        {
                            return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
                        }

                    }
                }
                for (int i = 0; i < smPersonelIds.Count(); i++)
                {
                    if (!fmPersonelIds.Contains(smPersonelIds[i]))
                    {
                        TempFaturaMail tempFaturaMail = new TempFaturaMail();
                        tempFaturaMail.CariPersonelId = smPersonelIds[i];
                        tempFaturaMail.Olusturan = kullaniciId;
                        tempFaturaMail.OlusturulmaTarih = DateTime.Now;
                        tempFaturaMail.ServisMailiGonderilecekMi = true;
                        tempFaturaMail.SonDegistiren = kullaniciId;
                        tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                        try
                        {
                            tfmm.TAdd(tempFaturaMail);

                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Personel Eklenirken Bir Hata Oluştu";
                            if (proje == "servis")
                            {
                                return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
                            }
                            else
                            {
                                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
                            }
                        }
                    }
                }
            }
            else
            {
                TempFaturaMail tempFaturaMail = new TempFaturaMail();
                tempFaturaMail.CariPersonelId = cariPersonelId;
                if (faturaMaili == "on")
                {
                    tempFaturaMail.FaturaMailiGonderilecekMi = true;
                }
                if (servisMaili == "on")
                {
                    tempFaturaMail.ServisMailiGonderilecekMi = true;
                }
                tempFaturaMail.Olusturan = kullaniciId;
                tempFaturaMail.OlusturulmaTarih = DateTime.Now;
                tempFaturaMail.SonDegistiren = kullaniciId;
                tempFaturaMail.SonDegistirmeTarih = DateTime.Now;
                try
                {
                    tfmm.TAdd(tempFaturaMail);
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Personel Eklenirken Bir Hata Oluştu";
                    if (proje == "servis")
                    {
                        return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
                    }
                    else
                    {
                        return RedirectToAction("ProjeDuzneleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
                    }

                }
            }
            Vb();

            ViewBag.periyotList = fpm.TGetList().Where(x => x.Silindi == false);
            if (proje == "servis")
            {
                return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
            }
            else
            {
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId, smPersonelIds = smPersonelIds, fmPersonelIds = fmPersonelIds });
            }
        }
        [HttpPost]
        public IActionResult TempFaturaMailDuzenleG(int projeId, int personelId, string faturaMaili, string servisMaili, int tempFaturaMailId, string proje)
        {
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int projeProgramId = (int)HttpContext.Session.GetInt32("projeProgramId");
            int projePeriyotId = (int)HttpContext.Session.GetInt32("projePeriyotId");
            var tempFaturaMail = tfmm.TGetByID(tempFaturaMailId);
            if (faturaMaili == "on")
            {
                tempFaturaMail.FaturaMailiGonderilecekMi = true;
            }
            else
            {
                tempFaturaMail.FaturaMailiGonderilecekMi = false;
            }
            if (servisMaili == "on")
            {
                tempFaturaMail.ServisMailiGonderilecekMi = true;
            }
            else
            {
                tempFaturaMail.ServisMailiGonderilecekMi = false;
            }
            try
            {
                tfmm.TUpdate(tempFaturaMail);

            }
            catch (Exception ex)
            {
                TempData["error"] = "Personel Bilgileri Guncellenirken Bir Hata Oluştu";
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
                else
                {
                    return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
            }
            if (proje == "servis")
            {
                return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
            }
            else
            {
                return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
            }
        }
        [HttpPost]
        public IActionResult FaturaMailDuzenleG(int faturaMailId, string faturaMaili, string servisMaili, string proje)
        {
            return View();
        }
        [HttpPost]
        public IActionResult TempFaturaMailSil(int id, string proje)
        {
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int projeProgramId = (int)HttpContext.Session.GetInt32("projeProgramId");
            int projePeriyotId = (int)HttpContext.Session.GetInt32("projePeriyotId");
            try
            {
                var tempFaturaMail = tfmm.TGetByID(id);
                tfmm.TDelete(tempFaturaMail);
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
                else
                {
                    return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Perosnel Silinirken Bir Hata Oluştu";
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
                else
                {
                    return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
            }
        }
        [HttpPost]
        public IActionResult TempFaturaMailSilG(int id, int projeId, string proje)
        {
            int projeCariId = (int)HttpContext.Session.GetInt32("projeCariId");
            int projeProgramId = (int)HttpContext.Session.GetInt32("projeProgramId");
            int projePeriyotId = (int)HttpContext.Session.GetInt32("projePeriyotId");
            try
            {
                var tempFaturaMail = tfmm.TGetByID(id);
                tfmm.TDelete(tempFaturaMail);
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
                else
                {
                    return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Perosnel Silinirken Bir Hata Oluştu";
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeDuzenleServis", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
                else
                {
                    return RedirectToAction("ProjeDuzenleDanisman", new { id = projeId, projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId });
                }
            }
        }
        [HttpGet]
        public IActionResult ProjeGorServis(int id)
        {
            var tblProje = prjm.TGetByID(id);
            HttpContext.Session.SetInt32("projeCariId", tblProje.CariId);
            HttpContext.Session.SetInt32("projeProgramId", tblProje.ProgramId);
            HttpContext.Session.SetInt32("projePeriyotId", tblProje.FaturalamaPeriyoduId);
            ViewBag.projeId = id;
            ViewBag.servisProjeList = spim.TGetList().Where(x => x.ProjeId == id && x.Silindi == false);
            ViewBag.faturaMailList = fmm.TGetList().Where(x => x.ProjeId == id && x.Silindi == false);
            return View();
        }
        #endregion

        #region javascript
        [HttpGet]
        public JsonResult PersonelGetir(int id)
        {
            var personel = pm.TGetByID(id);
            return Json(personel);
        }
        [HttpGet]
        public JsonResult PersonelGetirEdt(int id)
        {
            var personel = pm.TGetByID(tdm.TGetByID(id).PersonelId);
            return Json(personel);
        }
        [HttpGet]
        public JsonResult PersonelList()
        {
            var personel = pm.TGetList().Where(x => x.Silindi == false);
            return Json(personel);
        }
        [HttpGet]
        public JsonResult PersonelTipiGetir(int id)
        {
            var personelTpi = ptm.TGetByID(tdm.TGetByID(id).PersonelTipiId);
            return Json(personelTpi);
        }
        [HttpGet]
        public JsonResult PersonelTipiList()
        {
            var personelTipi = ptm.TGetList().Where(x => x.Silindi == false);
            return Json(personelTipi);
        }
        [HttpGet]
        public JsonResult PersonelTipiGetirFiyat(int id)
        {
            var personelTipi = ptm.TGetByID((int)tfm.TGetByID(id).PersonelTipiId);
            return Json(personelTipi);
        }
        [HttpGet]
        public JsonResult ParaBirimiGetir(int id)
        {
            var paraBirimi = pbm.TGetByID((int)tfm.TGetByID(id).ParaBirimiId);
            return Json(paraBirimi);
        }
        [HttpGet]
        public JsonResult ParaBirimiList()
        {
            var paraBirimi = pbm.TGetList().Where(x => x.Silindi == false);
            return Json(paraBirimi);
        }
        [HttpGet]
        public JsonResult ProjeIcerikGetir(int id)
        {
            var projeIcerik = tfm.TGetByID(id);
            return Json(projeIcerik);
        }
        [HttpGet]
        public JsonResult ModulGetirServisProje(int id)
        {
            var modul = mm.TGetByID((int)tspim.TGetByID(id).ModulId);
            return Json(modul);
        }
        [HttpGet]
        public JsonResult ModulGetirServisProjeG(int id)
        {
            var modul = mm.TGetByID((int)spim.TGetByID(id).ModulId);
            return Json(modul);
        }
        [HttpGet]
        public JsonResult ModulList()
        {
            var modul = mm.TGetList().Where(x => x.Silindi == false);
            return Json(modul);
        }
        [HttpGet]
        public JsonResult TempServisProjeIcerikGetir(int id)
        {
            var tempProjeIcerik = tspim.TGetByID(id);
            return Json(tempProjeIcerik);
        }
        [HttpGet]
        public JsonResult ServisProjeIcerikGetirG(int id)
        {
            var tempProjeIcerik = spim.TGetByID(id);
            return Json(tempProjeIcerik);
        }
        [HttpGet]
        public JsonResult ParaBirimiGetirServisProje(int id)
        {
            var paraBirimi = pbm.TGetByID((int)tspim.TGetByID(id).ParaBirimiId);
            return Json(paraBirimi);
        }
        [HttpGet]
        public JsonResult ParaBirimiGetirServisProjeG(int id)
        {
            var paraBirimi = pbm.TGetByID((int)spim.TGetByID(id).ParaBirimiId);
            return Json(paraBirimi);
        }
        [HttpGet]
        public JsonResult SayfaYonlendir(int id)
        {
            var proje = prjm.TGetByID(id);
            return Json(proje.ServisProjesi);
        }
        [HttpGet]
        public JsonResult CariPersonelGetir(int id)
        {
            var personel = cpm.TGetByID(tfmm.TGetByID(id).CariPersonelId);

            return Json(personel);
        }
        [HttpGet]
        public JsonResult MailGonder(int id)
        {
            var tempFaturaMail = tfmm.TGetByID(id);
            return Json(tempFaturaMail);
        }
        [HttpGet]
        public JsonResult PersonelIsFirst()
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            bool isfirst = false;
            var tempFaturaMail = tfmm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            if (tempFaturaMail.Count() == 0)
            {
                isfirst = true;
            }
            return Json(isfirst);
        }
        [HttpGet]
        public JsonResult PeriyotGetir(int id)
        {
            var periyot = fpm.TGetByID(id);
            HttpContext.Session.SetInt32("projePeriyotId", id);
            return Json(periyot);
        }
        [HttpGet]
        public JsonResult PeriyotList()
        {
            var periyot = fpm.TGetList().Where(x => x.Silindi == false);
            return Json(periyot);
        }
        [HttpGet]
        public JsonResult ProgramGetir(int id)
        {
            var program = prgm.TGetByID(id);
            HttpContext.Session.SetInt32("projeProgramId", id);
            return Json(program);
        }
        [HttpGet]
        public JsonResult ProgramList()
        {
            var program = prgm.TGetList().Where(x => x.Silindi == false);
            return Json(program);
        }
        [HttpGet]
        public JsonResult TarihAraligi(string tarih)
        {
            string tarih1=tarih.Substring(0, 10);
            string tarih2 = tarih.Substring(tarih.Length - 10);
            HttpContext.Session.SetString("projeBaslangicTarihi", tarih1);
            HttpContext.Session.SetString("projeBitisTarihi", tarih2);
            return Json(true);
        }
        #endregion
        [HttpGet]
        public IActionResult KaydetmedenCik()
        {
            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            var tempDanisman = tdm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempFiyatList = tfm.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            var tempServisProje = tspim.TGetList().Where(x => x.SonDegistiren == kullaniciId && x.Silindi == false);
            foreach (var item in tempDanisman)
            {
                tdm.TDelete(item);
            }
            foreach (var item in tempFiyatList)
            {
                tfm.TDelete(item);
            }
            foreach (var item in tempServisProje)
            {
                tspim.TDelete(item);
            }
            return RedirectToAction("Proje");
        }
        [HttpGet]
        public IActionResult ProjeSil(int id)
        {
            try
            {
                var proje = prjm.TGetByID(id);
                prjm.TDelete(proje);
                return RedirectToAction("Proje");
            }
            catch (Exception ex)
            {
                Vb();
                return RedirectToAction("ProjeDuzenleDanisman", new { id = id });
            }

        }
        [HttpPost]
        public IActionResult TempCariProgramEkleServis(int projeCariId, int projeProgramId, int projePeriyotId,string tarihAraligi ,string proje)
        {
            //var servisSiraNo = prjm.TGetList().Count;
            //string projeNo = "0";
            //if (servisSiraNo == 0)
            //{
            //  projeNo = "00001";
            //}
            //else
            //{
            //    var siraNo = prjm.TGetList().OrderByDescending(x => x.ProjeId).FirstOrDefault().ProjeNo.Substring(prjm.TGetList().OrderByDescending(x => x.ProjeNo).FirstOrDefault().ProjeNo.Length - 5);
            //    ViewBag.servisSiraNo = (Convert.ToInt32(siraNo) + 1).ToString("00000");

            //}

            int kullaniciId = (int)HttpContext.Session.GetInt32("kullanici");
            string baslangicTarihi = tarihAraligi.Substring(0, 10);
            string bitisTarihi = tarihAraligi.Substring(tarihAraligi.Length - 10);
            HttpContext.Session.SetInt32("projeCariId", projeCariId);
            HttpContext.Session.SetInt32("projeProgramId", projeProgramId);
            HttpContext.Session.SetInt32("projePeriyotId", projePeriyotId);
            HttpContext.Session.SetString("projeBaslangicTarihi", baslangicTarihi);
            HttpContext.Session.SetString("projeBitisTarihi", bitisTarihi);
            TempCariProgram tempCariProgram = new TempCariProgram();
            tempCariProgram.CariId = projeCariId;
            tempCariProgram.FaturalamaPeriyoduId = projePeriyotId;
            tempCariProgram.Olusturan = kullaniciId;
            tempCariProgram.OlusturulmaTarih = DateTime.Now;
            tempCariProgram.ProgramId = projeProgramId;
            tempCariProgram.SonDegistiren = kullaniciId;
            tempCariProgram.SonDegistirmeTarih = DateTime.Now;
            tempCariProgram.ProjeBaslangicTarihi = DateTime.Parse(baslangicTarihi);
            tempCariProgram.ProjeBitisTarihi = DateTime.Parse(bitisTarihi);
            try
            {
                tcpm.TAdd(tempCariProgram);
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId,projeBaslangicTarihi=baslangicTarihi,projeBitistarihi=bitisTarihi });
                }
                else
                {
                    return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId ,projeBaslangicTarihi=baslangicTarihi,projeBitisTarihi=bitisTarihi});
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Cari Eklenirken Bir Hata Oluştu";
                if (proje == "servis")
                {
                    return RedirectToAction("ProjeEkleServis", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId ,projeBaslangicTarihi=baslangicTarihi,projeBitisTarihi=bitisTarihi});
                }
                else
                {
                    return RedirectToAction("ProjeEkleDanisman", new { projeCariId = projeCariId, projeProgramId = projeProgramId, projePeriyotId = projePeriyotId ,projeBaslangicTarihi=baslangicTarihi,projeBitisTarihi=bitisTarihi});
                }
            }
        }
        [HttpGet]
        public ActionResult IcerikYonlendir(int id)
        {
            bool isServis = prjm.TGetByID(id).ServisProjesi;
            ViewBag.projeId = id;
            if (isServis == true)
            {
                return RedirectToAction("ProjeGorServis", new { id = id });
            }
            else
            {
                return RedirectToAction("ProjeGorDanisman", new { id = id });
            }

        }
        public void Vb()
        {
            ViewBag.tempFiyatList = tfm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelList = pm.TGetList().Where(x => x.Silindi == false);
            ViewBag.personelTipiList = ptm.TGetList().Where(x => x.Silindi == false);
            ViewBag.paraBirimiList = pbm.TGetList().Where(x => x.Silindi == false);
            ViewBag.tempDanismanList = tdm.TGetList();
            ViewBag.cariList = cm.TGetList().Where(x => x.Silindi == false);

        }
    }
}

