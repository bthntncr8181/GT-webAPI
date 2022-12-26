using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities.Constants
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public Customer? Customer { get; set; }
        public long? customerId { get; set; }

    }
}
