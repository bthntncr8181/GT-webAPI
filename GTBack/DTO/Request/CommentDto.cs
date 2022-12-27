using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class CommentDto
    {
        public long Id { get; set; }
        public long placeId { get; set; }



        public long CustomerId { get; set; }


        public string Content { get; set; }
    }
}
