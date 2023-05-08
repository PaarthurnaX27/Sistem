using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TempServisBilgiManager : ITempServisBilgiService
    {
        ITempServisBilgiDal _tempServisBilgiDal;

        public TempServisBilgiManager(ITempServisBilgiDal tempServisBilgiDal)
        {
            _tempServisBilgiDal = tempServisBilgiDal;
        }
        public void TAdd(TempServisBilgi t)
        {
            _tempServisBilgiDal.Insert(t);
        }

        public void TDelete(TempServisBilgi t)
        {
            _tempServisBilgiDal.Delete(t);
        }

        public TempServisBilgi TGetByID(int id)
        {
            return _tempServisBilgiDal.Get(x => x.TempServisId == id);
        }

        public List<TempServisBilgi> TGetList()
        {
            return _tempServisBilgiDal.GetList();
        }

        public void TUpdate(TempServisBilgi t)
        {
            _tempServisBilgiDal.Update(t);
        }
    }
}