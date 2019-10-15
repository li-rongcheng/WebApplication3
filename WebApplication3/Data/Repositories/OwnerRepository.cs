using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data.Models;

namespace WebApplication3.Data.Repositories
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }

    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }
    }
}
