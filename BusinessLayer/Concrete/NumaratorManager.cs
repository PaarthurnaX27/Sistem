using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class NumaratorManager:INumaratorService
	{
        INumaratorDal _numaratorDal;
		public NumaratorManager(INumaratorDal numaratorDal)
		{
            _numaratorDal = numaratorDal;
		}

        public void TAdd(Numarator t)
        {
            _numaratorDal.Insert(t);
        }

        public void TDelete(Numarator t)
        {
            _numaratorDal.Delete(t);
        }

        public Numarator TGetByID(int id)
        {
            return _numaratorDal.Get(x => x.NumaratorId == id);
        }

        public List<Numarator> TGetList()
        {
            return _numaratorDal.GetList();
        }

        public void TUpdate(Numarator t)
        {
            _numaratorDal.Update(t);
        }
    }
}

