using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HelpData.Classes.Login
{
    [Table("players")]
    public class Players
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [Column("account")]
        public int Account { get; set; }
        public Accounts? Nav_Accounts { get; set; }
        public int Groupe { get; set; }
        public int Sexe { get; set; }
        public int Class { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Color3 { get; set; }
        public long Kamas { get; set; }
        public int SpellBoost { get; set; }
        public int Capital { get; set; }
        public int Energy { get; set; }
        public int Level { get; set; }
        public long Xp { get; set; }
        public int Size { get; set; }
        public int Gfx { get; set; }
        public int Alignement { get; set; }
        public int Honor { get; set; }
        public int Alvl { get; set; }
        public int Vitalite { get; set; }
        public int Force { get; set; }
        public int Sagesse { get; set; }
        public int Intelligence { get; set; }
        public int Chance { get; set; }
        public int Agilite { get; set; }
        public bool SeeFriend { get; set; }
        public bool SeeAlign { get; set; }
        public bool SeeSeller { get; set; }
        public string? Canaux { get; set; }
        public int Map { get; set; }
        public int Cell { get; set; }
        public int PdvPer { get; set; }
        public string? Spells { get; set; }
        public string? Objets { get; set; }
        public string? StoreObjets { get; set; }
        public string? SavePos { get; set; }
        public string? Zaaps { get; set; }
        public string? Jobs { get; set; }
        public int MountXpGive { get; set; }
        public int Mount { get; set; }
        public int Title { get; set; }
        public int Wife { get; set; }
        public string? MorphMode { get; set; }
        public string? Emotes { get; set; }
        public long Prison { get; set; }
        public int Server { get; set; }
        public int Logged { get; set; }
        public string? AllTitle { get; set; }
        public string? Parcho { get; set; }
        public long TimeDeblo { get; set; }
        public bool NoAll { get; set; }
        public string? DeadInformation { get; set; }
        public int DeathCount { get; set; }
        public int TotalKills { get; set; }
        public int Prestige { get; set; }
        public string? Artefact { get; set; }
        public string? SaveSpells { get; set; }
        public int SaveSpellPts { get; set; }
    }
}
