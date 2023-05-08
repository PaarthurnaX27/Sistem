using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class IslemYeriManager : IIslemYeriService
    {
        IIslemYeriDal _islemYeriDal;
        public IslemYeriManager(IIslemYeriDal islemYeriDal)
        {
            _islemYeriDal=islemYeriDal;
        }
        public void TAdd(IslemYeri t)
        {
            _islemYeriDal.Insert(t);
        }

        public void TDelete(IslemYeri t)
        {
            _islemYeriDal.Delete(t);
        }

        public IslemYeri TGetByID(int id)
        {
            return _islemYeriDal.Get(x=>x.IslemYeriId==id);
        }

        public List<IslemYeri> TGetList()
        {
            return _islemYeriDal.GetList();
        }

        public void TUpdate(IslemYeri t)
        {
           _islemYeriDal.Update(t);
        }
    }
}