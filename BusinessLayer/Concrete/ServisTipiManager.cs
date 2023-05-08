using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServisTipiManager : IServisTipiService
    {
        IServisTipiDal _servisTipiDal;
        public ServisTipiManager(IServisTipiDal servistipiDal)
        {
            _servisTipiDal=servistipiDal;
        }
        public void TAdd(ServisTipi t)
        {
           _servisTipiDal.Insert(t);
        }

        public void TDelete(ServisTipi t)
        {
           _servisTipiDal.Delete(t);
        }

        public ServisTipi TGetByID(int id)
        {
            return _servisTipiDal.Get(x=>x.ServisTipiId==id);
        }

        public List<ServisTipi> TGetList()
        {
            return _servisTipiDal.GetList();
        }

        public void TUpdate(ServisTipi t)
        {
            _servisTipiDal.Update(t);
        }
    }
}