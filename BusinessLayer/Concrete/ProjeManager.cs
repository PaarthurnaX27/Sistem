using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ProjeManager : IProjeService
    {
        IProjeDal _projeDal;
        public ProjeManager(IProjeDal projeDal)
        {
            _projeDal = projeDal;
        }
        public void TAdd(Proje t)
        {
            _projeDal.Insert(t);
        }

        public void TDelete(Proje t)
        {
            _projeDal.Delete(t);
        }

        public Proje TGetByID(int id)
        {
            return _projeDal.Get(x => x.ProjeId == id);
        }

        public List<Proje> TGetList()
        {
            return _projeDal.GetList();
        }

        public void TUpdate(Proje t)
        {
            _projeDal.Update(t);
        }
    }
}

