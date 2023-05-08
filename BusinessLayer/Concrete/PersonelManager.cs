using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void TAdd(Personel t)
        {
            _personelDal.Insert(t);
        }

        public void TDelete(Personel t)
        {
            _personelDal.Delete(t);
        }

        public Personel TGetByID(int id)
        {
            return _personelDal.Get(x => x.PersonelId == id);
        }

        public List<Personel> TGetList()
        {
            return _personelDal.GetList();
        }

        public void TUpdate(Personel t)
        {
            _personelDal.Update(t);
        }
    }
}

