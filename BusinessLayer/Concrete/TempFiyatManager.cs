using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class TempFiyatManager:ITempFiyatService
	{
        ITempFiyatDal _tempFiyatDal;
		public TempFiyatManager(ITempFiyatDal tempFiyatDal)
		{
            _tempFiyatDal = tempFiyatDal;
		}

        public void TAdd(TempFiyatList t)
        {
            _tempFiyatDal.Insert(t);
        }

        public void TDelete(TempFiyatList t)
        {
           _tempFiyatDal.Delete(t);
        }

        public TempFiyatList TGetByID(int id)
        {
            return _tempFiyatDal.Get(x => x.TempFiyatListId == id);
        }

        public List<TempFiyatList> TGetList()
        {
            return _tempFiyatDal.GetList();
        }

        public void TUpdate(TempFiyatList t)
        {
            _tempFiyatDal.Update(t);
        }
    }
}

