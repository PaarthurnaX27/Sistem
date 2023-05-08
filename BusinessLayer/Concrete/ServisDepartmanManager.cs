using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServisDepartmanManager : IServisDepartmanService
    {
        IServisDepartmanDal _servisDepartmanDal;
        
        public ServisDepartmanManager(IServisDepartmanDal servisDepartmanDal)
        {
            _servisDepartmanDal=servisDepartmanDal;
        }
        public void TAdd(ServisDepartman t)
        {
            _servisDepartmanDal.Insert(t);
        }

        public void TDelete(ServisDepartman t)
        {
            _servisDepartmanDal.Delete(t);
        }

        public ServisDepartman TGetByID(int id)
        {
            return _servisDepartmanDal.Get(x=>x.ServisDepartmanId==id);
        }

        public List<ServisDepartman> TGetList()
        {
           return _servisDepartmanDal.GetList();
        }

        public void TUpdate(ServisDepartman t)
        {
            _servisDepartmanDal.Update(t);
        }
    }
}