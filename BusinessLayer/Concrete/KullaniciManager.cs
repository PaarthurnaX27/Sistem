using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class KullaniciManager:IKullaniciService
	{
        IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void TAdd(Kullanici t)
        {
            _kullaniciDal.Insert(t);
        }

        public void TDelete(Kullanici t)
        {
            _kullaniciDal.Delete(t);
        }

        public Kullanici TGetByID(int id)
        {
            return _kullaniciDal.Get(x => x.KullaniciId == id);
        }

        public List<Kullanici> TGetList()
        {
            return _kullaniciDal.GetList();
        }

        public void TUpdate(Kullanici t)
        {
            _kullaniciDal.Update(t);
        }
    }
}

