using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private customersContext _context;
        public CustomerRepository(customersContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUser(Users user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public Users GetUserbyID(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Userid == id);
            return user;
        }

        public IEnumerable<Users> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public async Task<Users> NewUser(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<Users> UpdateUser(Users user)
        {
            var id = user.Userid;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            var u = this.GetUserbyID(id);
            return u;

        }
    }
}
