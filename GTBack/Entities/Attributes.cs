using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Attributes : BaseEntity
    {
        public int placeId { get; set; }

        public Place Place { get; set; }


        public string Name { get; set; }

        public bool isExist { get; set; }
    }
}
