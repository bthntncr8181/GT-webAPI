using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class CustomerFavoriteCafeRelation:BaseEntity
    {

        public Customer Customer { get; set; }

       public Cafe Cafe { get; set; }
        
        public int CustomerId { get; set; }
        public int CafeId { get; set; }

     




    }
}
