using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class PlaceInWidget:BaseEntity
    {
       public long placeId { get; set; }
        public long widgetId { get; set; }
        public Place place { get; set; }
        public Widget widget { get; set; }
    }
}
