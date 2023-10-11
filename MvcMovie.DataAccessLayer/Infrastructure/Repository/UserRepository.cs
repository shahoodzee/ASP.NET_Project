using MvcMovie.DataAccessLayer.Data;
using MvcMovie.DataAccessLayer.Infrastructure.IRepository;
using MvcMovie.Models;
using MvcMovie.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.DataAccessLayer.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository 
	{
		//IUserRepositopry brings out the update interface.
		//Repository<User> brings out the general common functions.
		//Repository<User> brings out the general common functions.

		private ApplicationDbContext _context;
		
		public UserRepository(ApplicationDbContext context):base(context)
		{
			_context = context;	//initializing the context
		}

		public void Update(User user)
		{
			//_context.User.Update(user);

            var userdb = _context.User.FirstOrDefault(x => x.Id == user.Id);
			if (userdb != null)
			{
				userdb.FirstName = user.FirstName;
				userdb.LastName = user.LastName;
				userdb.City	= user.City;
			}
        }
    }  
}
