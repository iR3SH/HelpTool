using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Spells
{
    public class Zones
    {
        public string? ZoneCode {  get; set; }
        public string? Name { get; set; }
        private string? Path { get; set; }
        public string? IconPath { get { return Path; } set { Path = "/Resources/Icons/" + value + ".png"; } }
    }
}
