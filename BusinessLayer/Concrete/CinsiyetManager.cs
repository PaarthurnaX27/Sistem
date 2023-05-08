using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class CinsiyetManager:ICinsiyetService
	{
        ICinsiyetDal _cinsiyetDal;

		public CinsiyetManager(ICinsiyetDal cinsiyetDal)
		{
            _cinsiyetDal = cinsiyetDal;
		}

        public void TAdd(Cinsiyet t)
        {
            _cinsiyetDal.Insert(t);
        }

        public void TDelete(Cinsiyet t)
        {
            _cinsiyetDal.Delete(t);
        }

        public Cinsiyet TGetByID(int id)
        {
            return _cinsiyetDal.Get(x => x.CinsiyetId == id);
        }

        public List<Cinsiyet> TGetList()
        {
            return _cinsiyetDal.GetList();
        }

        public void TUpdate(Cinsiyet t)
        {
            _cinsiyetDal.Update(t);
        }
    }
}

