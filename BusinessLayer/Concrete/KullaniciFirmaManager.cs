using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class KullaniciFirmaManager : IKullaniciFirmaService
    {
        IKullaniciFirmaDal _kullaniciFirmaDal;

        public KullaniciFirmaManager(IKullaniciFirmaDal kullaniciFirmaDal)
        {
            _kullaniciFirmaDal = kullaniciFirmaDal;
        }

        public void TAdd(KullaniciFirma t)
        {
            _kullaniciFirmaDal.Insert(t);
        }

        public void TDelete(KullaniciFirma t)
        {
            _kullaniciFirmaDal.Delete(t);
        }

        public KullaniciFirma TGetByID(int id)
        {
            
            return _kullaniciFirmaDal.Get(x => x.KullaniciId == id);
        }

        public List<KullaniciFirma> TGetList()
        {
            return _kullaniciFirmaDal.GetList();
        }

        public void TUpdate(KullaniciFirma t)
        {
            _kullaniciFirmaDal.Update(t);
        }
    }
}

