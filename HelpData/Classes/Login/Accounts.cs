using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Login
{
    [Table("accounts")]
    public class Accounts
    {
        [Key]
        public int Guid { get; set; }
        public string? Account { get; set; }
        public string? Pass { get; set; }
        public bool Banned { get; set; }
        public long BannedTime { get; set; }
        public string? Pseudo { get; set; }
        public string? Question { get; set; }
        public string? Reponse { get; set; }
        public string? LastConnectionDate { get; set; }
        public string? LastIp { get; set; }
        public string? Friends { get; set; }
        public string? Enemy { get; set; }
        public int Vip { get; set; }
        public bool Reload_Needed { get; set; }
        public int Logged { get; set; }
        public int Votes { get; set; }
        public int TotalVotes { get; set; }
        public long Subscribe { get; set; }
        public long HeureVote { get; set; }
        public int Points { get; set; }
        public long MuteTime { get; set; }
        public string? MuteRaison { get; set; }
        public string? MutePseudo { get; set; }
        public int Image { get; set; }
        public string? Email { get; set; }
        public string? LastVoteIp { get; set; }
        public bool ShowOrHide { get; set; }
        public bool ShowOrHidePos { get; set; }
        public string? DateRegister { get; set; }
        public string? LastConnectDay { get; set; }
        public int Rules { get; set; }
        public int Admin { get; set; }
        public string? SwitchPacketKey { get; set; }
        public List<Players>? Nav_Players { get; set; }
    }
}
