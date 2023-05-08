using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServisSekliManager : IServisSekliService
    {
        IServisSekliDal _servisSekliDal;
        public ServisSekliManager(IServisSekliDal servisSekliDal)
        {
            _servisSekliDal=servisSekliDal;
        }
        public void TAdd(ServisSekli t)
        {
            _servisSekliDal.Insert(t);
        }

        public void TDelete(ServisSekli t)
        {
           _servisSekliDal.Delete(t);
        }

        public ServisSekli TGetByID(int id)
        {
            return _servisSekliDal.Get(x=>x.ServisSekliId==id);
        }

        public List<ServisSekli> TGetList()
        {
            return _servisSekliDal.GetList();
        }

        public void TUpdate(ServisSekli t)
        {
            _servisSekliDal.Update(t);
        }
    }
}