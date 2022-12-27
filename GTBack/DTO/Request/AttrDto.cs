using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class AttrDto
    {
        public long placeId { get; set; }
        public string Name { get; set; }
        public bool isExist { get; set; }
    }
}
