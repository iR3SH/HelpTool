using HelpData.Classes.Game;
using HelpData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace HelpData.Repository
{
    public class ObjectsRepository : IObjectsRepository
    {
        private readonly HelpDbContext _context;
        public ObjectsRepository(HelpDbContext context)
        {
            _context = context;
        }

        public async Task<List<Objects>> GetAll(int PlayerId)
        {
            return await _context.Objects.Include(c => c.ItemTemplate).ToListAsync();
        }

        public async Task<Objects?> Get(int Id)
        {
            return await _context.Objects.Include(c => c.ItemTemplate).FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
