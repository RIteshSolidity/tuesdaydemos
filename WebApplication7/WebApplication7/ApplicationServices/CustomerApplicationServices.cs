using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.commands;
using WebApplication7.CommandHandlers;

namespace WebApplication7.ApplicationServices
{

    public interface ICustomerApplicationServices {
        void Handle(ICommand command);
    }
    public class CustomerApplicationServices : ICustomerApplicationServices
    {
        ICommandHandler handler;
        public CustomerApplicationServices(ICommandHandler _handler)
        {
            handler = _handler;
        }

        public void SetHandler(ICommandHandler _handler) {
            handler = _handler;
        }

        public  void Handle(ICommand command) {
            handler.HandleCommand(command);
        }
    }
}
