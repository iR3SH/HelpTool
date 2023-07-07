using HelpData.Classes.Game;
using HelpData.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HelpData.Repository
{
    public class SortsRepository : ISortsRepository
    {
        private readonly HelpDbContext _context;
        public SortsRepository(HelpDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sorts>> GetAll()
        {
            List<Sorts> spells = await _context.Sorts.ToListAsync();
            return spells;
        }
        public async Task<Sorts?> Get(int id)
        {
            Sorts? spell = await _context.Sorts.FindAsync(id);
            return spell;
        }
        public async Task Create(Sorts sort)
        {
            await _context.Sorts.AddAsync(sort);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Sorts sort)
        {
            _context.Sorts.Update(sort);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Sorts? spell = await Get(id);
            if (spell != null)
            {
                _context.Sorts.Remove(spell);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Sorts>> GetAllNoTracking()
        {
            List<Sorts> spells = await _context.Sorts.AsNoTracking().OrderBy(c => c.Id).ToListAsync();
            return spells;
        }
    }
}
