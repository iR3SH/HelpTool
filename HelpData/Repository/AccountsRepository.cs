using HelpData.Classes.Login;
using HelpData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly LoginDbContext _context;
        public AccountsRepository(LoginDbContext context)
        {
            _context = context;
        }

        public async Task<List<Accounts>> GetAll()
        {
            List<Accounts> accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<Accounts?> Get(int Guid)
        {
            Accounts? account = await _context.Accounts.FirstOrDefaultAsync(x => x.Guid == Guid);
            return account;
        }
    }
}
