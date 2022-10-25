using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Repository.Models
{
    public class PlaceListParameters:DefaultListParameters
    {
        public int? placeId { get; set; }
    }
}
