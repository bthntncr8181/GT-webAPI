using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class WidgetPlaceRelation :BaseEntity
    {
        public int placeId { get; set; }
        public int widgetId { get; set; }
        public Place Place { get; set; }
        public Widget Widget { get; set; }

    }
}
