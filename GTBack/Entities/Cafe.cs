using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Cafe:BasePlace
    {



        public List<CustomerFavoriteCafeRelation> CustomerFavoriteCafeRelations { get; set; }


        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public int CategoryId { get; set; } = 1;
        //Self ATT
    }
}
