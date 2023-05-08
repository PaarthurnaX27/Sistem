using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CalismaDurumuManager : ICalismaDurumuService
    {
         ICalismaDurumuDal _calismaDurumuDal;

        public CalismaDurumuManager(ICalismaDurumuDal calismaDurumuDal)
        {
            _calismaDurumuDal = calismaDurumuDal;
        }

        public void TAdd(CalismaDurumu t)
        {
            _calismaDurumuDal.Insert(t);
        }

        public void TDelete(CalismaDurumu t)
        {
            _calismaDurumuDal.Delete(t);
        }

        public CalismaDurumu TGetByID(int id)
        {
            return _calismaDurumuDal.Get(x=>x.CalismaDurumuId==id);
        }

        public List<CalismaDurumu> TGetList()
        {
            return _calismaDurumuDal.GetList();
        }

        public void TUpdate(CalismaDurumu t)
        {
            _calismaDurumuDal.Update(t);
        }
    }
}