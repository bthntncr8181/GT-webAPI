using GTBack.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Models
{
    public class CustomerListParameters : DefaultListParameters
    {
        public int? customerId { get; set; }
    }
}
