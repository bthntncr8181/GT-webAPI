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

        public int placeId { get; set; }

        public Place Place { get; set; }


        public int customerId { get; set; }

        public Customer Customer { get; set; }

        public int Count { get; set; }
        public string Type { get; set; }
    }
}
