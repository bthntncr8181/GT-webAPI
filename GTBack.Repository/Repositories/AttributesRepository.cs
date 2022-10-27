using GTBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Repository.Repositories
{
    public class AttributesRepository : GenericRepository<Attributes>
    {
        protected readonly AppDbContext _context;

        public AttributesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



    }
}
