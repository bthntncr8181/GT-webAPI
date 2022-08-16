using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class RestourantDto : BaseDTO_
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string password { get; set; }
        public int Phone { get; set; }


        private int CategoryId = 2;
    }
}
