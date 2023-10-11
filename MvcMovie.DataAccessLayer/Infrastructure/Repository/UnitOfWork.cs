using MvcMovie.DataAccessLayer.Data;
using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;
		public IUserRepository User { get; private set; }

        public IDepartmentRepository Department { get; private set; }

        public UnitOfWork(ApplicationDbContext context) //constructor
		{
			_context = context; //initializing the context
			User = new UserRepository(context);
			Department = new DepartmentRepository(context);	//NEW REPOSITROY OF CONTEXT
		}
		//unitofwork can call this privately variable User and this variable user has user repository class.
		//and this user repository class can also call general repository.

		void IUnitOfWork.Save()
		{
			_context.SaveChanges();
		}
	}
}
