using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
	public class EfProjeIcerikDal:GenericRepository<ProjeIcerik>,IProjeIcerikDal
	{

	}
}

