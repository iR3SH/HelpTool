using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Game
{
    public class Sorts
    {
        [Key]
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int Sprite { get; set; }
        public string? SpriteInfos { get; set; }
        public string? Lvl1 { get; set; } = "-1";
        public string? Lvl2 { get; set; } = "-1";
        public string? Lvl3 { get; set; } = "-1";
        public string? Lvl4 { get; set; } = "-1";
        public string? Lvl5 { get; set; } = "-1";
        public string? Lvl6 { get; set; } = "-1";
        public string? EffectTarget { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
    }
}
