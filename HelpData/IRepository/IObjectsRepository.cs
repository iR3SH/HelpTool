using HelpData.Classes.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.IRepository
{
    public interface IObjectsRepository
    {
        public Task<List<Objects>> GetAll(int PlayerId);
        public Task<Objects?> Get(int Id);
    }
}
