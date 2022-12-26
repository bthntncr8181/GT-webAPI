using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class UpdateCustomer
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

  
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
