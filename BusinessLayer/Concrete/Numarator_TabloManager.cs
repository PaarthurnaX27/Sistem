using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Numarator_TabloManager : INumarator_TabloService
    {
        INumarator_TabloDal _numaratorTabloDal;

        public Numarator_TabloManager(INumarator_TabloDal numarator_TabloDal)
        {
            _numaratorTabloDal = numarator_TabloDal;
        }
        public void TAdd(Numarator_Tablo t)
        {
            _numaratorTabloDal.Insert(t);

        }

        public void TDelete(Numarator_Tablo t)
        {
            _numaratorTabloDal.Delete(t);
        }

        public Numarator_Tablo TGetByID(int id)
        {
            return _numaratorTabloDal.Get(x => x.Numarator_TabloId == id);
            
        }

        public List<Numarator_Tablo> TGetList()
        {
            return _numaratorTabloDal.GetList();
        }

        public void TUpdate(Numarator_Tablo t)
        {
            _numaratorTabloDal.Update(t);
        }
    }
}
