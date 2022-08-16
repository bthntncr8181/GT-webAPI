using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Restourant:BasePlace
    {

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
      
        public int CategoryId { get; set; } = 2;
        //SELF ATTRİBUTES
    }
    
}
