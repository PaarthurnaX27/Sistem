using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class TempCariProgramManager:ITempCariProgramService
	{
		ITempCariProgramDal _tempCariProgramDal;
		public TempCariProgramManager(ITempCariProgramDal tempCariProgramDal)
		{
            _tempCariProgramDal = tempCariProgramDal;
		}

        public void TAdd(TempCariProgram t)
        {
            _tempCariProgramDal.Insert(t);
        }

        public void TDelete(TempCariProgram t)
        {
           _tempCariProgramDal.Delete(t);
        }

        public TempCariProgram TGetByID(int id)
        {
            return _tempCariProgramDal.Get(x => x.TempCariProgramId == id);
        }

        public List<TempCariProgram> TGetList()
        {
            return _tempCariProgramDal.GetList();
        }

        public void TUpdate(TempCariProgram t)
        {
            _tempCariProgramDal.Update(t);
        }
    }
}

