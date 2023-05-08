using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class IlceManager:IIlceService
	{
        IIlceDal _ilceDal;
		public IlceManager(IIlceDal ilceDal)
		{
            _ilceDal = ilceDal;
		}

        public void TAdd(Ilce t)
        {
            _ilceDal.Insert(t);
        }

        public void TDelete(Ilce t)
        {
            _ilceDal.Delete(t);
        }

        public Ilce TGetByID(int id)
        {
            return _ilceDal.Get(x => x.IlceId == id);
        }

        public List<Ilce> TGetList()
        {
            return _ilceDal.GetList();
        }

        public void TUpdate(Ilce t)
        {
            _ilceDal.Update(t);
        }
    }
}

