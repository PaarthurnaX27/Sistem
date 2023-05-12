using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class PozisyonManager : IPozisyonService
    {
        IPozisyonDal _pozisyonDal;
        public PozisyonManager(IPozisyonDal pozisyonDal)
        {
            _pozisyonDal = pozisyonDal;
        }

        public void TAdd(Pozisyon t)
        {
            _pozisyonDal.Insert(t);
        }

        public void TDelete(Pozisyon t)
        {
            _pozisyonDal.Delete(t);
        }

        public Pozisyon TGetByID(int id)
        {
            return _pozisyonDal.Get(x => x.PozisyonId == id);
        }

        public List<Pozisyon> TGetList()
        {
            return _pozisyonDal.GetList();
        }

        public void TUpdate(Pozisyon t)
        {
            _pozisyonDal.Update(t);
        }
    }
}

