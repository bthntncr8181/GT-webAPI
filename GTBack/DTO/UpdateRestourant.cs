using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO
{
    public class UpdateRestourant
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int CategoryId { get; set; } = 1;
        public long Phone { get; set; }
    }
}
