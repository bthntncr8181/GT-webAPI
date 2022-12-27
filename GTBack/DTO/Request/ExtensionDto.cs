using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class ExtensionDto : BaseDTO_
    {

        public long placeId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
