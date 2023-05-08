using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class UlkeManager:IUlkeService
	{
        IUlkeDal _ulkeDal;
		public UlkeManager(IUlkeDal ulkeDal)
		{
            _ulkeDal = ulkeDal;
		}

        public void TAdd(Ulke t)
        {
            _ulkeDal.Insert(t);
        }

        public void TDelete(Ulke t)
        {
            _ulkeDal.Delete(t);
        }

        public Ulke TGetByID(int id)
        {
            return _ulkeDal.Get(x => x.UlkeId == id);
        }

        public List<Ulke> TGetList()
        {
           return _ulkeDal.GetList();
        }

        public void TUpdate(Ulke t)
        {
            _ulkeDal.Update(t);
        }
    }
}

