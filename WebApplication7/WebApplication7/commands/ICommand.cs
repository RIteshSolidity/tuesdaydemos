using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.commands
{
    public interface ICommand
    {
    }

    public class NewCustomerCommand : ICommand {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreditScore { get; set; }

        public NewCustomerCommand(int _custid, string fname, string lname, int cs)
        {
            CustomerId = _custid;
            FirstName = fname;
            LastName = lname;
            CreditScore = cs;

        }
    }
}
