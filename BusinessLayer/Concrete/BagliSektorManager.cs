using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class BagliSektorManager:IBagliSektorService
	{
        IBagliSektorDal _bagliSektorDal;

        public BagliSektorManager(IBagliSektorDal bagliSektorDal)
		{
            _bagliSektorDal = bagliSektorDal;
		}

        public void TAdd(BagliSektor t)
        {
            _bagliSektorDal.Insert(t);
        }

        public void TDelete(BagliSektor t)
        {
            _bagliSektorDal.Delete(t);
        }

        public BagliSektor TGetByID(int id)
        {
            return _bagliSektorDal.Get(x => x.BagliSektorId == id);
        }

        public List<BagliSektor> TGetList()
        {
            return _bagliSektorDal.GetList();
        }

        public void TUpdate(BagliSektor t)
        {
            _bagliSektorDal.Update(t);
        }
    }
}

