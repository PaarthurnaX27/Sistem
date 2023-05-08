using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class UnvanManager:IUnvanService
	{
        IUnvanDal _unvanDal;
		public UnvanManager(IUnvanDal unvanDal)
		{
            _unvanDal = unvanDal;
		}

        public void TAdd(Unvan t)
        {
            _unvanDal.Insert(t);
        }

        public void TDelete(Unvan t)
        {
            _unvanDal.Delete(t);
        }

        public Unvan TGetByID(int id)
        {
           return _unvanDal.Get(x => x.UnvanId == id);
        }

        public List<Unvan> TGetList()
        {
            return _unvanDal.GetList();
        }

        public void TUpdate(Unvan t)
        {
            _unvanDal.Update(t);
        }
    }
}

