using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServisKalemManager : IServisKalemService
    {
        IServisKalemDal _servisKalemDal;
        public ServisKalemManager(IServisKalemDal servisKalemDal)
        {
            _servisKalemDal=servisKalemDal;
        }
        public void TAdd(ServisKalem t)
        {
            _servisKalemDal.Insert(t);
        }

        public void TDelete(ServisKalem t)
        {
            _servisKalemDal.Delete(t);
        }

        public ServisKalem TGetByID(int id)
        {
          return _servisKalemDal.Get(x=>x.KalemId==id);
        }

        public List<ServisKalem> TGetList()
        {
            return _servisKalemDal.GetList();
        }

        public void TUpdate(ServisKalem t)
        {
            _servisKalemDal.Update(t);
        }
    }
}