using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
	public class EfTempCariProgramDal:GenericRepository<TempCariProgram>,ITempCariProgramDal
	{
	
	}
}

