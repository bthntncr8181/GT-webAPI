using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Entities
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Cafe> Cafe { get; set; }

        public ICollection<Restourant> Restourant { get; set; }


    }
}
