using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CariPersonelManager : ICariPersonelService
    {
          ICariPersonelDal _cariPersonelDal;
        public CariPersonelManager(ICariPersonelDal cariPersonelDal)
        {
            _cariPersonelDal = cariPersonelDal;
        }
        public void TAdd(CariPersonel t)
        {
            _cariPersonelDal.Insert(t);
        }

        public void TDelete(CariPersonel t)
        {
            _cariPersonelDal.Delete(t);
        }

        public CariPersonel TGetByID(int id)
        {
          return _cariPersonelDal.Get(x=>x.CariPersonelId==id);
        }

        public List<CariPersonel> TGetList()
        {
           return _cariPersonelDal.GetList();
        }

        public void TUpdate(CariPersonel t)
        {
            _cariPersonelDal.Update(t);
        }
    }
}