using Microsoft.EntityFrameworkCore;
using MvcMovie.DataAccessLayer.Data;
using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
	{
		private ApplicationDbContext _context;
		private DbSet<T> _dbSet;

		public Repository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}
		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void DeleteRange(T entity)
		{
			_dbSet.RemoveRange(entity);
		}

		public IEnumerable<T>  GetAll()
		{
			return _dbSet.ToList();
		}

		public T GetT(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate).FirstOrDefault();
		}
	}

}
