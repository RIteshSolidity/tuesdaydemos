using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.repositories;
using CustomerService.Models;
using CustomerService.Commands;
using CustomerService.entities;
using CustomerService.Events;
using CustomerService.EventStore;

namespace CustomerService.CommandHandlers
{
    public interface ICustomerCommandHandler
    {
        void HandleCustomerCreated(ICustomerCommand command);

    }

    public class CustomerCommandHandler : ICustomerCommandHandler {
        private ICustomerRepository _repo;
        public CustomerCommandHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public void HandleCustomerCreated(ICustomerCommand command)
        {
            CustomerCreatedCommand c = command as CustomerCreatedCommand;

            UserIdentifier u = new UserIdentifier(c.Userid);
            FirstNameValueObject f = new FirstNameValueObject(c.Firstname);
            CustomerEntity cust = new CustomerEntity(u, f, c.Firstname, c.Age, c.City, 10);

            Users us = cust.GetCustomerModelfromEntity();
            //if (_repo.GetUserbyID(c.Userid) != null) {
                _repo.NewUser(us);
            //}

            CustomerCreatedEvent e = new CustomerCreatedEvent(c.Userid, c.Firstname, c.Lastname, c.City);
            ServiceBusQueueStore.SendEvent(e);

            //save the customer
            // raise the event
        }
    }
}
