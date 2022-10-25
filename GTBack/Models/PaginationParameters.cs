using GTBack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Repository.Models
{
    public class PaginationParameters
    {

        public int? Take { get; set; }
        public int? Skip { get; set; }

        public ListOrderType Order { get; set; }

        public PaginationParameters()
        {
            Order = ListOrderType.Ascending;
        }

    }
}
