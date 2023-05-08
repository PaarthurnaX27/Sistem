using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TempDanismanManager : ITempDanismanService
    {
        ITempDanismanDal _tempDanismanDal;

        public TempDanismanManager(ITempDanismanDal tempDanismanDal)
        {
            _tempDanismanDal = tempDanismanDal;
        }
        public void TAdd(TempDanisman t)
        {
            _tempDanismanDal.Insert(t);
        }

        public void TDelete(TempDanisman t)
        {
            _tempDanismanDal.Delete(t);
        }

        public TempDanisman TGetByID(int id)
        {
            return _tempDanismanDal.Get(x => x.TempDanismanId== id);
        }

        public List<TempDanisman> TGetList()
        {
            return _tempDanismanDal.GetList();
        }

        public void TUpdate(TempDanisman t)
        {
            _tempDanismanDal.Update(t);
        }
    }
}

