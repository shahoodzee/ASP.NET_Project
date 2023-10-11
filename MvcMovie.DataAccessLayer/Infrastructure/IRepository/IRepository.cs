using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.DataAccessLayer.Infrastructure.IRepository
{
	//internal interface IRepository  
	public interface IRepository<T> where T : class	/*interface made public so it can be accessed*/
	{
		IEnumerable<T> GetAll();

		T GetT(Expression<Func<T, bool>> predicate);

		void Add(T entity);
		void Delete(T entity);
		void DeleteRange(T entity);	
		//Deleting multiple data /// deleteing multiple objects of data in list.

	}
}
