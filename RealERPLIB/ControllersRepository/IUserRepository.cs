using RealEntity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.ControllersRepository
{
    public interface IUserRepository
    {
        Task<List<Userinf>> GetUserList();
        Task<bool> InsertUserData(Userinf user);
        Task<bool> UpdateUserData(List<Userinf> updatedData);
        Task<bool> DeleteUserData(string comcod, string usrid);
    }
}
