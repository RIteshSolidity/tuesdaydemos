using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.entities
{
    
    public class FirstNameValueObject
    {
        public string firstName;
        public FirstNameValueObject(string _name)
        {
            if (String.IsNullOrEmpty(_name))
                throw new ApplicationException("name is null");
            firstName = _name;
        }
    }
}
