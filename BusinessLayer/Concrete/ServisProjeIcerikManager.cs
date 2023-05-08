using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class ServisProjeIcerikManager:IServisProjeIcerikService
	{
        IServisProjeIcerikDal _servisProjeIcerikDal;
		public ServisProjeIcerikManager(IServisProjeIcerikDal servisProjeIcerikDal)
		{
            _servisProjeIcerikDal = servisProjeIcerikDal;
		}

        public void TAdd(ServisProjeIcerik t)
        {
            _servisProjeIcerikDal.Insert(t);
        }

        public void TDelete(ServisProjeIcerik t)
        {
            _servisProjeIcerikDal.Delete(t);
        }

        public ServisProjeIcerik TGetByID(int id)
        {
            return _servisProjeIcerikDal.Get(x => x.ServisProjeIcerikId == id);
        }

        public List<ServisProjeIcerik> TGetList()
        {
            return _servisProjeIcerikDal.GetList();
        }

        public void TUpdate(ServisProjeIcerik t)
        {
            _servisProjeIcerikDal.Update(t);
        }
    }
}

