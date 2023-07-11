using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Spells
{
    public class SpellsEffects
    {
        public int SpellEffectLevel { get; set; }
        public int SpellId { get; set; }
        public string? Effect { get; set; }
        public string? EffectSwf { get; set; }
        public string? EffectCC { get; set; }
        public string? EffectCCSwf { get; set; }
        public int PaCost { get; set; }
        public int PoMin { get; set; }
        public int PoMax { get; set; }
        public int CC { get; set; }
        public int EC { get; set; }
        public string? Zone { get; set; }
        public bool IsInlineLaunch { get; set; }
        public bool IsWithoutLdv { get; set; }
        public bool IsEmptycell { get; set; }
        public bool IsPoEditable { get; set; }
        public bool IsEcFinishTurn { get; set; }
        public int SpellType { get; set; }
        public int RequireState { get; set; }
        public int LaunchPerTurn { get; set; }
        public int LaunchPerTurnPerPlayer { get; set; }
        public int TurnBetweenTwoLaunch { get; set; }
        public string? EffectTarget { get; set; }
        public int RequiredLevel { get; set; }
    }
}
