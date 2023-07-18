using HelpData.Classes.Game;
using HelpData.Classes.Login;
using HelpData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpData.Repository
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly LoginDbContext _context;
        private readonly HelpDbContext _helpDbContext;
        public PlayersRepository(LoginDbContext context, HelpDbContext helpDbContext)
        {
            _context = context;
            _helpDbContext = helpDbContext;
        }

        public async Task<List<Players>> GetAll()
        {
            List<Players> players = await _context.Players.ToListAsync();
            return players;
        }

        public async Task<Players?> Get(int Id)
        {
            Players? player = await _context.Players.Include(c => c.Nav_Accounts).FirstOrDefaultAsync(x => x.Id == Id);
            return player;
        }

        public async Task<List<Objects>> GetAllObjects(int PlayerId)
        {
            Players? player = await Get(PlayerId);
            List<Objects> objects = new();
            if(player != null)
            {
                if(!string.IsNullOrEmpty(player.Objets))
                {
                    foreach(string objId in player.Objets.Split('|'))
                    {
                        if (!string.IsNullOrEmpty(objId))
                        {
                            Objects? objet = await _helpDbContext.Objects.Include(c => c.ItemTemplate).FirstOrDefaultAsync(c => c.Id == Convert.ToInt32(objId));
                            if (objet != null)
                            {
                                objects.Add(objet);
                            }
                        }
                    }
                }
            }
            return objects;
        }
    }
}
