using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class MenuWidgetUpdateDto:BaseDTO_
    {
        public long Id { get; set; }
        public long placeId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
