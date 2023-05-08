using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TempCariPersonelManager : ITempCariPersonelService
    {
        ITempCariPersonelDal _tempCariPersonelDal;
        public TempCariPersonelManager(ITempCariPersonelDal tempCariPersonelDal)
        {
            _tempCariPersonelDal = tempCariPersonelDal;
        }
        public void TAdd(TempCariPersonel t)
        {
            _tempCariPersonelDal.Insert(t);
        }

        public void TDelete(TempCariPersonel t)
        {
            _tempCariPersonelDal.Delete(t);
        }

        public TempCariPersonel TGetByID(int id)
        {
            return _tempCariPersonelDal.Get(x => x.CariPersonelId == id);
        }

        public List<TempCariPersonel> TGetList()
        {
            return _tempCariPersonelDal.GetList();
        }

        public void TUpdate(TempCariPersonel t)
        {
            _tempCariPersonelDal.Update(t);
        }
    }
}