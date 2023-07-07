using HelpData.Classes.Game;
using HelpData.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpData.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly HelpDbContext _context;

        public ItemsRepository(HelpDbContext context)
        {
            _context = context;
        }

        public async Task<List<ItemTemplate>> GetAll()
        {
            List<ItemTemplate> items = await _context.Items.ToListAsync();
            return items;
        }

        public async Task<ItemTemplate?> Get(int Id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task Create(ItemTemplate itemTemplate)
        {
            _context.Items.AsNoTracking();
            _context.Add(itemTemplate);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ItemTemplate itemTemplate)
        {
            _context.Update(itemTemplate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            ItemTemplate? itemTemplate = await Get(Id);
            if (itemTemplate != null)
            {
                _context.Items.Remove(itemTemplate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
