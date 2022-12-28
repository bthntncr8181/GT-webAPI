using GTBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class GalleryWidgetRequestDto
    {

        public long Id { get; set; }
        public long placeId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
