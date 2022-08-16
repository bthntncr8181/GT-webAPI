using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class CafeRegisterResponseDto
    {


        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public long Phone { get; set; }
    }
}
