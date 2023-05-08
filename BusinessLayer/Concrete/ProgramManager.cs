using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class ProgramManager:IProgramService
	{
        IProgramDal _programDal;
		public ProgramManager(IProgramDal programDal)
		{
            _programDal = programDal;
		}

        public void TAdd(Programs t)
        {
            _programDal.Insert(t);
        }

        public void TDelete(Programs t)
        {
            _programDal.Delete(t);
        }

        public Programs TGetByID(int id)
        {
            return _programDal.Get(x => x.ProgramId == id);
        }

        public List<Programs> TGetList()
        {
            return _programDal.GetList();
        }

        public void TUpdate(Programs t)
        {
            _programDal.Update(t);
        }
    }
}

