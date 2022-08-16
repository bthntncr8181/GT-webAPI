using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class CustomerRegisterResponseDto
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    
        public string Adress { get; set; }
        public int Phone { get; set; }
    }
}
