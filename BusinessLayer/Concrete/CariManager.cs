  using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using System.Runtime.Intrinsics.X86;

namespace BusinessLayer.Concrete
{
    public class CariManager : ICariService
    {

        ICariDal _cariDal ;

        public CariManager(ICariDal cariDal)
        {
            _cariDal = cariDal;
        }

        public void TAdd(Cari t)
        {
            _cariDal.Insert(t);
        }

        public void TDelete(Cari t)
        {
            _cariDal.Delete(t);
        }

        public Cari TGetByID(int id)
        {
            return _cariDal.Get(x => x.CariId == id);
        }

        public List<Cari> TGetList()
        {
            return _cariDal.GetList();
        }

        public void TUpdate(Cari t)
        {
            _cariDal.Update(t);
        }

        //public void FirmaAddBl(Firma firma)
        //{
        //    _firmaDal.Insert(firma);
        //}

        //public void FirmaDelete(Firma firma)
        //{
        //    _firmaDal.Delete(firma);    
        //}

        //public void FirmaUpdate(Firma firma)
        //{
        //    _firmaDal.Update(firma);
        //}

        //public Firma GetById(int id)
        //{
        //    return _firmaDal.Get(x => x.FirmaId == id);
        //}

        //public List<Firma> GetList()
        //{
        //    return _firmaDal.List();
        //}








        //GenericRepository<Firma> repository = new GenericRepository<Firma>();
        //public List<Firma> GetAllBl()
        //{
        //	return repository.List();
        //}

        //public void FirmaAddBl(Firma p)
        //{
        //	if (p.VergiNo.ToString().Length==11)
        //	{

        //	}
        //	else
        //	{
        //		repository.Insert(p);	
        //	}
        //}
    }


}

