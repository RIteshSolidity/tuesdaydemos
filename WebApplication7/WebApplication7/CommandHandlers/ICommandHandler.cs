using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.commands;
using WebApplication7.Repository;
using WebApplication7.Models;
using WebApplication7.entities;
using WebApplication7.events;
using WebApplication7.EventStore;

namespace WebApplication7.CommandHandlers
{
    public interface ICommandHandler
    {
        void HandleCommand(ICommand command);
    }


    public class CustomerHandler : ICommandHandler
    {
        ISqlRepository repo;

        public CustomerHandler(ISqlRepository _repo)
        {
            repo = _repo;
        }
        public void HandleCommand(ICommand command)
        {
            string abc = command.GetType().Name;
            switch (abc) {
                case "NewCustomerCommand": {
                        var cust = command as NewCustomerCommand;
                        var cust1 = repo.GetCustomerbyID(cust.CustomerId);
                        if (cust1 is null) {
                            CustomerEntity entity = new CustomerEntity();
                            
                            var aa = entity.CreateCustomer(cust);
                            var newCust = new Customer();
                            
                            newCust.CustomerId = cust.CustomerId;
                            newCust.FirstName = cust.FirstName;
                            newCust.LastName = cust.LastName;
                            //repo.InsertCustomer(newCust);
                            ServiceBus.sendMessage(aa).GetAwaiter().GetResult();

                        }
                        break;
                    }
            }
        }
    }
}
