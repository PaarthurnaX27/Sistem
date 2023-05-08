using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CariDurumManager : ICariDurumService
    {
        ICariDurumDal _cariDurumDal;

        public CariDurumManager(ICariDurumDal cariDurumDal)
        {
            _cariDurumDal = cariDurumDal;
        }

        public void TAdd(CariDurum t)
        {
            _cariDurumDal.Insert(t);
        }

        public void TDelete(CariDurum t)
        {
            _cariDurumDal.Delete(t);
        }

        public CariDurum TGetByID(int id)
        {
            return _cariDurumDal.Get(x => x.CariDurumId == id);
        }

        public List<CariDurum> TGetList()
        {
            return _cariDurumDal.GetList();
        }

        public void TUpdate(CariDurum t)
        {
            _cariDurumDal.Update(t);
        }
    }
}

