using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.entities
{
    public abstract class entity
    {
        
        
    }

    public class CustomerEntity : entity {
        public UserIdentifier Userid { get;  set; }
        public FirstNameValueObject Firstname { get; private set; }
        public string Lastname { get; private set; }
        public int Age { get; private set; }
        public string City { get; private set; }
        public int Creditrating { get; private set; }

        public CustomerEntity(UserIdentifier _userid, FirstNameValueObject _firstName, string _lastName, int _age, string _city, int _creditrating)
        {
            Userid = _userid;
            Firstname = _firstName;
            Lastname = _lastName;
            Age = _age;
            City = _city;
            Creditrating = _creditrating;
        }

        public Users GetCustomerModelfromEntity() {
            return new Users
            {
                Userid = this.Userid.identifier,
                Firstname = this.Firstname.firstName,
                Lastname = this.Lastname,
                Age = this.Age,
                City = this.City,
                Creditrating = this.Creditrating
            };
        }


    }
}
