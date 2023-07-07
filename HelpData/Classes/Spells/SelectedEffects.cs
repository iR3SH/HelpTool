using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Spells
{
    public class SelectedEffects
    {
        public Effects? Effect { get; set; }
        public int DamageMin { get; set; }
        public int DamageMax { get; set; }
        public int GlypheColor { get; set; }
        public int SpellDuration { get; set; }
        public int Probability { get; set; }
        public string? Zone { get; set; }
        public string? DisplayName { get; set; }
        public string? IconPath { get; set; }
    }
}
