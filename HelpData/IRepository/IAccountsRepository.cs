using HelpData.Classes.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.IRepository
{
    public interface IAccountsRepository
    {
        public Task<List<Accounts>> GetAll();
        public Task<Accounts?> Get(int Guid);
    }
}
