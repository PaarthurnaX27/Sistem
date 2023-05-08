using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class IlgiliKisilerManager:IIlgiliKisilerService
	{
        IIlgiliKisilerDal _ilgiliKisilerDal;

        public IlgiliKisilerManager(IIlgiliKisilerDal ilgiliKisilerDal)
        {
            _ilgiliKisilerDal = ilgiliKisilerDal;
        }

        //public void IlgiliKisilerAddBl(IlgiliKisiler ilgiliKisiler)
        //{
        //    _ilgiliKisilerDal.Insert(ilgiliKisiler);
        //}

        //public List<IlgiliKisiler> GetList()
        //{
        //    return _ilgiliKisilerDal.List();
        //}

        public void TAdd(IlgiliKisiler t)
        {
            _ilgiliKisilerDal.Insert(t);
        }

        public void TDelete(IlgiliKisiler t)
        {
            _ilgiliKisilerDal.Delete(t);
        }

        public void TUpdate(IlgiliKisiler t)
        {
            _ilgiliKisilerDal.Update(t);
        }

        public List<IlgiliKisiler> TGetList()
        {
            return _ilgiliKisilerDal.GetList();
        }

        public IlgiliKisiler TGetByID(int id)
        {
            return _ilgiliKisilerDal.Get(x => x.IlgiliKisiId == id);
        }
    }
}

