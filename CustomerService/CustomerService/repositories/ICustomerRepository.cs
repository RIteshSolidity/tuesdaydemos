using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Users> GetUsers();
        Users GetUserbyID(int id);
        Task<Users> NewUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(Users user);
    }
}
