using RealEntity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.ConfigurationRepository
{
    public interface IRoleService
    {
        List<UserRole> GetRoles();
    }
}
