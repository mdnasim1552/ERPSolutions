using RealEntity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.LoginRepository
{
    public interface ILoginRepository
    {
        Task<List<Company>> GetCompanyList();
        Task<Company> GetCompany(string comcod);
        Task<LoginUsers> GetLoginUsers(string comcod, string username, string password);
    }
}
