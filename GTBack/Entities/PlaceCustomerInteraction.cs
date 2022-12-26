using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class PlaceCustomerInteraction : BaseEntity


    {

        public PlaceCustomerInteraction()
        {
           Count = 0;
        }

        public long placeId { get; set; }

        public Place Place { get; set; }


        public long customerId { get; set; }

        public Customer Customer { get; set; }

        public long Count { get; set; }
        public string Type { get; set; }
    }
}
