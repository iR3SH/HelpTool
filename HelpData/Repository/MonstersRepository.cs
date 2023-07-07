using HelpData.Classes.Game;
using HelpData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Repository
{
    public class MonstersRepository : IMonstersRepository
    {
        private readonly HelpDbContext _context;
        public MonstersRepository(HelpDbContext context)
        {
            _context = context;
        }

        public async Task<List<Monsters>> GetAll()
        {
            List<Monsters> monsters = await _context.Monsters.ToListAsync();
            return monsters;
        }
        public async Task<Monsters?> Get(int Id)
        {
            Monsters? monster = await _context.Monsters.Where(c => c.Id == Id).FirstOrDefaultAsync();
            return monster;
        }
        public async Task Create(Monsters monster)
        {
            await _context.Monsters.AddAsync(monster);
            await _context.SaveChangesAsync();
        }
    }
}
