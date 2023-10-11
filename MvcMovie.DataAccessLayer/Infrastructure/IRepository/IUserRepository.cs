using MvcMovie.Models;
using MvcMovie.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUserRepository:IRepository<User>
	{
        void Update(User user);
	}
}
