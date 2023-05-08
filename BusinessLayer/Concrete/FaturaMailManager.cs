using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class FaturaMailManager:IFaturaMailService
	{
        IFaturaMailDal _faturaMailDal;
		public FaturaMailManager(IFaturaMailDal faturaMailDal)
		{
            _faturaMailDal = faturaMailDal;
		}

        public void TAdd(FaturaMail t)
        {
            _faturaMailDal.Insert(t);
        }

        public void TDelete(FaturaMail t)
        {
            _faturaMailDal.Delete(t);
        }

        public FaturaMail TGetByID(int id)
        {
            return _faturaMailDal.Get(x => x.FaturaMailId == id);
        }

        public List<FaturaMail> TGetList()
        {
            return _faturaMailDal.GetList();
        }

        public void TUpdate(FaturaMail t)
        {
            _faturaMailDal.Update(t);
        }
    }
}

