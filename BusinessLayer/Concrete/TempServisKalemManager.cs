using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TempServisKalemManager : ITempServisKalemService
    {
        ITempServisKalemDal _tempServisKalemDal;

        public TempServisKalemManager(ITempServisKalemDal tempServisKalemDal)
        {
            _tempServisKalemDal=tempServisKalemDal;
        }
        public void TAdd(TempServisKalem t)
        {
            _tempServisKalemDal.Insert(t);
        }

        public void TDelete(TempServisKalem t)
        {
            _tempServisKalemDal.Delete(t);
        }

        public TempServisKalem TGetByID(int id)
        {
            return _tempServisKalemDal.Get(x=>x.TempKalemId==id);
        }

        public List<TempServisKalem> TGetList()
        {
            return _tempServisKalemDal.GetList();
        }

        public void TUpdate(TempServisKalem t)
        {
           _tempServisKalemDal.Update(t);
        }
    }
}