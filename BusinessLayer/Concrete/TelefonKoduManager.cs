using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class TelefonKoduManager:ITelefonKoduService
	{
        ITelefonKoduDal _telefonKoduDal;
		public TelefonKoduManager(ITelefonKoduDal telefonKoduDal)
		{
            _telefonKoduDal = telefonKoduDal;
		}

        public void TAdd(TelefonKodu t)
        {
            _telefonKoduDal.Insert(t);
        }

        public void TDelete(TelefonKodu t)
        {
            _telefonKoduDal.Delete(t);
        }

        public TelefonKodu TGetByID(int id)
        {
            return _telefonKoduDal.Get(x => x.id == id);
        }

        public List<TelefonKodu> TGetList()
        {
            return _telefonKoduDal.GetList();
        }

        public void TUpdate(TelefonKodu t)
        {
            _telefonKoduDal.Update(t);
        }
    }
}

