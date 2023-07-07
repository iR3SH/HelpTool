using HelpData.Classes.Game;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HelpData.IRepository
{
    public interface ISortsRepository
    {
        public Task<List<Sorts>> GetAll();
        public Task<List<Sorts>> GetAllNoTracking();
        public Task<Sorts?> Get(int id);
        public Task Create(Sorts sort);
        public Task Update(Sorts sort);
        public Task Delete(int id);
    }
}
