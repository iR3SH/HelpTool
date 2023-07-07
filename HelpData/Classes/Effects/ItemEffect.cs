using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Effects
{
    public class ItemEffect
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AddHexId { get; set; }
        public string? RemHexId { get; set; }
        public bool IsCacEffect { get; set; }
        private string? Path { get; set; }
        public string? IconPath { get { return Path; } set { Path = "/Resources/Icons/" + value + ".png"; } }
    }
}
