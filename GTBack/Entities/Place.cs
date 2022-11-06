using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Place:BaseEntity
    {
     
        public string Username { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address {get; set; }
        
        

        public long favCount { get; set; }
        public ICollection<ExtensionStrings> ExtensionStrings { get; set; }
        public ICollection<Attributes> Attributes { get; set; }
        public int cusutomerId { get; set; }

        public Customer customer { get; set; }
     

    }
}
