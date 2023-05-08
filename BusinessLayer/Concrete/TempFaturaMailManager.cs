using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class TempFaturaMailManager:ITempFaturaMailService
	{
        ITempFaturaMailDal _tempFaturaMailDal;
		public TempFaturaMailManager(ITempFaturaMailDal faturaMailDal)
		{
            _tempFaturaMailDal = faturaMailDal;
		}

        public void TAdd(TempFaturaMail t)
        {
            _tempFaturaMailDal.Insert(t);
        }

        public void TDelete(TempFaturaMail t)
        {
            _tempFaturaMailDal.Delete(t);
        }

        public TempFaturaMail TGetByID(int id)
        {
            return _tempFaturaMailDal.Get(x => x.TempFaturaMailId ==id);
        }

        public List<TempFaturaMail> TGetList()
        {
            return _tempFaturaMailDal.GetList();
        }

        public void TUpdate(TempFaturaMail t)
        {
            _tempFaturaMailDal.Update(t);
        }
    }
}

