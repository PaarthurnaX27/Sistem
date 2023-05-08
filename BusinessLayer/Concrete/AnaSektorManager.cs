using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class AnaSektorManager:IAnaSektorService
	{
        IAnaSektorDal _anaSektorDal;
		public AnaSektorManager(IAnaSektorDal anaSektorDal)
		{
            _anaSektorDal = anaSektorDal;
		}

        public void TAdd(AnaSektor t)
        {
            _anaSektorDal.Insert(t);
        }

        public void TDelete(AnaSektor t)
        {
            _anaSektorDal.Delete(t);
        }

        public AnaSektor TGetByID(int id)
        {
            return _anaSektorDal.Get(x => x.AnaSektorId == id);
        }

        public List<AnaSektor> TGetList()
        {
            return _anaSektorDal.GetList();
        }

        public void TUpdate(AnaSektor t)
        {
            _anaSektorDal.Update(t);
        }
    }
}

