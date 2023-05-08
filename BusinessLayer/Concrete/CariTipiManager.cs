using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CariTipiManager : ICariTipiService
    {
        ICariTipiDal _cariTipiDal;
        public CariTipiManager(ICariTipiDal cariTipiDal)
        {
            _cariTipiDal = cariTipiDal;
        }

        public void TAdd(CariTipi t)
        {
            _cariTipiDal.Insert(t);
        }

        public void TDelete(CariTipi t)
        {
            _cariTipiDal.Delete(t);
        }

        public CariTipi TGetByID(int id)
        {
            return _cariTipiDal.Get(x => x.CariTipiId == id);
        }

        public List<CariTipi> TGetList()
        {
            return _cariTipiDal.GetList();
        }

        public void TUpdate(CariTipi t)
        {
            _cariTipiDal.Update(t);
        }
    }
}

