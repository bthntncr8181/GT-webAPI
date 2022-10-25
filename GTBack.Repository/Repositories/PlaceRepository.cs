using GTBack.Core.Entities;
using GTBack.Repository;
using GTBack.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Repositories
{
    public class PlaceRepository : GenericRepository<Place>
    {
        protected readonly AppDbContext _context;

        public PlaceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



    }
}
