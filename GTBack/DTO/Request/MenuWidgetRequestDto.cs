using GTBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class MenuWidgetRequestDto:BaseDTO_
    {
        public long placeId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
