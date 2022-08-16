using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class CustomerDto
    {

        public string UserName { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }



        public string password { get; set; }
        public string Adress { get; set; }
        public long Phone { get; set; }
        public string Mail { get; set; }
    }
}
