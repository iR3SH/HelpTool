using HelpData.Classes.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpData.Classes.Monsters
{
    public class MobGrade
    {
        public int Grade { get; set; }
        public int Level { get; set; }
        public int Pa { get; set; } 
        public int Pm { get; set; }
        public int Initiative { get; set; }
        public int Vitalite { get; set; }
        public int Sagesse { get; set; }
        public int Force { get; set; }
        public int Intelligence { get; set; }
        public int Chance { get; set; }
        public int Agilite { get; set; }
        public int Dommages { get; set; }
        public int DommagesPer { get; set; }
        public int Soins { get; set; }
        public int Creatures { get; set; }
        public int ResNeutre { get; set; }
        public int ResTerre { get; set; }
        public int ResFeu { get; set; }
        public int ResEau { get; set; }
        public int ResAir { get; set; }
        public int EsqPa { get; set; }
        public int EsqPm { get; set; }
        public List<Sorts>? Sorts { get; set; }
        public List<int>? SortsLevels { get; set; }
        public int Experience { get; set; }
    }
}
