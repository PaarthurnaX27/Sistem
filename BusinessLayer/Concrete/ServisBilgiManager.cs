using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServisBilgiManager : IServisBilgiService
    {
        IServisBilgiDal _servisBilgiDal;

        public ServisBilgiManager(IServisBilgiDal servisBilgiDal)
        {
            _servisBilgiDal = servisBilgiDal;
        }
        public void TAdd(ServisBilgi t)
        {
            _servisBilgiDal.Insert(t);
        }

        public void TDelete(ServisBilgi t)
        {
            _servisBilgiDal.Delete(t);
        }

        public ServisBilgi TGetByID(int id)
        {
            return _servisBilgiDal.Get(x => x.ServisId == id);
        }

        public List<ServisBilgi> TGetList()
        {
            return _servisBilgiDal.GetList();
        }

        public void TUpdate(ServisBilgi t)
        {
            _servisBilgiDal.Update(t);
        }
    }
}