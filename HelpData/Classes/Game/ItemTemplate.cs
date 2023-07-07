using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpData.Classes.Game
{
    [Table("item_template")]
    public class ItemTemplate
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public string? StatsTemplate { get; set; }
        public int Pod { get; set; }
        public int Panoplie { get; set; }
        public int Prix { get; set; }
        public string? Conditions { get; set; }
        public string? ArmesInfos { get; set; }
        public int Sold { get; set; }
        public int AvgPrice { get; set; }
        public int Points { get; set; }
        public int ExchangesObject { get; set; }
        public int NewPrice { get; set; }
    }
}
