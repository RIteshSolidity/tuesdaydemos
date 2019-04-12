using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public interface ISqlRepository
    {
        Task<ICollection<Customer>> getAllCustomers();
        Customer GetCustomerbyID(int _customerId);

        Task<Customer> InsertCustomer(Customer _table1);

        Task<Customer> UpdateCustomer(Customer _table1);

        Task<bool> DeleteCustomer(int _customerId);
    }
}
