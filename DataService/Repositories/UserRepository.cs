using DataService.Infrastructure;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository()
        {
        }
    }
}
