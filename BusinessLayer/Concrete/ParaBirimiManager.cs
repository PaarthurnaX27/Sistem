using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ParaBirimiManager : IParaBirimiService
    {
        IParaBirimiDal _paraBirimiDal;

        public ParaBirimiManager(IParaBirimiDal paraBirimiDal)
        {
            _paraBirimiDal = paraBirimiDal;
        }
        public void TAdd(ParaBirimi t)
        {
            _paraBirimiDal.Insert(t);
        }

        public void TDelete(ParaBirimi t)
        {
            _paraBirimiDal.Delete(t);

        }

        public ParaBirimi TGetByID(int id)
        {
            return _paraBirimiDal.Get(x => x.ParaBirimiId == id);
        }

        public List<ParaBirimi> TGetList()
        {
            return _paraBirimiDal.GetList();
        }

        public void TUpdate(ParaBirimi t)
        {
            _paraBirimiDal.Update(t);
        }
    }
}

