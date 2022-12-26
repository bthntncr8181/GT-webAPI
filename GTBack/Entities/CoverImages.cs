using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class CoverImages:BaseEntity
    {
        public long placeId { get; set; }
        public string img { get; set; }
    }
}
