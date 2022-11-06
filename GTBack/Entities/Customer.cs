using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Customer:BaseEntity
    {

        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }

        public ICollection<Place> Place { get; set; }

        public string? profileİmgUrl { get; set; }

       

        public string PasswordHash { get; set; }
        


        public ICollection<RefreshToken> RefreshTokens { get; set; }





    }
}
