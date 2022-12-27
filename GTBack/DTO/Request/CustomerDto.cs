using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Request
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string password { get; set; }

        public string? il { get; set; }
        public string? ilce { get; set; }

        public bool isDeleted { get; set; }


    }
}
