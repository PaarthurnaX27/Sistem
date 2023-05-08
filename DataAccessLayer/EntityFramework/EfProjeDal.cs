using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
	public class EfProjeDal:GenericRepository<Proje>,IProjeDal
	{

	}
}

