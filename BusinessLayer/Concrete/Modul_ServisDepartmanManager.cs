using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Modul_ServisDepartmanManager : IModul_ServisDepartmanService
    {
        IModul_ServisDepartmanDal _modulServisDepartmanDal;

        public Modul_ServisDepartmanManager(IModul_ServisDepartmanDal modul_ServisDepartmanDal)
        {
            _modulServisDepartmanDal=modul_ServisDepartmanDal;
        }
        public void TAdd(Modul_ServisDepartman t)
        {
            _modulServisDepartmanDal.Insert(t);
        }

        public void TDelete(Modul_ServisDepartman t)
        {
            _modulServisDepartmanDal.Delete(t);
        }

        public Modul_ServisDepartman TGetByID(int id)
        {
          return _modulServisDepartmanDal.Get(x=>x.Modul_ServisDepartmanId==id);
        }

        public List<Modul_ServisDepartman> TGetList()
        {
            return _modulServisDepartmanDal.GetList();
        }

        public void TUpdate(Modul_ServisDepartman t)
        {
            _modulServisDepartmanDal.Update(t);
        }
    }
}