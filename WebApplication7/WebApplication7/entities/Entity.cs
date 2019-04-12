using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.events;

namespace WebApplication7.entities
{
    public abstract class Entity
    {
        private readonly List<object> _events;

        protected Entity()
        {
            _events = new List<object>();
        }

        public void apply(IEvents myevent) {
            when(myevent);
            //ValidateState();
            _events.Add(myevent);
        }

        public IEnumerable<Object> getChanges() {
            return _events.AsEnumerable<object>();
        }

        public void ClearChanges()
        {
            _events.Clear();
        }

        public abstract void when(IEvents myevent);
       // public abstract bool ValidateState();

    }
} 
