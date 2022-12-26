using GTBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class CommentResDto:BaseDTO_
    {

        public long placeId { get; set; }



        public long CustomerId { get; set; }


        public string Content { get; set; }

        public string CustomerName{ get; set; }
    }
}
