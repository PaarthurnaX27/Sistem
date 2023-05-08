using System;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
	public interface IRepository<T>
	{
		List<T> GetList();

		void Insert(T p);

		T Get(Expression<Func<T,bool>> filter);

		void Update(T p);

		void Delete(T p);
		List<T> List(Expression<Func<T, bool>> filter);
	}
}

