using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class OncelikManager : IOncelikService
    {
        IOncelikDal _oncelikDal;
        public OncelikManager(IOncelikDal oncelikDal)
        {
            _oncelikDal=oncelikDal;
        }
        public void TAdd(Oncelik t)
        {
            _oncelikDal.Insert(t);
        }

        public void TDelete(Oncelik t)
        {
            _oncelikDal.Delete(t);
        }

        public Oncelik TGetByID(int id)
        {
            return _oncelikDal.Get(x=>x.OncelikId==id);
        }

        public List<Oncelik> TGetList()
        {
            return _oncelikDal.GetList();
        }

        public void TUpdate(Oncelik t)
        {
            _oncelikDal.Update(t);
        }
    }
}