using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ModulManager : IModulService
    {
         IModulDal _modulDal;
		public ModulManager(IModulDal modulDal)
		{
            _modulDal = modulDal;
		}
        public void TAdd(Modul t)
        {
            _modulDal.Insert(t);
        }

        public void TDelete(Modul t)
        {
           _modulDal.Delete(t);
        }

        public Modul TGetByID(int id)
        {
            return _modulDal.Get(x=>x.ModulId==id);
        }

        public List<Modul> TGetList()
        {
            return _modulDal.GetList();
        }

        public void TUpdate(Modul t)
        {
            _modulDal.Update(t);
        }
    }
}