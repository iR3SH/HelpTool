using HelpData.Classes.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.IRepository
{
    public interface IItemsRepository
    {
        public Task<List<ItemTemplate>> GetAll();
        public Task<ItemTemplate?> Get(int Id);
        public Task Create(ItemTemplate itemTemplate);
        public Task Update(ItemTemplate itemTemplate);
        public Task Delete(int Id);
    }
}
