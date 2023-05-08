using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class TempServisProjeIcerikManager:ITempServisProjeIcerikService
	{
        ITempServisProjeIcerikDal _tempServisProjeIcerikDal;
		public TempServisProjeIcerikManager(ITempServisProjeIcerikDal tempServisProjeIcerikDal)
		{
            _tempServisProjeIcerikDal = tempServisProjeIcerikDal;
		}

        public void TAdd(TempServisProjeIcerik t)
        {
            _tempServisProjeIcerikDal.Insert(t);
        }

        public void TDelete(TempServisProjeIcerik t)
        {
            _tempServisProjeIcerikDal.Delete(t);
        }

        public TempServisProjeIcerik TGetByID(int id)
        {
            return _tempServisProjeIcerikDal.Get(x => x.TempServisProjeIcerikId == id);
        }

        public List<TempServisProjeIcerik> TGetList()
        {
            return _tempServisProjeIcerikDal.GetList();
        }

        public void TUpdate(TempServisProjeIcerik t)
        {
            _tempServisProjeIcerikDal.Update(t);
        }
    }
}

