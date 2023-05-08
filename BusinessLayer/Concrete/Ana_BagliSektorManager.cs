using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class Ana_BagliSektorManager:IAna_BagliSektorService
	{

        IAna_BagliSektorDal _ana_bagliSektorDal;
		public Ana_BagliSektorManager(IAna_BagliSektorDal ana_BagliSektorDal)
		{
            _ana_bagliSektorDal = ana_BagliSektorDal;
		}

        public void TAdd(AnaSektor_BagliSektor t)
        {
            _ana_bagliSektorDal.Insert(t);
        }

        public void TDelete(AnaSektor_BagliSektor t)
        {
            _ana_bagliSektorDal.Delete(t);
        }

        public AnaSektor_BagliSektor TGetByID(int id)
        {
            return _ana_bagliSektorDal.Get(x => x.Id == id);
        }

        public List<AnaSektor_BagliSektor> TGetList()
        {
            return _ana_bagliSektorDal.GetList();
        }

        public void TUpdate(AnaSektor_BagliSektor t)
        {
            _ana_bagliSektorDal.Update(t);
        }
    }
}

