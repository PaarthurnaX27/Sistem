using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class FaturalamaPeriyoduManager : IFaturalamaPeriyoduService
    {
        IFaturalamaPeriyoduDal _faturalamaPeriyoduDal;
        public FaturalamaPeriyoduManager(IFaturalamaPeriyoduDal faturalamaPeriyoduDal)
        {
            _faturalamaPeriyoduDal = faturalamaPeriyoduDal;
        }
        public void TAdd(FaturalamaPeriyodu t)
        {
            _faturalamaPeriyoduDal.Insert(t);
        }

        public void TDelete(FaturalamaPeriyodu t)
        {
            _faturalamaPeriyoduDal.Delete(t);
        }

        public FaturalamaPeriyodu TGetByID(int id)
        {
            return _faturalamaPeriyoduDal.Get(x => x.FaturalamaPeriyoduId == id);
        }

        public List<FaturalamaPeriyodu> TGetList()
        {
            return _faturalamaPeriyoduDal.GetList();
        }

        public void TUpdate(FaturalamaPeriyodu t)
        {
            _faturalamaPeriyoduDal.Update(t);
        }
    }
}

