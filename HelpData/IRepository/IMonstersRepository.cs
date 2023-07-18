using HelpData.Classes.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpData.IRepository
{
    public interface IMonstersRepository
    {
        public Task<List<Monsters>> GetAll();
        public Task<Monsters?> Get(int id);
        public Task Create(Monsters monster);
        public Task Update(Monsters monster);
    }
}
