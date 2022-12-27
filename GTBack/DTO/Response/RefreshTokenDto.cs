using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.DTO.Response
{
    public class RefreshTokenDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public int? ChildId { get; set; }
        public int? ParentId { get; set; }
        public int? TeacherId { get; set; }

    }
}
