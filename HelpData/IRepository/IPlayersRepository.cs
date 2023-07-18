using HelpData.Classes.Game;
using HelpData.Classes.Login;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpData.IRepository
{
    public interface IPlayersRepository
    {
        public Task<List<Players>> GetAll();
        public Task<Players?> Get(int Id);
        public Task<List<Objects>> GetAllObjects(int PlayerId);
    }
}
