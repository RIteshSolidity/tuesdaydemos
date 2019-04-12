using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public class SqlRepository : ISqlRepository
    {
        ecommerceContext context;
        public SqlRepository(ecommerceContext _context)
        {
            context = _context;
        }

        public async Task<bool> DeleteCustomer(int _customerId)
        {
            Customer cust = GetCustomerbyID(_customerId);
            context.Customer.Remove(cust);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Customer>> getAllCustomers()
        {
            return context.Customer.ToList<Customer>();
        }

        public Customer GetCustomerbyID(int _customerId)
        {
            return context.Customer.Where<Customer>(w => w.CustomerId == _customerId).FirstOrDefault<Customer>();
        }

        public async Task<Customer> InsertCustomer(Customer _table1)
        {
            await context.Customer.AddAsync(_table1);
            await context.SaveChangesAsync();
            return _table1;
        }

        public async Task<Customer> UpdateCustomer(Customer _table1)
        {
            var custid = _table1.CustomerId;
            context.Entry(_table1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            Customer cust = GetCustomerbyID(custid);
            return cust;
        }
    }
}
