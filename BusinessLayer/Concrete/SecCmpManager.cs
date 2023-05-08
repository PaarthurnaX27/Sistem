using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SecCmpManager : ISecCmpService
    {
        ISecCmpDal _secCmpDal;

        public SecCmpManager(ISecCmpDal secCmpDal)
        {
            _secCmpDal = secCmpDal;
        }

        public void TAdd(SecCmp t)
        {
            _secCmpDal.Insert(t);
        }

        public void TDelete(SecCmp t)
        {
            _secCmpDal.Delete(t);
        }

        public SecCmp TGetByID(int id)
        {
            return _secCmpDal.Get(x => x.CompanyId == id);
        }

        public List<SecCmp> TGetList()
        {
            return _secCmpDal.GetList();
        }

        public void TUpdate(SecCmp t)
        {
            _secCmpDal.Update(t);
        }
    }
}

