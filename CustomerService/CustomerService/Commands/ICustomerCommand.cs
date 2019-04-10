using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.CommandHandlers;

namespace CustomerService.Commands
{
    public interface ICustomerCommand
    {
        void HandleCommand(ICustomerCommand command);
    }

    public class CustomerCreatedCommand : ICustomerCommand
    {
        private ICustomerCommandHandler _handler;
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public CustomerCreatedCommand( ICustomerCommandHandler handler)
        {
            _handler = handler;
        }
        public CustomerCreatedCommand()
        {

        }
        public CustomerCreatedCommand(int _userid, string _firstName, string _lastName, int _age, string _city)
        {
            Userid = _userid;
            Firstname = _firstName;
            Lastname = _lastName;
            Age = _age;
            City = _city;
        }

        public void HandleCommand(ICustomerCommand command)
        {
            _handler.HandleCustomerCreated(command);
        }
    }
}
