using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.entities
{
    public class UserIdentifier
    {
        public int identifier;
        public UserIdentifier(int id)
        {
            if ((id <= 0) || (id >= 100)) {
                throw new ApplicationException("Id must be between 1 and 100");
            }
            identifier = id;
        }
    }
}
