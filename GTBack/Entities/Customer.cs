using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Customer:BaseEntity
    {

        public Customer()
        {
           
            placeId = 0;
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }

        public int placeId { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }



        




    }
}
