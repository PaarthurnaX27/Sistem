using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TempCariManager : ITempCariService
    {
         ITempCariDal _tempCariDal;
        public TempCariManager(ITempCariDal tempCariDal)
        {
            _tempCariDal = tempCariDal;
        }
        public void TAdd(TempCari t)
        {
           _tempCariDal.Insert(t);
        }

        public void TDelete(TempCari t)
        {
            _tempCariDal.Delete(t);
        }

        public TempCari TGetByID(int id)
        {
           return _tempCariDal.Get(x=>x.CariId==id);
        }

        public List<TempCari> TGetList()
        {
           return _tempCariDal.GetList();
        }

        public void TUpdate(TempCari t)
        {
            _tempCariDal.Update(t);
        }
    }
}