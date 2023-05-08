using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SehirManager : ISehirService
    {
        ISehirDal _sehirDal;
        public SehirManager(ISehirDal sehirDal)
        {
            _sehirDal = sehirDal;
        }

        public void TAdd(Sehir t)
        {
            _sehirDal.Insert(t);
        }

        public void TDelete(Sehir t)
        {
            _sehirDal.Delete(t);
        }

        public Sehir TGetByID(int id)
        {
            return _sehirDal.Get(x => x.SehirId == id);
            
        }

        public List<Sehir> TGetList()
        {
            return _sehirDal.GetList();
        }

        public void TUpdate(Sehir t)
        {
            _sehirDal.Update(t);
        }
    }
}

