using MvcMovie.DataAccessLayer.Data;
using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
using MvcMovie.Models;
using MvcMovie.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository 
	{
		//IUserRepositopry brings out the update interface.
		//Repository<User> brings out the general common functions.
		//Repository<User> brings out the general common functions.

		private ApplicationDbContext _context;
		
		public DepartmentRepository(ApplicationDbContext context):base(context)
		{
			_context = context;	//initializing the context
		}

		public void Update(Department department)
		{
			//_context.Departments.Update(department);
			var departmentdb = _context.Departments.FirstOrDefault(x => x.Id == department.Id);
			if (departmentdb != null)
			{
                departmentdb.D_name = department.D_name;
				department.D_description = department.D_description;
            }

		}
	}  
}
