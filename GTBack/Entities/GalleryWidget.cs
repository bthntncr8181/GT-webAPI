using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class GalleryWidget:BaseEntity
    {
        public int placeId { get; set; }

        public Place place { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
