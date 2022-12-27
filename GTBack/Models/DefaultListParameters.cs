using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Repository.Models
{
    public class DefaultListParameters:PaginationParameters
    {
       public string? Search { get; set; }

        public bool? Rand { get; set; }

    }
}
