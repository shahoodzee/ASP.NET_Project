using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.DataAccessLayer.Infrastructure.IRepository
{
	public interface IUnitOfWork
	{
		IUserRepository User { get; }
		IDepartmentRepository Department { get; }
		void Save();
	}
}
