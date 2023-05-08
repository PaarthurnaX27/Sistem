using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SonDurumManager : ISonDurumService
    {
        ISonDurumDal _sonDurumDal;
        public SonDurumManager(ISonDurumDal sonDurumDal)
        {
            _sonDurumDal=sonDurumDal;
        }
        public void TAdd(SonDurum t)
        {
            _sonDurumDal.Insert(t);
        }

        public void TDelete(SonDurum t)
        {
            _sonDurumDal.Delete(t);
        }

        public SonDurum TGetByID(int id)
        {
            return _sonDurumDal.Get(x=>x.SonDurumId==id);
        }

        public List<SonDurum> TGetList()
        {
            return _sonDurumDal.GetList();
        }

        public void TUpdate(SonDurum t)
        {
           _sonDurumDal.Update(t);
        }
    }
}