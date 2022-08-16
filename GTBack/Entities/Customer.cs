using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Customer:BaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }


        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
      
        public string  Adress { get; set; }
        public long Phone { get; set; }

        public string Mail { get; set; }

        public List<CustomerFavoriteCafeRelation> CustomerFavoriteCafeRelations { get; set; }
    }
}
