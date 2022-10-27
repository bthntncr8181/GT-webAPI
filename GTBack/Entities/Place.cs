using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Place:BaseEntity
    {
        public Place()
        {
            
            cusutomerId = 0;
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address {get; set; }
    
        public ICollection<Attributes> Attributes { get; set; }
        public int? cusutomerId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
