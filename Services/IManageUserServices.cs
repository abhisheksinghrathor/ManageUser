using System.Collections.Generic;
using System.Threading.Tasks;
//using Users.Models;

namespace ManageUser.Services
{
    public interface IManageUserServices
    {
       bool AddUsers(Users user);
       bool DeleteUsers(int id);
       bool UpdateUsers(Users user);
       Task<IEnumerable<Users>> GetAllUsers();
    }
}