using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomAttr
{
    public class EventAttribute:Attribute
    {
        public string EventName { get; set; }
        public EventAttribute(string EventName) 
        {
            
        }
    }
}
