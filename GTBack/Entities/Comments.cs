using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Comments:BaseEntity
    {
        public long placeId { get; set; }

        public Place Place { get; set; }


        public long CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string Content { get; set; }
    }
}
