using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Widget:BaseEntity
    {
        public int type { get; set; }

       
        public ICollection<Place> Place { get; set; }


    }
}
