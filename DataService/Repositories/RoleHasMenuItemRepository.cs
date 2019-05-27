using DataService.Infrastructure;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public interface IRoleHasMenuItemRepository : IRepository<RoleHasMenuItem>
    {

    }
    public class RoleHasMenuItemRepository : Repository<RoleHasMenuItem>, IRoleHasMenuItemRepository
    {
        public RoleHasMenuItemRepository()
        {
        }
    }
}
