using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Spells
{
    public class Effects
    {
        public int EffectId { get; set; }
        public string? Name { get; set; }
        public string? HexEffectId { get; set; }
        private string? _Path { get; set; }
        public string ImagePath { get { return _Path == null ?  "/Resources/Icons/sort.png" : _Path; } set { _Path = "/Resources/Icons/" + value + ".png"; } }
    }
}
