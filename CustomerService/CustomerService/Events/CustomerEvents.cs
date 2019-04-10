using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Events
{
    public interface IEvents { }


        public class CustomerCreatedEvent : IEvents {
            public int CustomerId;
            public string FirstName;
            public string LasName;
            public string City;

            public CustomerCreatedEvent(int cid, string fname, string lname, string city)
            {
                CustomerId = cid;
                FirstName = fname;
                LasName = lname;
                City = city;
            }
        }

    
}
