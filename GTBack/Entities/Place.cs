using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTBack.Core.Entities.Widgets;

namespace GTBack.Core.Entities
{
    public class Place:BaseEntity
    {
     
        public string Username { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address {get; set; }
        
      

        public long favCount { get; set; }
        public ICollection<ExtensionStrings> ExtensionStrings { get; set; }
        public ICollection<Attributes> Attributes { get; set; }
        public ICollection<Widget> Widget { get; set; }
        public ICollection<MenuWidget>? MenuWidget { get; set; }

        public ICollection<GalleryWidget>? GalleryWidget { get; set; }
        public long customerId { get; set; }


       
  

        public Customer customer { get; set; }
     

    }
}
