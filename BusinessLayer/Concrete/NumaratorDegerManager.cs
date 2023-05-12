using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class NumaratorDegerManager:INumaratorDegerService
	{
        INumaratorDegerDal _numaratorDegerDal;
		public NumaratorDegerManager(INumaratorDegerDal numaratorDegerDal)
		{
            _numaratorDegerDal = numaratorDegerDal;
		}

        public void TAdd(NumaratorDeger t)
        {
            _numaratorDegerDal.Insert(t);
        }

        public void TDelete(NumaratorDeger t)
        {
            _numaratorDegerDal.Delete(t);
        }

        public NumaratorDeger TGetByID(int id)
        {
            return _numaratorDegerDal.Get(x => x.NumaratorDegerId == id);
        }

        public List<NumaratorDeger> TGetList()
        {
            return _numaratorDegerDal.GetList();
        }

        public void TUpdate(NumaratorDeger t)
        {
            _numaratorDegerDal.Update(t);
        }
    }
}

