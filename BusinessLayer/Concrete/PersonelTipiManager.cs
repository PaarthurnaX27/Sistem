using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PersonelTipiManager : IPersonelTipiService
    {
        IPersonelTipiDal _personelTipiDal;
        public PersonelTipiManager(IPersonelTipiDal personelTipiDal)
        {
            _personelTipiDal = personelTipiDal;
        }

        public void TAdd(PersonelTipi t)
        {
            _personelTipiDal.Insert(t);
        }

        public void TDelete(PersonelTipi t)
        {
            _personelTipiDal.Delete(t);
        }

        public PersonelTipi TGetByID(int id)
        {
            return _personelTipiDal.Get(x => x.PersonelTipiId == id);
        }

        public List<PersonelTipi> TGetList()
        {
            return _personelTipiDal.GetList();
        }

        public void TUpdate(PersonelTipi t)
        {
            _personelTipiDal.Update(t);
        }
    }
}

