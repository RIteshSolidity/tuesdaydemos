using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.events;
using WebApplication7.commands;


namespace WebApplication7.entities
{
    public class CustomerEntity : Entity
    {
        public int CustomerId;
        public string firstName;
        public string lastName;


        public CustomerCreatedEvent CreateCustomer(NewCustomerCommand cust) {
            CustomerCreatedEvent ee = new CustomerCreatedEvent { CustomerId = cust.CustomerId, LastName = cust.LastName, FirstName = cust.FirstName };
            apply(ee);
            return ee;
        }

        public override void when(IEvents myevent) {
            string abc = myevent.GetType().Name;
            switch (abc)
            {
                case "CustomerCreatedEvent":
                    {
                        var cust = myevent as CustomerCreatedEvent;
                        CustomerId = cust.CustomerId;
                        firstName = cust.FirstName;
                        lastName = cust.LastName;
                        break;
                    }
            }
        }
    }
}
