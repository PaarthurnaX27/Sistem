using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        IDepartmanDal _departmanDal;

        public DepartmanManager(IDepartmanDal departmanDal)
        {
            _departmanDal = departmanDal;
        }
        public void TAdd(Departman t)
        {
            _departmanDal.Insert(t);
        }

        public void TDelete(Departman t)
        {
            _departmanDal.Delete(t);
        }

        public Departman TGetByID(int id)
        {
            return _departmanDal.Get(x => x.DepartmanId == id);
        }

        public List<Departman> TGetList()
        {
            return _departmanDal.GetList();
        }

        public void TUpdate(Departman t)
        {
            _departmanDal.Update(t);
        }
    }
}

